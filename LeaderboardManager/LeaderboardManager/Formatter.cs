using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static readonly string FormatHelp = @"The format will be used to parse the information that the user is supposed to input, after it has been decrypted.
                                                     A proper format needs to contain following keywords: name, value, comment.
                                                     These keywords can only appear once and need to be seperated by at least one delimiter.";

        public static bool ValidateFormat(string format)
        {
            if (string.IsNullOrWhiteSpace(format))
                return false;

            //TODO add format validation
            return true;
        }

        public static bool TryParse(string input, string format, out UserInfo userInfo)
        {
            throw new NotImplementedException();
        }
    }
}
