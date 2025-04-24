using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Utility
{
    public class Validator
    {
        static bool invalid = false;

        public static bool IsValidURL(string url)
        {

            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }
        public static bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private static string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
       
        public static bool IsDate1GreaterThanDate2(DateTime date1, DateTime date2)
        {
            bool isGreater = false;

            if (date1 > date2)
            {
                isGreater = true;
            }
            else
            {
                isGreater = false;
            }

            return isGreater;
        }

        public static bool IsDate1LessThanDate2(DateTime date1, DateTime date2)
        {
            bool isLesser = false;

            if (date1 < date2)
            {
                isLesser = true;
            }
            else
            {
                isLesser = false;
            }

            return isLesser;
        }

        public static bool IsValidDateRange(bool isValidLesser, bool isValidGreater)
        {
            bool isValidDateRange = false;
            if (isValidLesser && isValidGreater)
            {
                isValidDateRange = true;
            }
            else
            {
                isValidDateRange = false;
            }
            return isValidDateRange;
        }

        public static bool IsValidDateRange(DateTime selectedFromDate, DateTime selectedToDate, DateTime dtFromDate, DateTime dtToDate)
        {
            bool isValidDateRange = false;
            if (Utility.Validator.IsValidDateRange(((Utility.Validator.IsDate1LessThanDate2(selectedFromDate, dtFromDate)) && (Utility.Validator.IsDate1LessThanDate2(selectedToDate, dtFromDate))), (Utility.Validator.IsDate1GreaterThanDate2(selectedFromDate, dtToDate)) && (Utility.Validator.IsDate1GreaterThanDate2(selectedToDate, dtToDate))))
            { isValidDateRange = true; }
            else { isValidDateRange = false; }
            return isValidDateRange;
        }
    }
}
