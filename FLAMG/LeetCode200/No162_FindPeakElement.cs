using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No162_FindPeakElement
    {
        
        /// <summary>
        /// Linear scan
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(n)
        /// S: O(1)
        public int FindPeakElement(int[] nums)
        {
            for(int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                    return i;
            }
            return nums.Length - 1;
        }


        /// <summary>
        /// Iterative Binary Search
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(log2(n))
        /// S: O(1)
        public int FindPeakElement1(int[] nums)
        {            
            int left = 0, right = nums.Length - 1;
            while(left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > nums[mid + 1])
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }
    }
}
