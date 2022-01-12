using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverII
{
    public class KthLargestElement
    {
        // quick search
        public int KthLargestElementI(int[] nums, int k)
        {
            return QuickSearch(nums, 0, nums.Length - 1, k);
        }
        //快速搜索过程： j == k - 1时定位。
        public int QuickSearch(int[] nums, int left, int right, int k)
        {
            int j = Partition(nums, left, right);
            if (j == k - 1)
            {
                return nums[j];
            }
            return j > k - 1 ? QuickSearch(nums, left, j - 1, k) : QuickSearch(nums, j + 1, right, k);
        }
        //一次partition能确定pivot的最终位置，返回的是pivot的index
        //[left,right)， pivot = nums[left]， 将[left + 1, right]分区，分成左边 > pivot， 右边 < pivot （或者左边 < pivot， 右边 > pivot）两部分（取决升序，还是降序，找第k大，还是第k小）。
        //此时，交换pivot和nums[r]， pivot便在最终位置，r 即为其最终index
        public int Partition(int[] nums, int left, int right)
        {
            int pivot = nums[left];
            int l = left, r = right + 1;
            while (true)
            {
                while (++l <= right && nums[l] > pivot) ;
                while (--r >= left && nums[r] < pivot) ;
                if (l < r)
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
            return r;
        }
    }
}
