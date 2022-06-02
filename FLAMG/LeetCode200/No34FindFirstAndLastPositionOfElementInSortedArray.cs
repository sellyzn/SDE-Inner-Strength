using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No34FindFirstAndLastPositionOfElementInSortedArray
    {
        /// <summary>
        /// find the left/right edge
        /// LeftEdge(target + 1) - LeftEdge(target)
        /// RightEdge(target) - RightEdge(target - 1)
        /// 
        /// [LeftEdge(target), LeftEdge(target + 1) - 1]
        /// [RightEdge(target - 1) + 1, RightEdge(target)]
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return new int[] { -1, -1 };
            int leftIndex = FindLeftEdge(nums, target);
            // 数组中所有的数都比target小，或者没有找到与target相等的数
            // [1, 2, 3, 3, 4, 5]  target = 8
            // [1, 2, 3, 5, 7, 8]  target = 4
            // [1, 2, 3, 5, 7, 8]  target = 0
            if (leftIndex >= nums.Length || nums[leftIndex] != target)
                return new int[] { -1, -1 };
            int rightIndex = FindLeftEdge(nums, target + 1);            
            return new int[] {leftIndex, rightIndex - 1};            
        }
        //Find the first index, which nums[i] >= target
        //第一个大于等于target的数的下标，找不到则返回数组长度
        public int FindLeftEdge(int[] nums, int target)
        {  
            int left = 0, right = nums.Length - 1;
            
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if(nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if(nums[mid] >= target)
                {
                    right = mid - 1;                 
                }                               
            }
            return left;
        }

        // nums -> non-decreasing order
        // nums[0] > target -> -1
        // nums[n - 1] < target -> -1
        // left = 0, right = n - 1
    }
}
