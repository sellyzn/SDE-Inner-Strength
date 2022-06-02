using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No53MaximumSubarray
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        
        // Brute Force:
        public int MaxSubArray(int[] nums)
        {
            var maxSubarray = int.MinValue;
            for(int i = 0; i < nums.Length; i++)
            {
                var curSubarray = 0;
                for(int j = i; j < nums.Length; j++)
                {
                    curSubarray += nums[j];
                    maxSubarray = Math.Max(maxSubarray, curSubarray);
                }
            }
            return maxSubarray;
        }


        // DP:
        // curSubArray = Max(num, curSubarray + num)
        // T: O(N)
        // S: O(1)
        public int MaxSubarray_DP(int[] nums)
        {
            int curSubarray = nums[0];
            int maxSubarray = nums[0];
            for(int i = 1; i < nums.Length; i++)
            {
                curSubarray = Math.Max(nums[i], curSubarray + nums[i]);
                maxSubarray = Math.Max(maxSubarray, curSubarray);
            }
            return maxSubarray;
        }

    }
}
