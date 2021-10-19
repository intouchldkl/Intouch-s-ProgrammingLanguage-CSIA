using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace CS_IA_Ibasic_Intouch_Re
{
    /// <summary>
    /// This class is used to do a compare or contain check with the source being case insensitive
    /// </summary>
    static class StringExtension
    {
        /// <summary>
        /// Compares two string values case insensitively
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns> Boolean value if the two values are the same or not
        public static bool compare(string value1 , string value2)
        {
            int result = string.Compare(value1.ToLower(), value2.ToLower());
            return result == 0;
        }
        /// <summary>
        /// Case insensitive check if the source contains the string to check 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns> Bool value if the source contains the string or not
        public static bool Contains(string source, string toCheck)
        {
            //Specify that the comparison has to be case insensitive
            StringComparison comp = StringComparison.InvariantCultureIgnoreCase;
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}
