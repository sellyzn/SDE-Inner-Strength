using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverIII
{
    public class FindMinimumInRotatedSortedArray
    {
        //element unique
        public int FindMin(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            int index = 0;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < nums[right])
                    right = mid;
                else
                    left = mid + 1;
            }
            return nums[right];
        }
        //contain duplicates
        public int FinMinII(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {                
                int mid = left + (right - left) / 2;
                if (nums[mid] > nums[right])
                    left = mid + 1;
                else if (nums[mid] < nums[right])
                    right = mid;
                else
                    right = right - 1;
            }
            return nums[left];
        }
    }
}
