using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No26RemoveDuplicatesFromSortedArray
    {
        /// <summary>
        /// Two Pointers
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public int RemoveDuplicates(int[] nums)
        {
            if(nums.Length == 1)
                return 1;
            int left = 0, right = 1;
            while(right < nums.Length)
            {
                if(nums[left] == nums[right])
                    right++;
                else
                {
                    nums[left + 1] = nums[right];
                    left++;
                    right++;
                }
            }
            return left + 1;
        }
    }
}
