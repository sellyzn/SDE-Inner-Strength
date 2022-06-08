using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No67_AddBinary
    {
        /// <summary>
        /// similar with merge sort
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// T: O(Max(M, N))
        /// S: O(Max(M, N))
        public string AddBinary(string a, string b)
        {
            if (a == null || a.Length == 0)
                return b;
            if (b == null || b.Length == 0)
                return a;
            var result = new StringBuilder();
            int i = a.Length - 1, j = b.Length - 1;
            int carry = 0;
            
            while(i >= 0 && j >= 0)
            {
                var sum = carry;
                sum += a[i] - '0';
                sum += b[j] - '0';
                result.Insert(0, sum % 2);
                carry = sum / 2;
                i--;
                j--;
            }
            while(i >= 0)
            {
                var sum = carry;
                sum += a[i] - '0';
                result.Insert(0, sum % 2);
                carry = sum / 2;
                i--;
            }
            while(j >= 0)
            {
                var sum = carry;
                sum += b[j] - '0';
                result.Insert(0, sum % 2);
                carry = sum / 2;
                j--;
            }
            if (carry != 0)
                result.Insert(0, 1);
            return result.ToString();
        }

        // Bit Mamipulation

    }
}
