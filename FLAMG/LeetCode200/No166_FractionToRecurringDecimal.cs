using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No166_FractionToRecurringDecimal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <returns></returns>
        public string FractionToDecimal(int numerator, int denominator)
        {
            if (numerator == 0)
                return "0";
            if (denominator == 0)
                return null;
            var fraction = new StringBuilder();
            if(numerator < 0 ^ denominator < 0)
                fraction.Append("-");

            long dividend = Math.Abs((long)numerator);
            long divisor = Math.Abs((long)denominator);
            fraction.Append((dividend / divisor).ToString());
            long remainder = dividend % divisor;
            if(remainder == 0)
                return fraction.ToString();
            fraction.Append(".");
            var map = new Dictionary<long, int>();
            while(remainder != 0)
            {
                if (map.ContainsKey(remainder))
                {
                    fraction.Insert(map[remainder], "(");
                    fraction.Append(")");
                    break;
                }
                map.Add(remainder, fraction.Length);
                remainder *= 10;
                fraction.Append((remainder / divisor).ToString());
                remainder %= divisor;
            }
            return fraction.ToString();
        }
    }
}
