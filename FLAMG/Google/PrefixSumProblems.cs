using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Google
{
    public class PrefixSumProblems
    {
        public int MinSubArrayLen_BruteForce(int target, int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            var minLen = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                var sum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    sum += nums[j];
                    if(sum >= target)
                    {
                        minLen = Math.Min(minLen, j - i + 1);
                        break;
                    }
                }
            }
            return minLen == int.MaxValue ? 0 : minLen;
        }
        public int MinSubArrayLen_prefixSum(int target, int[] nums)
        {
            // spilt the subarray: prefixSum
            // use a variable minLength to record the min SubArray length, traverse the prefixSum array to find the r-l+1 value of prefixSum[r] - prefixSum[l] >= target

            if (nums == null || nums.Length == 0)
                return 0;

            var prefixSum = new int[nums.Length + 1];
            prefixSum[0] = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
            }
            var minLength = int.MaxValue;
            int left = 0, right = 0;
            while(right < prefixSum.Length)
            {
                right = left;
                while (right < prefixSum.Length && prefixSum[right] - prefixSum[left] < target)
                    right++;
                if(right < prefixSum.Length)
                {
                    minLength = Math.Min(minLength, right - left - 1);
                    left++;
                }                
            }
            return minLength = minLength == int.MaxValue ? 0 : minLength;
        }
    }
}
