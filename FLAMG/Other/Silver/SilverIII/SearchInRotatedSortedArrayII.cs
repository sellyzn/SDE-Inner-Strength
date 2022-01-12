using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverIII
{
    public class SearchInRotatedSortedArrayII
    {
        //对非降序数组nums（元素不唯一）进行旋转，查找数组中是否存在目标元素target。若存在，返回true，否则返回false。
        //Exist duplicate elements
        public bool SearchII(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return false;
            if (nums.Length == 1)
                return nums[0] == target ? true : false;
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return true;
                if (nums[left] == nums[mid] && nums[mid] == nums[right])
                {
                    left++;
                    right--;
                }
                else if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid])
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
                    if (nums[mid] < target && target <= nums[right])
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

        //对非降序数组nums（元素唯一不重复）进行旋转，查找数组中是否存在目标元素target。若存在则返回其index位置，否则返回-1.
        //elements unique
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;
            if (nums.Length == 1)
                return nums[0] == target ? 0 : -1;
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid])
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
                    if (nums[mid] < target && target <= nums[right])
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

    }
}
