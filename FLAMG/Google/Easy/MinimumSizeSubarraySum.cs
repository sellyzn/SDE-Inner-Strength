using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.Easy
{
    internal class MinimumSizeSubarraySum
    {
        // 209. 
        // prefixsum
        public int MinSubArrayLen(int target, int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            var prefixSum = new int[nums.Length + 1];
            prefixSum[0] = 0;
            for (int i = 1; i <= nums.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
            }
            var minLength = int.MaxValue;
            int left = 0, right = 0;
            while (left < prefixSum.Length && right < prefixSum.Length)
            {
                right = left;
                while (right < prefixSum.Length && prefixSum[right] - prefixSum[left] < target)
                    right++;
                if (right < prefixSum.Length)
                {
                    minLength = Math.Min(minLength, right - left);
                    left++;
                }
                else
                    break;
            }
            return minLength = minLength == int.MaxValue ? 0 : minLength;
        }
    }
}
