using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Microsoft.Medium
{
    public class SearchInRotatedSortedArray
    {
        ////////////////////////////////////
        // Search in Rotated Sorted Array //
        ////////////////////////////////////
        //
        //Binary Search
        //
        // Divide array to two parts: [left,mid] and [mid + 1, right]
        // Judge which part is sorted.
        // 

        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;
            if (nums.Length == 1)
                return nums[0] == target ? 0 : -1;
            int left = 0, right = nums.Length - 1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                if(nums[left] <= nums[mid])
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
            return -1;
        }


        ///////////////////////////////////////
        // Search in Rotated Sorted Array II //
        ///////////////////////////////////////
        //
        // Binary Search
        // special case: nums[left] = nums[mid] = nums[right]


        public bool SearchII(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return false;
            if (nums.Length == 1)
                return nums[0] == target ? true : false;
            int left = 0, right = nums.Length - 1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return true;
                if(nums[left] == nums[mid] && nums[mid] == nums[right])
                {
                    left++;
                    right--;
                }
                else if(nums[left] <= nums[mid])    //nums[left] <= nums[mid], not nums[left] < nums[mid]. Because 
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

        //////////////////////////////////////////
        // Find Minimum in Rotated Sorted Array //
        //////////////////////////////////////////
        //
        // Binary Search
        //

        public int FindMin(int[] nums)
        {
            int minValue = nums[0];
            int left = 0, right = nums.Length - 1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[left] <= nums[right])
                {
                    minValue = nums[left];
                    return minValue;
                }
                else if(nums[left] <= nums[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    left++;
                }
            }
            return minValue;
        }
    }
}
