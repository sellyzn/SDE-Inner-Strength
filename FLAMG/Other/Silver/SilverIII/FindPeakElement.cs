using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverIII
{
    public class FindPeakElement
    {
        public int FindPeak(int[] nums)
        {
            //int index = 0;
            //while (index < nums.Length - 1 && nums[index] > nums[index + 1])
            //    index++;
            //while (index < nums.Length - 1 && nums[index] < nums[index + 1])
            //    index++;
            //return index;
            if (nums.Length == 1)
                return 0;
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid - 1] < nums[mid] && nums[mid] > nums[mid + 1])
                    return mid;
                else if (nums[mid] < nums[mid + 1])
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            if (nums[left] >= nums[right])
                return left;
            else
                return right;
        }  
    }
}
