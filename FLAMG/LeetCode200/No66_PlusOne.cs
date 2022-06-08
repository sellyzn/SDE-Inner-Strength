using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No66_PlusOne
    {
        /// <summary>
        /// if digits[i] < 9, digits[i] += 1, return digits.
        /// if all the digits are 9, then assign all digits to 0, and add 1 to the begining place. (new a result array, which length is digits.Length + 1, and assign result[0] = 1, the others are d.efault 0, so just return result directly)
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public int[] PlusOne(int[] digits)
        {           
            for(int i = digits.Length - 1; i >= 0; i--)
            {
                if(digits[i] < 9)
                {
                    digits[i] += 1;
                    return digits;
                }
                digits[i] = 0;
            }
            int[] result = new int[digits.Length + 1];
            result[0] = 1;
            return result;
        }
    }
}
