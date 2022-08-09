using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class FindTheSmallestDivisorGivenAThreshold
    {
        /// <summary>
        /// Binary Search
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        /// T: O(NlogC), C是一个常数，为二分查找的上下限之差，本体范围C不会超过10^6
        /// S: O(1)
        public int SmallestDivisor(int[] nums, int threshold)
        {
            // 除数越小，和越大
            // 左边界为1， 有边界为nums里最大的数，这样每个数除完都是最小为1
            int left = 1, right = nums.Max();
            int ans = -1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                int sum = Sum(nums, mid);
                if (sum <= threshold)
                {
                    ans = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return ans;
        }
        public int Sum(int[] nums, int div)
        {
            int sum = 0;
            foreach (var num in nums)
            {
                sum += (num + div - 1) / div;  // 向上取整  
            }
            return sum;
        }
    }
}
