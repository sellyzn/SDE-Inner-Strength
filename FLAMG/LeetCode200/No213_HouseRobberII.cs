using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No213_HouseRobberII
    {
        public int Rob(int[] nums)
        {
            if(nums == null || nums.Length == 0)
                return 0;
            int n = nums.Length;
            if(n == 1)
                return nums[0];
            return Math.Max(RobRange(nums, 1, n - 2), Math.Max(RobRange(nums, 0, n - 2), RobRange(nums, 1, n - 1)));
        }
        public int RobRange(int[] nums, int start, int end)
        {            
            var length = end - start + 1;
            if (length == 1)
                return nums[start];
            if(length == 2)
                return Math.Max(nums[start], nums[end]);
            var dp = new int[length];
            dp[start] = nums[start];
            dp[start + 1] = Math.Max(nums[start], nums[start + 1]);
            for(int i = start + 2; i <= end; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
            }
            return dp[length - 1];
        }
    }
}
