using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No80_RemoveDuplicatesFromSortedArrayII
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
            if(nums.Length <= 2)
                return nums.Length;
            int left = 1, right = 2;
            while(right < nums.Length)
            {
                if(nums[left] != nums[left - 1])
                {
                    nums[left + 1] = nums[right];
                    left++;
                    right++;
                }
                else
                {
                    if (nums[left] != nums[right])
                    {
                        nums[left + 1] = nums[right];
                        left++;
                        right++;
                    }
                    else
                    {
                        right++;
                    }
                }
            }
            return left + 1;
        }
    }
}
