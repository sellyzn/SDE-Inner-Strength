using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.ArrayCategory
{
    internal class ProductOfArrayExceptSelf
    {
        // 238. Product of Array Except Self
        /*
         nums: 1 2 3 4
         pre: 1 2 6 24
         sub: 24 24 12 4
         result: 24, 1*12, 2*4, 6
         */
        /// <summary>
        /// 前缀积，后缀积
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public int[] ProductExceptSelf(int[] nums)
        {
            if(nums == null || nums.Length == 0)
                return new int[0];
            var pre = new int[nums.Length];
            var sub = new int[nums.Length];
            var result = new int[nums.Length];
            pre[0] = nums[0];
            sub[nums.Length - 1] = nums[nums.Length - 1];
            for(int i = 1; i < nums.Length; i++)
            {
                pre[i] = pre[i - 1] * nums[i];
            }
            for(int i = nums.Length - 2; i >= 0; i--)
            {
                sub[i] = sub[i + 1] * nums[i];
            }
            result[0] = sub[1];
            result[nums.Length - 1] = pre[nums.Length - 2];
            for(int i = 1; i < nums.Length - 1; i++)
            {
                result[i] = pre[i - 1] * sub[i + 1];
            }
            return result;
        }

        /*
                i
        nums: 1 2 3 4
        p:    24
        res:  1 2 6  24
        q:    12
        res:    2*12   6*4   24

         */
        /// <summary>
        /// 优化空间：
        /// answer复用代替前缀之积L
        /// 用整形变量R代替后缀之积R
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S; O(1)
        public int[] ProductExceptSelf1(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return new int[0];
            // answer[i]表示索引i左侧的所有元素乘积
            var answer = new int[nums.Length];
            answer[0] = 1;
            for(int i = 1; i < nums.Length; i++)
            {
                answer[i] = answer[i - 1] * nums[i - 1];
            }
            int R = 1;
            for(int i = nums.Length - 1; i >= 0; i--)
            {
                //对于索引i，左边的乘积为answer[i]，右边的乘积为R
                answer[i] = answer[i] * R;
                // R需要包含右边所有的乘积，所以计算下一个结果时需要将当前值乘到R上，更新R值
                R *= nums[i];
            }
            return answer;
        }

        // 152. Maximum Product Subarray
        // DP
        // T: O(N)
        // S: O(N) --> O(1)优化
        public int MaxProduct(int[] nums)
        {
            if(nums == null || nums.Length == 0)
                return 0;
            int length = nums.Length;
            // 以第i个元素结尾的乘积最大子数组的乘积
            var maxProduct = new int[length];
            // 以第i个元素结尾的乘积最小子数组的乘积
            var minProduct = new int[length];
            maxProduct[0] = nums[0];
            minProduct[0] = nums[0];
            for(int i = 1;i < length; i++)
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


        // 42. Trapping Rain Water
        // 对于下标i，下雨后能到达的最大高度等于下标i两边的最大高度的最小值，下标i处能接的雨水量等于下标i处的水能到达的最大高度减去height[i]。
        // lmax[i]: 下标i及其左边的位置中，height的最大高度
        // rmax[i]: 下标i及其右边的位置中，height的最大高度

        
        public int Trap(int[] height)
        {
            if (height == null || height.Length == 0)
                return 0;
            var lmax = new int[height.Length];
            var rmax = new int[height.Length];
            lmax[0] = height[0];
            rmax[height.Length - 1] = height[height.Length - 1];
            for(int i = 1; i < height.Length; i++)
            {
                lmax[i] = Math.Max(lmax[i - 1], height[i]);
            }
            for(int i = height.Length - 2; i >= 0; i--)
            {
                rmax[i] = Math.Max(rmax[i + 1], height[i]);
            }

            var ans = 0;
            for(int i = 0; i < height.Length; i++)
            {
                ans += Math.Min(lmax[i], rmax[i]) - height[i];
            }
            return ans;
        }

        // 优化空间复杂度
        // 双指针
        // 用height[left]和height[right]的值更新lmax和rmax的值
        public int TrapOp(int[] height)
        {
            if (height == null || height.Length == 0)
                return 0;
            int left = 0, right = height.Length - 1;
            int lmax = 0, rmax = 0;
            int ans = 0;
            while(left < right)
            {
                lmax = Math.Max(lmax, height[left]);
                rmax = Math.Max(rmax, height[right]);
                if(height[left] < height[right])
                {
                    ans += lmax - height[left];
                    left++;
                }
                else
                {
                    ans += rmax - height[right];
                    right--;
                }
            }
            return ans;
        }

        
    }
}
