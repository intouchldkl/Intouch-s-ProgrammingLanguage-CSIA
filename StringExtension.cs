using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace CS_IA_Ibasic_Intouch_Re
{
    static class StringExtension
    {
        public static bool compare(string value1 , string value2)
        {
            int result = string.Compare(value1.ToLower(), value2.ToLower());
            return result == 0;
        }
        public static bool Contains(string source, string toCheck)
        {
            StringComparison comp = StringComparison.InvariantCultureIgnoreCase;
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}
