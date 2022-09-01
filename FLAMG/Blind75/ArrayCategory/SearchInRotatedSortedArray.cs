using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.ArrayCategory
{
    internal class SearchInRotatedSortedArray
    {
        // 33. Search in Rotated Sorted Array
        // 元素不重复
        // Binary Search
        public int Search(int[] nums, int target)
        {
            if(nums == null || nums.Length == 0)
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
                    if (nums[left] <= target & target < nums[mid])
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                else
                {
                    if (nums[mid] < target && target <= nums[right])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }
            return -1;
        }

        // 81. Search in Rotated Sorted Array II
        // 有重复元素
        // Binary Search
        // 对于数组中有重复元素的情况，二分查找时可能会有 a[l]=a[\textit{mid}]=a[r]a[l]=a[mid]=a[r]，此时无法判断区间 [l,\textit{mid}][l,mid] 和区间 [\textit{mid}+1,r][mid+1,r] 哪个是有序的。
        // 对于这种情况，我们只能将当前二分区间的左边界加一，右边界减一，然后在新区间上继续二分查找。

        public bool SearchII(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return false;
            int left = 0, right = nums.Length - 1;
            while(left <= right)
            {
                int mid = left + ((right - left) / 2);
                if (nums[mid] == target)
                    return true;
                if(nums[left] == nums[mid] && nums[mid] == nums[right])
                {
                    left++;
                    right--;
                }else if(nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid])
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                else
                {
                    if (nums[mid] < target && target <= nums[right])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }                
            }
            return false;
        }
    }
}
