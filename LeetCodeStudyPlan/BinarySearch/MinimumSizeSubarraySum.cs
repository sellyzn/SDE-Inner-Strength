using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.BinarySearch
{
    internal class MinimumSizeSubarraySum
    {
        public int MinSubArrayLen(int target, int[] nums)
        {
            // prefixsum
            if (nums == null || nums.Length == 0)
                return 0;
            var prefixSum = new int[nums.Length + 1];
            prefixSum[0] = 0;
            for(int i = 1; i <= nums.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
            }
            // two pointers (同向)
            var minLength = int.MaxValue;
            int left = 0, right = 0;
            while(left < prefixSum.Length && right < prefixSum.Length)
            {
                right = left;
                while (right < prefixSum.Length && prefixSum[right] - prefixSum[left] < target)
                    right++;
                if (right < prefixSum.Length)
                {
                    minLength = Math.Min(minLength, right - left);
                    left++;
                }
                else
                    break;
            }
            return minLength = minLength == int.MaxValue ? 0 : minLength;
        }
        //int solution(int X, int Y, int[] A)
        //{
        //    int N = A.length;
        //    int result = -1;
        //    int nX = 0;
        //    int nY = 0;
        //    for (int i = 0; i < N; i++)
        //    {
        //        if (A[i] == X)
        //            nX += 1;
        //        else if (A[i] == Y)
        //            nY += 1;
        //        if (nX == nY)
        //            result = i;
        //    }
        //    return result;
        //}
    }
}
