using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No215_KthLargestElementInArray
    {
        /// <summary>
        /// Fast Selection
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(logN), 递归使用栈空间的空间代价的期望为O(logN)
        public int FindKthLargest(int[] nums, int k)
        {
            // fast selection
            return QuickSearch(nums, 0, nums.Length - 1, k);
        }
        public int QuickSearch(int[] nums, int left, int right, int k)
        {
            int j = Partition(nums, left, right);
            if (j == k - 1)
                return nums[j];
            return j > k - 1 ? QuickSearch(nums, left, j - 1, k) : QuickSearch(nums, j + 1, right, k);
        }
        public int Partition(int[] nums, int left, int right)
        {
            int pivot = nums[left];
            int l = left, r = right + 1;
            while (true)
            {
                while (++l <= right && nums[l] > pivot) ;
                while (--r >= left && nums[r] < pivot) ;
                if(l < r)
                {
                    var tmp = nums[l];
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
