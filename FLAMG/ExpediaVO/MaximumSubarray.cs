using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class MaximumSubarray
    {
        /// <summary>
        /// prefix Sum
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// 
        public int MaxSubArray(int[] nums)
        {
            /*
             nums: [-2,1,-3,4,-1,2,1,-5,4]
             

             f[i]: 代表以第i个数结尾的【连续子数组的最大和】
             maxSumArraySum: max(f[0]....f[n-1])
            如何求f[i]， 考虑nums[i]是单独成为一段还是加入f[i-1]对应的那一段，这取决于nums[i]和f[i-1]+nums[i]的大小， 我们希望获得比较大的
             f[i] = max(f[i-1] + nums[i], nums[i])
            
            走完这一生 如果我和你在一起会变得更好，那我们就在一起，否则我就丢下你。 我回顾我最光辉的时刻就是和不同人在一起，变得更好的最长连续时刻

            T: O(N)
            S: O(N)

             */

            var dp = new int[nums.Length];
            dp[0] = nums[0];
            var maxSum = nums[0];
            for(int i = 1; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
                maxSum = Math.Max(maxSum, dp[i]);
            }
            return maxSum;
        }
        public int MaxSubArray1(int[] nums)
        {
            var pre = nums[0];
            var maxSum = nums[0];
            for(int i = 1; i < nums.Length; i++)
            {
                pre = Math.Max(pre + nums[i], nums[i]);
                maxSum = Math.Max(maxSum, pre);
            }
            return maxSum;
        }

        // follow up: Find the maximum subarray
        public int[] FindMaxSubarray(int[] nums)
        {
            var dp = new int[nums.Length];
            dp[0] = nums[0];
            var maxSum = nums[0];
            var res = new List<int>();
            var right = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
                if (maxSum < dp[i])
                    right = i;
                maxSum = Math.Max(maxSum, dp[i]);
            }
           
            int left = right;
            while(left >= 0)
            {
                if (maxSum == 0)
                    break;
                else
                {
                    maxSum -= nums[left];
                    left--;
                }
            }
            for(int i = left; i <= right; i++)
            {
                res.Add(nums[i]);
            }
            return res.ToArray();

        }
    }
}
