using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No55_JumpGame
    {
        /// <summary>
        /// Greedy
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(n)
        /// S: O(1)
        public bool CanJump(int[] nums)
        {
            int n = nums.Length;
            int rightMost = 0;
            for(int i = 0; i < n; i++)
            {
                if(i <= rightMost)
                {
                    rightMost = Math.Max(rightMost, i + nums[i]);
                    if (rightMost >= n - 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanJump_BT(int[] nums)
        {
            return Backtrack(nums, 0);
        }
        public bool Backtrack(int[] nums, int start)
        {
            if (start == nums.Length - 1)
                return true;
            int furthestJump = Math.Min(start + nums[start], nums.Length - 1);
            for(int i = start + 1; i <= furthestJump; i++)
            {
                if (Backtrack(nums, i))
                    return true;
            }
            return false;
        }
    }
}
