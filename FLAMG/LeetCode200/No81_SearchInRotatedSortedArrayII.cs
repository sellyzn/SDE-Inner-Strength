using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No81_SearchInRotatedSortedArrayII
    {
        /// <summary>
        /// Binary Search
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        /// T: O(N) worst case (happens when all the elements are the same and we search for some different element), O(logN)best case, where N is the length if the input array.
        /// S: O(1)
        public bool Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return false;
            
            int left = 0, right = nums.Length - 1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return true;
                if(nums[mid] == nums[left] && nums[mid] == nums[right])
                {
                    left++;
                    right--;
                }else if(nums[left] <= nums[mid])       //nums[left] <= nums[mid]
                {
                    if(nums[left] <= target && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    if(nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            return false;
        }
    }
}
