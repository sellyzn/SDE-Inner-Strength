using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.ArrayCategory
{
    internal class MaximumSubarray
    {
        // 53. Maximum Subarray
        // DP
        // T: O(N)
        // S: O(1)
        public int MaxSubArray(int[] nums)
        {
            var curSubarray = nums[0];
            var maxSubarray = nums[0];
            for(int i = 1; i < nums.Length; i++)
            {
                curSubarray = Math.Max(nums[i], curSubarray + nums[i]);
                maxSubarray = Math.Max(maxSubarray, curSubarray);
            }
            return maxSubarray;
        }
    }
}
