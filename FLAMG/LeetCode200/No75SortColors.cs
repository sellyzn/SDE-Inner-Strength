using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No75SortColors
    {
        /// <summary>
        /// 三个指针： 双指针分别标记0和2的位置，从下标0，n - 1开始。另一个指针遍历数组。
        /// </summary>
        /// <param name="nums"></param>
        /// T: O(N)
        /// S: O(1)
        public void SortColors(int[] nums)
        {            
            int left = 0, right = nums.Length - 1;
            int cur = 0;
            while (cur < nums.Length)
            {
                if (nums[cur] == 0)
                {
                    Swap(nums, cur, left);
                    left++;
                    cur++;      //此处要右cur++，因为cur是从左边index为0的位置遍历过来的，所以cur左边的数为0或1，不可能为2.
                }
                else if (nums[cur] == 2)
                {
                    Swap(nums, cur, right);
                    right--;
                }
                else
                {
                    cur++;
                }
            }
        }
        public void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
