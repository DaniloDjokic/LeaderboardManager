using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LeaderboardManagerClientLibrary
{
    public struct UserInfo
    {
        public string Name { get; set; }
        public double Score { get; set; }
        public string Comment { get; set; }
    }

    public static class Formatter
    {
        private class FormatInfo
        {

            public string Format { get; set; }
            public Match NameMatch { get; set; }
            public Match ScoreMatch { get; set; }
            public Match CommentMatch { get; set; }
            public int DelimiterStartAfterNameIndex { get; set; }
            public int DelimiterStartAfterScoreIndex { get; set; }
            public int DelimiterStartAfterCommentIndex { get; set; }
            public string NameDelimiter { get; set; }
            public string ScoreDelimiter { get; set; }
            public string CommentDelimiter { get; set; }
            public List<Match> OrderedMatches { get; set; }

            public void ParseDelimiters()
            {
                try
                {
                    OrderedMatches = (new List<Match>() { NameMatch, ScoreMatch, CommentMatch }).OrderBy(m => m.Index).ToList();
                    foreach (var match in OrderedMatches)
                    {
                        int indexOf = OrderedMatches.IndexOf(match);
                        int delimiterLength;

                        if (match == NameMatch)
                        {
                            if (indexOf < (OrderedMatches.Count - 1))
                            {
                                delimiterLength = OrderedMatches[indexOf + 1].Index - DelimiterStartAfterNameIndex;
                            }
                            else
                            {
                                delimiterLength = Format.Length - DelimiterStartAfterNameIndex;
                            }

                            NameDelimiter = Format.Substring(DelimiterStartAfterNameIndex, delimiterLength);

                            continue;
                        }

                        if (match == ScoreMatch)
                        {
                            if (indexOf < (OrderedMatches.Count - 1))
                            {
                                delimiterLength = OrderedMatches[indexOf + 1].Index - DelimiterStartAfterScoreIndex;
                            }
                            else
                            {
                                delimiterLength = Format.Length - DelimiterStartAfterScoreIndex;
                            }

                            ScoreDelimiter = Format.Substring(DelimiterStartAfterScoreIndex, delimiterLength);

                            continue;
                        }

                        if (match == CommentMatch)
                        {
                            if (indexOf < (OrderedMatches.Count - 1))
                            {
                                delimiterLength = OrderedMatches[indexOf + 1].Index - DelimiterStartAfterCommentIndex;
                            }
                            else
                            {
                                delimiterLength = Format.Length - DelimiterStartAfterCommentIndex;
                            }

                            CommentDelimiter = Format.Substring(DelimiterStartAfterCommentIndex, delimiterLength);

                            continue;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException("Couldn't parse delimiters.", e);
                }
            }
        }

        public static string FormatHelp { get; } = @"The format will be used to parse the information that the user is supposed to input, after it has been decrypted.
                                                     A proper format needs to contain following keywords: name:value, score:value, comment:value . In the generated code,
                                                     value words will be replaced with coresponding values.
                                                     These keywords can only appear once and need to be seperated by at least one delimiter.";

        private static readonly string nameKeyword = "name:value";
        private static readonly string scoreKeyword = "score:value";
        private static readonly string commentKeyword = "comment:value";

        private static readonly Regex rexName = new Regex(nameKeyword);
        private static readonly Regex rexScore = new Regex(scoreKeyword);
        private static readonly Regex rexComment = new Regex(commentKeyword);

        private static FormatInfo GenerateFormatInfo(string format)
        {
            if (string.IsNullOrWhiteSpace(format))
                return null;

            FormatInfo result = new FormatInfo();
            result.Format = format;
            result.NameMatch = rexName.Match(format);
            result.ScoreMatch = rexScore.Match(format);
            result.CommentMatch = rexComment.Match(format);

            result.DelimiterStartAfterNameIndex = result.NameMatch.Index + nameKeyword.Length;
            result.DelimiterStartAfterScoreIndex = result.ScoreMatch.Index + scoreKeyword.Length;
            result.DelimiterStartAfterCommentIndex = result.CommentMatch.Index + commentKeyword.Length;

            try
            {
                result.ParseDelimiters();
            }
            catch 
            {
                return null;
            }

            return result;
        }

        private static FormatInfo ParseFormat(string format)
        {
            try
            {
                FormatInfo formatInfo = GenerateFormatInfo(format);

                if (formatInfo == null)
                {
                    throw new Exception("Generated format info was null.");
                }

                //if any of the keywords is not found
                if (!formatInfo.NameMatch.Success || !formatInfo.ScoreMatch.Success || !formatInfo.CommentMatch.Success)
                {
                    throw new Exception("One of the keywords was not found.");
                }

                //if any of the keywords appears more than once
                if (formatInfo.NameMatch.NextMatch().Success || formatInfo.ScoreMatch.NextMatch().Success || formatInfo.CommentMatch.NextMatch().Success)
                {
                    throw new Exception("One of the keywords appears more than once.");
                }


                //if any other keyword starts right after the name keyword without a delimiter
                if (formatInfo.DelimiterStartAfterNameIndex == formatInfo.ScoreMatch.Index || formatInfo.DelimiterStartAfterNameIndex == formatInfo.CommentMatch.Index)
                {
                    throw new Exception("No delimiter after the name keyword.");
                }

                //if any other keyword starts right after the score keyword without a delimiter
                if (formatInfo.DelimiterStartAfterScoreIndex == formatInfo.NameMatch.Index || formatInfo.DelimiterStartAfterScoreIndex == formatInfo.CommentMatch.Index)
                {
                    throw new Exception("No delimiter after the score keyword.");
                }

                //if any other keyword starts right after the comment keyword without a delimiter
                if (formatInfo.DelimiterStartAfterCommentIndex == formatInfo.NameMatch.Index || formatInfo.DelimiterStartAfterCommentIndex == formatInfo.ScoreMatch.Index)
                {
                    throw new Exception("No delimiter after the comment keyword.");
                }

                return formatInfo;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error parsing the format.", e);
            }
        }

        public static bool ValidateFormat(string format)
        {
            try
            {
                ParseFormat(format);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static UserInfo Parse(string input, string format)
        {
            FormatInfo formatInfo;
            try
            {
                formatInfo = ParseFormat(format);
            }
            catch (Exception e)
            {
                throw e;
            }

            string foundName = null;
            string foundScore = null;
            string foundComment = null;
            UserInfo userInfo = new UserInfo();

            try
            {               
                foreach (var match in formatInfo.OrderedMatches)
                {
                    int indexOf = formatInfo.OrderedMatches.IndexOf(match);
                    string searchStringInInput;
                    Regex rexInput;
                    Match inputMatch;
                    Regex rexDelimiter;
                    Match delimiterMatch;

                    if (match == formatInfo.NameMatch)
                    {
                        searchStringInInput = "name:";
                        rexInput = new Regex(searchStringInInput);
                        inputMatch = rexInput.Match(input);

                        if (!inputMatch.Success)
                        {
                            throw new Exception("Input does not comply with the format: Couldn't match name.");
                        }

                        int valueStart = inputMatch.Index + searchStringInInput.Length;

                        if (!string.IsNullOrWhiteSpace(formatInfo.NameDelimiter))
                        {
                            rexDelimiter = new Regex(formatInfo.NameDelimiter);
                            delimiterMatch = rexDelimiter.Match(input.Substring(valueStart));

                            if (!delimiterMatch.Success)
                            {
                                throw new Exception("Input does not comply with the format: Couldn't match name delimiter.");
                            }

                            foundName = input.Substring(valueStart, delimiterMatch.Index);
                        }
                        else
                        {
                            foundName = input.Substring(valueStart);
                        }

                        continue;
                    }

                    if (match == formatInfo.ScoreMatch)
                    {
                        searchStringInInput = "score:";
                        rexInput = new Regex(searchStringInInput);
                        inputMatch = rexInput.Match(input);

                        if (!inputMatch.Success)
                        {
                            throw new Exception("Input does not comply with the format: Couldn't match score.");
                        }

                        int valueStart = inputMatch.Index + searchStringInInput.Length;

                        if (!string.IsNullOrWhiteSpace(formatInfo.ScoreDelimiter))
                        {
                            rexDelimiter = new Regex(formatInfo.ScoreDelimiter);
                            delimiterMatch = rexDelimiter.Match(input.Substring(valueStart));

                            if (!delimiterMatch.Success)
                            {
                                throw new Exception("Input does not comply with the format: Couldn't match score delimiter.");
                            }

                            foundScore = input.Substring(valueStart, delimiterMatch.Index);
                        }
                        else
                        {
                            foundScore = input.Substring(valueStart);
                        }

                        continue;
                    }

                    if (match == formatInfo.CommentMatch)
                    {
                        searchStringInInput = "comment:";
                        rexInput = new Regex(searchStringInInput);
                        inputMatch = rexInput.Match(input);

                        if (!inputMatch.Success)
                        {
                            throw new Exception("Input does not comply with the format: Couldn't match comment.");
                        }

                        int valueStart = inputMatch.Index + searchStringInInput.Length;

                        if (!string.IsNullOrWhiteSpace(formatInfo.CommentDelimiter))
                        {
                            rexDelimiter = new Regex(formatInfo.CommentDelimiter);
                            delimiterMatch = rexDelimiter.Match(input.Substring(valueStart));

                            if (!delimiterMatch.Success)
                            {
                                throw new Exception("Couldn't match comment delimiter.");
                            }

                            foundComment = input.Substring(valueStart, delimiterMatch.Index);
                        }
                        else
                        {
                            foundComment = input.Substring(valueStart);
                        }

                        continue;
                    }
                }

                if (string.IsNullOrWhiteSpace(foundName))
                {
                    throw new Exception("Couldn't parse name.");
                }

                if (string.IsNullOrWhiteSpace(foundScore) || !double.TryParse(foundScore, out double scoreValue))
                {
                    throw new Exception("Couldn't parse score.");
                }

                if (foundComment == null)
                {
                    throw new Exception("Couldn't parse comment.");
                }

                userInfo.Name = foundName;
                userInfo.Score = scoreValue;
                userInfo.Comment = foundComment;

                return userInfo;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Input does not comply with the format: ", e);
            }
        }

        public static string GenerateFormattedString(string format, UserInfo userInfo)
        {
            FormatInfo formatInfo;
            try
            {
                formatInfo = ParseFormat(format);
            }
            catch (Exception e)
            {
                throw e;
            }

            if (userInfo.Name == null || userInfo.Comment == null)
            {
                throw new ArgumentNullException("Name and comment can't be null.");
            }

            string result = format;

            foreach (var match in formatInfo.OrderedMatches)
            {
                if (match == formatInfo.NameMatch)
                {
                    result = ReplaceFirst(result, "value", userInfo.Name);
                    continue;
                }

                if (match == formatInfo.ScoreMatch)
                {
                    result = ReplaceFirst(result, "value", userInfo.Score.ToString());
                    continue;
                }

                if (match == formatInfo.CommentMatch)
                {
                    result = ReplaceFirst(result, "value", userInfo.Comment);
                    continue;
                }
            }

            return result;
        }

        private static string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}
