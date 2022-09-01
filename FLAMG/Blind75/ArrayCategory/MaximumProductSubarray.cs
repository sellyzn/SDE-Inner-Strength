using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.ArrayCategory
{
    internal class MaximumProductSubarray
    {
        // 152. Maximum Product Subarray
        // DP
        // T: O(N)
        // S: O(N) --> O(1)优化
        public int MaxProduct(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int length = nums.Length;
            // 以第i个元素结尾的乘积最大子数组的乘积
            var maxProduct = new int[length];
            // 以第i个元素结尾的乘积最小子数组的乘积
            var minProduct = new int[length];
            maxProduct[0] = nums[0];
            minProduct[0] = nums[0];
            for (int i = 1; i < length; i++)
            {
                maxProduct[i] = Math.Max(maxProduct[i - 1] * nums[i], Math.Max(nums[i], minProduct[i - 1] * nums[i]));
                minProduct[i] = Math.Min(minProduct[i - 1] * nums[i], Math.Min(nums[i], maxProduct[i - 1] * nums[i]));
            }
            var ans = maxProduct[0];
            for (int i = 1; i < length; i++)
            {
                ans = Math.Max(ans, maxProduct[i]);
            }
            return ans;
        }


        public int MaxProductO1(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int length = nums.Length;
            int maxProduct = nums[0], minProduct = nums[0], ans = nums[0];
            for (int i = 1; i < length; i++)
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
