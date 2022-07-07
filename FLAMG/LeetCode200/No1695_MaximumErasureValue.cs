using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No1695_MaximumErasureValue
    {
        /// <summary>
        /// Two Pointers using hashset, sliding window
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(m), m is the number of unique elements
        public int MaximumUniqueSubarray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            if(nums.Length == 1)
                return nums[0];
            int left = 0;
            var set = new HashSet<int>();
            int maxSum = 0, currentSum = 0;
            for(int right = 0; right < nums.Length; right++)
            {
                
                if (!set.Contains(nums[right]))
                {
                    currentSum += nums[right];
                    maxSum = Math.Max(maxSum, currentSum);
                    set.Add(nums[right]);
                }
                else
                {
                    while(left <= right && set.Contains(nums[right]))
                    {
                        set.Remove(nums[left]);
                        currentSum -= nums[left];
                        left++;
                    }
                    currentSum += nums[right];
                    set.Add(nums[right]);
                }
            }
            return maxSum;
        }
    }
}
