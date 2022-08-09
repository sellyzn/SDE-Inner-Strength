using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No198_HouseRobber
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int n = nums.Length;
            if (n == 1)
                return nums[0];
            var dp = new int[n];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[1], nums[0]);
            for(int i = 2; i < n; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
            }
            return dp[n - 1];
        }
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public int Rob_Op(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int n = nums.Length;
            if (n == 1)
                return nums[0];
            if (n == 2)
                return Math.Max(nums[0], nums[1]);
            var maxAmount = 0;
            var prev1 = nums[0];
            var prev2 = Math.Max(nums[0], nums[1]);
            for(int i = 2; i < n; i++)
            {
                maxAmount = Math.Max(prev1 + nums[i], prev2);
                prev1 = prev2;
                prev2 = maxAmount;
            }
            return maxAmount;
        }
    }
}
