using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No167_TwoSumIIInputArrayIsSorted
    {
        /// <summary>
        /// Two pointers
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public int[] TwoSum(int[] numbers, int target)
        {
            var res = new int[2];
            if (numbers == null || numbers.Length < 2)
                return new int[0];
            int left = 0, right = numbers.Length - 1;
            while(left < right)
            {
                int sum = numbers[left] + numbers[right];
                if(sum == target)
                {
                    res[0] = left;
                    res[1] = right;
                    break;
                }else if(sum > target)
                {
                    right--;
                }else if(sum < target)
                {
                    left++;
                }              
            }
            return res;
        }
    }
}
