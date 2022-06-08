using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No16_ThreeSumClosest
    {
        /// <summary>
        /// Sorting + Two Pointers
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        /// T: O(N^2)
        /// S: O(1)
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int ans = nums[0] + nums[1] + nums[2];
            for(int i = 0; i < nums.Length; i++)
            {
                int start = i + 1, end = nums.Length - 1;
                while(start < end)
                {
                    int sum = nums[start] + nums[end] + nums[i];
                    if (Math.Abs(target - sum) < Math.Abs(target - ans))
                        ans = sum;
                    if (sum > target)
                        end--;
                    else if (sum < target)
                        start++;
                    else
                        return ans;
                }
            }
            return ans;
        }
    }
}
