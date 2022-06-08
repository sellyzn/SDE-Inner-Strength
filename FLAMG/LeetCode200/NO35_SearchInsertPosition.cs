using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class NO35_SearchInsertPosition
    {
        /// <summary>
        /// Binary Search
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        /// T: O(log(n))
        /// S: O(1)
        public int SearchInsert(int[] nums, int target)
        {
            //Binary Search
            int left = 0, right = nums.Length - 1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                    left = mid + 1;
                else if(nums[mid] > target)
                    right = mid - 1;
            }
            return left;
        }
    }
}
