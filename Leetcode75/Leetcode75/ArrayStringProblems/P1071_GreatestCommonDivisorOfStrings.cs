using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.ArrayStringProblems
{
    internal class P1071_GreatestCommonDivisorOfStrings
    {
        public string GcdOfStrings(string str1, string str2)
        {
            if(str1 + str2 != str2 + str1)
            {
                return "";
            }
            return str1.Substring(0, GCD(str1.Length, str2.Length));
        }
        public int GCD(int a, int b)
        {
            int remaider = a % b;
            while(remaider != 0)
            {
                a = b;
                b = remaider;
                remaider = a % b;
            }
            return b;
        }
    }
}
