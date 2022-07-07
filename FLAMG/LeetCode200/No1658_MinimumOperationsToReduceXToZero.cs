using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No1658_MinimumOperationsToReduceXToZero
    {
        public int MinOperations(int[] nums, int x)
        {
            int totalSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                totalSum += nums[i];
            }
            int target = totalSum - x;
            int left = 0;
            int currentSum = 0;
            int maxLength = -1;
            for (int right = 0; right < nums.Length; right++)
            {
                currentSum += nums[right];
                while (currentSum > totalSum - x && left <= right)
                {
                    currentSum -= nums[left];
                    left++;
                }
                if (currentSum == totalSum - x)
                {
                    maxLength = Math.Max(maxLength, right - left + 1);
                }
            }
            return maxLength != -1 ? nums.Length - maxLength : -1;
        }
    }
}
