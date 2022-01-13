using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverIII
{
    public class SearchForARange
    {
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return new int[] { -1, -1 };
            if (nums[0] == nums[nums.Length - 1])
                return new int[] { 0, nums.Length - 1 };
            int start = SearchRight(nums, target - 1);
            int end = SearchRight(nums, target);
            return end > start ? new int[] { start, end} : new int[] { -1, -1 };            
        }
        public int SearchRight(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;            
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] <= target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return left;
        }
    }
}
