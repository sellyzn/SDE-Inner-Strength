using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No136_SingleNumber
    {
        /// <summary>
        /// Bit Manipulation
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(n)
        /// S: O(1)
        public int SingleNumber(int[] nums)
        {
            if(nums.Length == 1)
                return nums[0];
            var result = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                result ^= nums[i];
            }
            return result;
        }
    }
}
