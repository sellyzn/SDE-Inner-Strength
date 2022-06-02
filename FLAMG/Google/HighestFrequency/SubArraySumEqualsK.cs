using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.HighestFrequency
{
    public class SubArraySumEqualsK
    {
        // 560. Given an array of integers nums and an integer k, return the total number of subarrays whose sum equals to k.

        public int SubarraySumEqualsK_I(int[] nums, int k)
        {
            if(nums == null || nums.Length == 0)
                return 0;
            // traverse
            var count = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                var sum = 0;
                for(int j = i; j < nums.Length; j++)
                {
                    sum += nums[j];
                    if (sum == k)
                        count++;                    
                }
            }
            return count;
        }
        public int SubarraySumEqualsK_I_PrefixSum(int[] nums, int k)
        {
            if (nums == null || nums.Length <= 0)
                return 0;
            var dict = new Dictionary<int, int>();   // store the value - count pair: the value and the count numbers of the value
            var prefixSum = new int[nums.Length + 1];
            prefixSum[0] = 0;
            dict.Add(0, 1);     // (0, 1), not (0, 0)
            var count = 0;
            for (int i = 1; i <= nums.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
                if (dict.ContainsKey(prefixSum[i] - k))
                    count += dict[prefixSum[i] - k];
                if(dict.ContainsKey(prefixSum[i]))
                    dict[prefixSum[i]]++;
                else
                    dict.Add(prefixSum[i], 1);
            }
            return count;
        }

        // Subarray Sum Equals K II
        // Given an array of integers and an integer k, you need to find the minimum size of continuous no-empty subarrays whose sum equals to k, and return its length.
        // if there are no such subarray, return -1.
        public int SubarraySumEqualsK_II(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            // traverse
            var minLength = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                var sum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    sum += nums[j];
                    if (sum == k)
                        minLength = Math.Min(minLength, j - i + 1);                   
                }
            }
            return minLength = minLength == int.MaxValue ? -1 : minLength;
        }
        public int SubarraySumEqualsK_II_PrefixSum(int[] nums, int k)
        {
            if (nums == null || nums.Length <= 0)
                return 0;
            var dict = new Dictionary<int, List<int>>();   // store the value-index pair
            var prefixSum = new int[nums.Length + 1];
            prefixSum[0] = 0;
            dict.Add(0, new List<int> { 0 });
            var minLength = int.MaxValue;
            for (int i = 1; i <= nums.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
                if (dict.ContainsKey(prefixSum[i] - k))
                {
                    foreach (var index in dict[prefixSum[i] - k])
                    {
                        minLength = Math.Min(minLength, i - index);     // i - index, not i - index + 1
                    }
                }

                if (dict.ContainsKey(prefixSum[i]))
                    dict[prefixSum[i]].Add(i);
                else
                    dict.Add(prefixSum[i], new List<int> { i });

            }
            return minLength = minLength == int.MaxValue ? -1 : minLength;
        }

        // 325. Maximum Size Subarray Sum Equals K
        // Given an integer array nums and an integer k, return the maximum length of a subarray that sums to k. If there is not one, return 0 instead.
        public int MaxSubArrayLen(int[] nums, int k)
        {
            if (nums == null || nums.Length <= 0)
                return 0;
            var dict = new Dictionary<int, List<int>>();   // store the value-index pair
            var prefixSum = new int[nums.Length + 1];
            prefixSum[0] = 0;
            dict.Add(0, new List<int> { 0 });
            var maxLength = int.MinValue;
            for (int i = 1; i <= nums.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
                if (dict.ContainsKey(prefixSum[i] - k))
                {
                    foreach (var index in dict[prefixSum[i] - k])
                    {
                        maxLength = Math.Max(maxLength, i - index);     // i - index, not i - index + 1
                    }
                }

                if (dict.ContainsKey(prefixSum[i]))
                    dict[prefixSum[i]].Add(i);
                else
                    dict.Add(prefixSum[i], new List<int> { i });

            }
            return maxLength = maxLength == int.MinValue ? 0 : maxLength;
        }

        // 209. Minimum Size Subarray Sum
        // Given an array of positive integers nums and a positive integer target, return the minimal length of a contiguous subarray [numsl, numsl+1, ..., numsr-1, numsr] of which the sum is greater than or equal to target. If there is no such subarray, return 0 instead.
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
                while (right < prefixSum.Length && prefixSum[right] - prefixSum[left] < target)     // right < prefixSum.Length
                    right++;
                if (right < prefixSum.Length)       // right < prefixSum.Length.   [1,1,1] target = 11
                {
                    minLength = Math.Min(minLength, right - left);
                    left++;
                }
                else
                    break;      // end advance
            }
            return minLength = minLength == int.MaxValue ? 0 : minLength;
        }

    }
}
