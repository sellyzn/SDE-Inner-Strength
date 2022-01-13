using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverII
{
    public class SortIntegersII
    {
        public void SortIntegersIISollution(int[] nums)
        {
            QuickSort(nums, 0, nums.Length);
        }
        public void QuickSort(int[] nums, int left, int right)
        {
            if (left >= right)
                return;
            int l = left, r = right + 1;
            int pivot = nums[left];
            while(true)
            {
                while (++l <= right && nums[l] < pivot) ;
                while (--r >= left && nums[r] > pivot) ;
                if(l <= r)
                {
                    int tmp = nums[l];
                    nums[l] = nums[r];
                    nums[r] = tmp;
                }
                else
                {
                    break;
                }
            }
            nums[left] = nums[r];
            nums[r] = pivot;
            QuickSort(nums, left, r);
            QuickSort(nums, r + 1, right);
        }
        
    }
}
