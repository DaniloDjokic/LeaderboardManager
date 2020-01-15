using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LeaderboardManager
{
    public struct UserInfo
    {
        public string name { get; set; }
        public double value { get; set; }
        public string comment { get; set; }
    }

    public static class Formatter
    {
        private class FormatInfo
        {

            public string format { get; set; }
            public Match nameMatch { get; set; }
            public Match scoreMatch { get; set; }
            public Match commentMatch { get; set; }
            public int delimiterStartAfterNameIndex { get; set; }
            public int delimiterStartAfterScoreIndex { get; set; }
            public int delimiterStartAfterCommentIndex { get; set; }
            public string nameDelimiter { get; set; }
            public string scoreDelimiter { get; set; }
            public string commentDelimiter { get; set; }

            public void ParseDelimiters()
            {
                try
                {
                    List<Match> orderedMatches = (new List<Match>() { nameMatch, scoreMatch, commentMatch }).OrderBy(m => m.Index).ToList();
                    foreach (var match in orderedMatches)
                    {
                        int indexOf = orderedMatches.IndexOf(match);
                        int delimiterLength;

                        if (match == nameMatch)
                        {
                            if (indexOf < (orderedMatches.Count - 1))
                            {
                                delimiterLength = orderedMatches[indexOf + 1].Index - delimiterStartAfterNameIndex;
                            }
                            else
                            {
                                delimiterLength = format.Length - delimiterStartAfterNameIndex;
                            }

                            nameDelimiter = format.Substring(delimiterStartAfterNameIndex, delimiterLength);

                            continue;
                        }

                        if (match == scoreMatch)
                        {
                            if (indexOf < (orderedMatches.Count - 1))
                            {
                                delimiterLength = orderedMatches[indexOf + 1].Index - delimiterStartAfterScoreIndex;
                            }
                            else
                            {
                                delimiterLength = format.Length - delimiterStartAfterScoreIndex;
                            }

                            scoreDelimiter = format.Substring(delimiterStartAfterScoreIndex, delimiterLength);

                            continue;
                        }

                        if (match == commentMatch)
                        {
                            if (indexOf < (orderedMatches.Count - 1))
                            {
                                delimiterLength = orderedMatches[indexOf + 1].Index - delimiterStartAfterCommentIndex;
                            }
                            else
                            {
                                delimiterLength = format.Length - delimiterStartAfterCommentIndex;
                            }

                            commentDelimiter = format.Substring(delimiterStartAfterCommentIndex, delimiterLength);

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

        public static readonly string FormatHelp = @"The format will be used to parse the information that the user is supposed to input, after it has been decrypted.
                                                     A proper format needs to contain following keywords: name:value, score:value, comment:value . In the generated code,
                                                     value words will be replaced with coresponding values.
                                                     These keywords can only appear once and need to be seperated by at least one delimiter.";

        private static string nameKeyword = "name:value";
        private static string scoreKeyword = "score:value";
        private static string commentKeyword = "comment:value";

        private static Regex rexName = new Regex(nameKeyword);
        private static Regex rexScore = new Regex(scoreKeyword);
        private static Regex rexComment = new Regex(commentKeyword);

        private static FormatInfo GenerateFormatInfo(string format)
        {
            if (string.IsNullOrWhiteSpace(format))
                return null;

            FormatInfo result = new FormatInfo();
            result.format = format;
            result.nameMatch = rexName.Match(format);
            result.scoreMatch = rexScore.Match(format);
            result.commentMatch = rexComment.Match(format);

            result.delimiterStartAfterNameIndex = result.nameMatch.Index + nameKeyword.Length;
            result.delimiterStartAfterScoreIndex = result.scoreMatch.Index + scoreKeyword.Length;
            result.delimiterStartAfterCommentIndex = result.commentMatch.Index + commentKeyword.Length;

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
                if (!formatInfo.nameMatch.Success || !formatInfo.scoreMatch.Success || !formatInfo.commentMatch.Success)
                {
                    throw new Exception("One of the keywords was not found.");
                }

                //if any of the keywords appears more than once
                if (formatInfo.nameMatch.NextMatch().Success || formatInfo.scoreMatch.NextMatch().Success || formatInfo.commentMatch.NextMatch().Success)
                {
                    throw new Exception("One of the keywords appears more than once.");
                }


                //if any other keyword starts right after the name keyword without a delimiter
                if (formatInfo.delimiterStartAfterNameIndex == formatInfo.scoreMatch.Index || formatInfo.delimiterStartAfterNameIndex == formatInfo.commentMatch.Index)
                {
                    throw new Exception("No delimiter after the name keyword.");
                }

                //if any other keyword starts right after the score keyword without a delimiter
                if (formatInfo.delimiterStartAfterScoreIndex == formatInfo.nameMatch.Index || formatInfo.delimiterStartAfterScoreIndex == formatInfo.commentMatch.Index)
                {
                    throw new Exception("No delimiter after the score keyword.");
                }

                //if any other keyword starts right after the comment keyword without a delimiter
                if (formatInfo.delimiterStartAfterCommentIndex == formatInfo.nameMatch.Index || formatInfo.delimiterStartAfterCommentIndex == formatInfo.scoreMatch.Index)
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
                List<Match> orderedMatches = (new List<Match>() { formatInfo.nameMatch, formatInfo.scoreMatch, formatInfo.commentMatch }).OrderBy(m => m.Index).ToList();
                foreach (var match in orderedMatches)
                {
                    int indexOf = orderedMatches.IndexOf(match);
                    string searchStringInInput;
                    Regex rexInput;
                    Match inputMatch;
                    Regex rexDelimiter;
                    Match delimiterMatch;

                    if (match == formatInfo.nameMatch)
                    {
                        searchStringInInput = "name:";
                        rexInput = new Regex(searchStringInInput);
                        inputMatch = rexInput.Match(input);

                        if (!inputMatch.Success)
                        {
                            throw new Exception("Input does not comply with the format: Couldn't match name.");
                        }

                        int valueStart = inputMatch.Index + searchStringInInput.Length;

                        if (!string.IsNullOrWhiteSpace(formatInfo.nameDelimiter))
                        {
                            rexDelimiter = new Regex(formatInfo.nameDelimiter);
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

                    if (match == formatInfo.scoreMatch)
                    {
                        searchStringInInput = "score:";
                        rexInput = new Regex(searchStringInInput);
                        inputMatch = rexInput.Match(input);

                        if (!inputMatch.Success)
                        {
                            throw new Exception("Input does not comply with the format: Couldn't match score.");
                        }

                        int valueStart = inputMatch.Index + searchStringInInput.Length;

                        if (!string.IsNullOrWhiteSpace(formatInfo.scoreDelimiter))
                        {
                            rexDelimiter = new Regex(formatInfo.scoreDelimiter);
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

                    if (match == formatInfo.commentMatch)
                    {
                        searchStringInInput = "comment:";
                        rexInput = new Regex(searchStringInInput);
                        inputMatch = rexInput.Match(input);

                        if (!inputMatch.Success)
                        {
                            throw new Exception("Input does not comply with the format: Couldn't match comment.");
                        }

                        int valueStart = inputMatch.Index + searchStringInInput.Length;

                        if (!string.IsNullOrWhiteSpace(formatInfo.commentDelimiter))
                        {
                            rexDelimiter = new Regex(formatInfo.commentDelimiter);
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

                userInfo.name = foundName;
                userInfo.value = scoreValue;
                userInfo.comment = foundComment;

                return userInfo;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Input does not comply with the format: ", e);
            }
        }


    }
}
