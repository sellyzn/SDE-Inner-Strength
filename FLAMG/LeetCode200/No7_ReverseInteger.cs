using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No7_ReverseInteger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// T: O(log10X)
        /// S: O(1)
        /// 
        /// Note: result should be long, and transform to int at last.
        /// result > int.MaxValue || result < int.MinValue, return 0.
        public int Reverse(int x)
        {
            long result = 0;
            while (x != 0)
            {
                var digit = x % 10;
                result = result * 10 + digit;
                x /= 10;
            }
            return ((result > int.MaxValue) || (result < int.MinValue)) ? 0 : (int)result;
        }
    }
}
