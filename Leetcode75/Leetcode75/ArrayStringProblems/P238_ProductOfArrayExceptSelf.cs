using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.ArrayStringProblems
{
    internal class P238_ProductOfArrayExceptSelf
    {
        /*
        用两个数组A, B。A[i]代表num的前i个数的乘积，B[i]代表nums[i]->nums[n-1]的乘积
        res[i] = A[i-1] * B[i + 1]，注意边界条件，i == 0, i == nums.Length - 1的情况单独考虑。
        time: O(n)
        space: O(n)
         */
        public int[] ProductExceptSelf(int[] nums)
        {
            var prefixProduct = new int[nums.Length];
            var suffixProduct = new int[nums.Length];
            var result = new int[nums.Length];
            prefixProduct[0] = nums[0];
            suffixProduct[0] = nums[nums.Length - 1];
            for(int i = 1; i < nums.Length; i++)
            {
                prefixProduct[i] = prefixProduct[i - 1] * nums[i];
            }
            for(int i = nums.Length - 2; i >= 0; i--)
            {
                suffixProduct[i] = suffixProduct[i + 1] * nums[i];
            }
            for(int i = 0; i < nums.Length; i++)
            {
                if(i == 0)
                {
                    result[i] = suffixProduct[i + 1];
                }else if(i == nums.Length - 1)
                {
                    result[i] = prefixProduct[i - 1];
                }
                else
                {
                    result[i] = prefixProduct[i - 1] * suffixProduct[i + 1];
                }
            }
            return result;
        }
    }
}
