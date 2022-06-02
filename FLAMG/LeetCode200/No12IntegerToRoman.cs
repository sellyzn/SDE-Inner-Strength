using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No12IntegerToRoman
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        /// T: O(1)
        /// S: O(1)
        public string IntToRoman(int num)
        {            
            var values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            var symbols = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            var roman = new StringBuilder();
            for(int i = 0; i < values.Length; i++)
            {
                int value = values[i];
                string symbol = symbols[i];
                while(num >= value)
                {
                    num -= value;
                    roman.Append(symbol);
                }
                if (num == 0)
                    break;
            }
            return roman.ToString();
        }
       
    }
}
