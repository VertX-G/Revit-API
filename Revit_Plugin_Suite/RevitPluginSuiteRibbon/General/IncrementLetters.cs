using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitPluginSuiteRibbon.General
{
    class IncrementLetters
    {
        public static string Increment(string s)

        {

            // first case - string is empty: return "A"
            if ((s == null) || (s.Length == 0))
            {
                return "A";
            }

            // next case - last char is less than 'Z': increment last char
            char lastChar = s[s.Length - 1];
            string fragment = s.Substring(0, s.Length - 1);

            //check uppercase
            if (char.IsUpper(lastChar) && lastChar < 'Z')
            {
                ++lastChar;
                return fragment + lastChar;
            }

            //check lowercase
            else if (char.IsLower(lastChar) && lastChar < 'z')
            {
                ++lastChar;
                return fragment + lastChar;
            }

            // next case - last char is 'Z': roll over and increment preceding string
            //check uppercase
            if (char.IsUpper(lastChar))
            {
                return Increment(fragment) + 'A';
            }

            //check lowercase
            else
            {
                return Increment(fragment) + 'a';
            }
        }
    }
}
