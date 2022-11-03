using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.BinarySearch
{
    internal class FindTheSmallestDivisorGivenAThreshold
    {
        public int SmallestDivisor(int[] nums, int threshold)
        {
            int left = 1, right = nums.Max();
            int ans = 1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                int sum = GetSum(nums, mid);
                if(sum <= threshold)
                {
                    ans = sum;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return ans;
        }
        public int GetSum(int[] nums, int div)
        {
            int sum = 0;
            foreach (var num in nums)
            {
                sum += (num + div - 1) / div;
            }
            return sum;
        }
    }
}
