using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No153_FindMinimumInRotatedSortedArray
    {
        /// <summary>
        /// Binary Search, Two Pointers
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {
            if(nums.Length == 1)
                return nums[0];
            int left = 0, right = nums.Length - 1;
            if (nums[right] > nums[left])
                return nums[left];
            while(left <= right)
            {
                int mid = left + (right - left) / 2;                
                if (nums[mid] > nums[mid + 1])
                    return nums[mid + 1];
                if (nums[mid - 1] > nums[mid])
                    return nums[mid];
                if (nums[mid] > nums[0])
                    left = mid + 1;
                else
                    right = mid - 1;                
            }
            return -1;
        }
        public int FindMin1(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            int index = 0;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < nums[right])
                    right = mid;
                else
                    left = mid + 1;
            }
            return nums[right];
        }
    }
}
