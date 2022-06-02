using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Google.Easy
{
    public class SubarraySumEqualsK
    {
        // [1,2,1,2,1]  3
        // left     0   0   1
        // right    0   1   1
        // sum      1   3   
        // count    0   1
        public int SubarraySum(int[] nums, int k)
        {
            Array.Sort(nums);
            if (nums == null || nums.Length == 0)
                return 0;
            int left = 0, right = 0;
            var count = 0;
            var sum = nums[0];
            while(left < nums.Length && right < nums.Length && left <= right)
            {
                if (nums[left] > k)
                    return count;
                if (sum == k)
                {
                    count++;
                    sum -= nums[left];
                    left++;
                }
                else if(sum < k)
                {
                    right++;
                    sum += nums[right];
                }else if(sum > k)
                {
                    sum -= nums[left];
                    left++;
                }
            }
            return count;
        }
        public int SubarraySum_PrefixSum(int[] nums, int k)
        {
            int count = 0, preSum = 0;
            var dict = new Dictionary<int, int>();
            dict.Add(0, 1);
            for (int i = 0; i < nums.Length; i++)
            {
                preSum += nums[i];
                if (dict.ContainsKey(preSum - k))
                    count += dict[preSum - k];
                if (dict.ContainsKey(preSum))
                    dict[preSum]++;
                else
                    dict.Add(preSum, 1);
            }
            return count;
        }
    }
}
