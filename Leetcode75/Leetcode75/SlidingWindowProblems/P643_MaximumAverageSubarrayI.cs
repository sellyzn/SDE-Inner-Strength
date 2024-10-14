using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.SlidingWindowProblems
{
    internal class P643_MaximumAverageSubarrayI
    {
        /*
        滑动窗口：
        时间：O(n)
        空间：O(1)
        */
        public double FindMaxAverage(int[] nums, int k)
        {
            double maxSum = 0;
            double sum = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if(i < k)
                {
                    maxSum += nums[i];
                    sum = maxSum;
                }
                else
                {
                    sum = sum + nums[i] - nums[i - k];
                    maxSum = Math.Max(maxSum, sum);
                }
            }
            return nums.Length >= k ? maxSum / k : maxSum / nums.Length;
        }
    }
}
