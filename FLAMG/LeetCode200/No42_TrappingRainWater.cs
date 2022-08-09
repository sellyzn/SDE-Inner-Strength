using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No42_TrappingRainWater
    {
        /// <summary>
        /// 对于位置i，能装下多少水？
        ///                # 左边最高的柱子      # 右边最高的主子
        /// water[i] = min(max(height[0...i]), max(height[i..end])) - height[i]
        /// </summary>


        /// <summary>
        /// 
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        /// T: O(N^2)
        /// S: O(1)
        public int Trap_BruteForce(int[] height)
        {
            if(height == null || height.Length == 0)
                return 0;
            int n = height.Length;
            int res = 0;
            for(int i = 1; i < n - 1; i++)
            {
                int lmax = 0, rmax = 0;
                // 找右边最高的柱子
                for(int j = i; j < n; j++)
                {
                    rmax = Math.Max(rmax, height[j]);
                }
                // 找左边最高的柱子
                for(int j = i; j >= 0; j--)
                {
                    lmax = Math.Max(lmax, height[j]);
                }
                res += Math.Min(lmax, rmax) - height[i];
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        ///
        public int Trap_Memo(int[] height)
        {
            if(height == null || height.Length == 0)
                return 0;
            int n = height.Length;
            int res = 0;
            var lmax = new int[n];
            var rmax = new int[n];
            lmax[0] = height[0];
            rmax[n - 1] = height[n - 1];
            for(int i = 1; i < n; i++)
            {
                lmax[i] = Math.Max(height[i], lmax[i - 1]);
            }
            for(int i = n - 2; i >= 0; i--)
            {
                rmax[i] = Math.Max(height[i], rmax[i + 1]);
            }
            for(int i = 1; i < n - 1; i++)
            {
                res += Math.Min(lmax[i], rmax[i]) - height[i];
            }
            return res;
        }


        public int Trap_TwoPointers(int[] height)
        {
            int res = 0;
            int left = 0, right = height.Length - 1;
            int lmax = 0, rmax = 0;
            while(left < right)
            {
                lmax = Math.Max(lmax, height[left]);
                rmax = Math.Max(rmax, height[right]);
                if(height[left] < height[right])
                {
                    res += lmax - height[left];
                    left++;
                }
                else
                {
                    res += rmax - height[right];
                    right--;
                }
            }
            return res;
        }
    }
}
