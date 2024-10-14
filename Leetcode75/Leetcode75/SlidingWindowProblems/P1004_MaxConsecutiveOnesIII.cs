using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.SlidingWindowProblems
{
    internal class P1004_MaxConsecutiveOnesIII
    {
        public int LongestOnes(int[] nums, int k)
        {
            var count = 0;
            var maxCount = 0;
            int left = 0, right = 0;
            while(right < nums.Length)
            {
                if(k > 0)
                {
                    if (nums[right] == 1)
                    {
                        count++;
                        right++;
                    }
                    else if (nums[right] == 0)
                    {
                        count++;
                        k--;
                        right++;
                    }
                }
                else
                {
                    if (nums[left] == 1)
                    {
                        count--;
                        left++;
                    }
                    else if (nums[left] == 0)
                    {
                        count--;
                        left++;
                        k++;
                    }
                }
                maxCount = Math.Max (maxCount, count);
            }
            return maxCount;
        }
    }
}
