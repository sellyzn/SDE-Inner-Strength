using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No11_ContainerWithMostWater
    {
        /// <summary>
        /// Two pointers
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        /// 
        /// Brute Force:
        /// T: O(n^2)
        /// S: O(1)
        /// Two Pointers:
        /// T: O(n)
        /// S: O(1)
        public int MaxArea(int[] height)
        {
            int n = height.Length;
            int maxArea = 0;
            for (int i = 0; i < n - 1; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    var curArea = Math.Min(height[j], height[i]) * (j - i);
                    maxArea = Math.Max(maxArea, curArea);
                }
            }
            return maxArea;
        }
        public int MaxArea_TP(int[] height)
        {
            int maxArea = 0;
            int left = 0;
            int right = height.Length - 1;
            while(left < right)
            {
                int width = right - left;
                var curArea = Math.Min(height[left], height[right]) * (right - left);
                maxArea = Math.Max(maxArea, curArea);
                if (height[left] <= height[right])
                    left++;
                else
                    right--;
            }
            return maxArea;
        }
    }
}
