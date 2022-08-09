using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class MaximumProductSubarray
    {
        /*
         nums: [2] => 2
         */
        public int MaxProduct(int[] nums)
        {
            var maxP = new int[nums.Length];
            var minP = new int[nums.Length];
            maxP[0] = nums[0];
            minP[0] = nums[0];
            for(int i = 1; i < nums.Length; i++)
            {
                maxP[i] = Math.Max(maxP[i - 1] * nums[i], Math.Max(minP[i - 1] * nums[i], nums[i]));
                minP[i] = Math.Max(maxP[i - 1] * nums[i], Math.Min(minP[i - 1] * nums[i], nums[i]));                
            }
            var maxProduct = maxP[0];
            foreach (var num in maxP)
            {
                maxProduct = Math.Max(maxProduct, num);
            }
            return maxProduct;
        }
    }
}
