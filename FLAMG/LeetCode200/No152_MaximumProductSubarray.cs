using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No152_MaximumProductSubarray
    {
        /// <summary>
        /// DP
        /// dp[i]： 表示以第i个元素结尾的乘积最大子数组的乘积
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public int MaxProduct(int[] nums)
        {
            if(nums == null || nums.Length == 0)
                return 0;
            int length = nums.Length;
            var maxProduct = new int[length];
            var minProduct = new int[length];
            maxProduct[0] = nums[0];
            for(int i = 1; i < length; i++)
            {
                maxProduct[i] = Math.Max(maxProduct[i - 1] * nums[i], Math.Max(nums[i], minProduct[i - 1] * nums[i]));
                minProduct[i] = Math.Min(minProduct[i - 1] * nums[i], Math.Min(nums[i], maxProduct[i - 1] * nums[i]));
            }
            var ans = maxProduct[0];
            for(int i = 1; i < length; i++)
            {
                ans = Math.Max(ans, maxProduct[i]);
            }
            return ans;
        }

        // 优化空间
        public int MaxProduct_SO(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int length = nums.Length;
            int maxProduct = nums[0], minProduct = nums[0], ans = nums[0];
            for(int i = 1; i < length; i++)
            {
                int mx = maxProduct, mn = minProduct;
                maxProduct = Math.Max(mx * nums[i], Math.Max(nums[i], mn * nums[i]));
                minProduct = Math.Min(mn * nums[i], Math.Min(nums[i], mx * nums[i]));
                ans = Math.Max(ans, maxProduct);
            }
            return ans;
        }
    }
}
