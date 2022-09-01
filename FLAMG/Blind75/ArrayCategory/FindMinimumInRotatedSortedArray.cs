using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.ArrayCategory
{
    internal class FindMinimumInRotatedSortedArray
    {
        // 153. Find Minimum in Rotated Sorted Array
        // 元素不重复
        // Two Pointers + Binary Search
        public int FindMin(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < nums[right])
                    right = mid;
                else
                    left = mid + 1;
            }
            return nums[left];
        }

        // 154. Find Minimum in Rotated Sorted Array II
        // 有重复元素， duplicates
        // Two Pointers + Binary Search
        /*
        nums[mid] == nums[right]时（元素重复，难以判断分界点i指针区间）：
        例如 [1, 0, 1, 1, 1] 和 [1, 1, 1, 0, 1] ，在 left = 0, right = 4, mid = 2 时，无法判断 mid在哪个排序数组中。
        我们采用 right = right - 1 解决此问题

        此操作不会使数组越界：因为迭代条件保证了 right > left >= 0；
        此操作不会使最小值丢失：假设 nums[right]nums[right] 是最小值，有两种情况：
            若 nums[right] 是唯一最小值：那就不可能满足判断条件 nums[mid] == nums[right]，因为 mid < right（left != right 且 mid = (left + right) // 2 向下取整）；
            若 nums[right] 不是唯一最小值，由于 mid < right 而 nums[mid] == nums[right]，即还有最小值存在于 [left, right - 1] 区间，因此不会丢失最小值。

         */
        public int FindMinII(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            while(left < right)
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
