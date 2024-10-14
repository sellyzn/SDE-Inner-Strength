using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.TwoPointersPorblems
{
    internal class P11_ContainerWithMostWater
    {
        /*
        1. 初始化： 双指针 i, j 分列水槽左右两端；
        2. 循环收窄： 直至双指针相遇时跳出；
           a. 更新面积最大值 res ；
           b. 选定两板高度中的短板，向中间收窄一格；
        3. 返回值： 返回面积最大值 res 即可；

        时间：O(n)
        空间：O(1)
         */
        public int MaxArea(int[] height)
        {
            if (height == null || height.Length == 0)
            {
                return 0;
            }
            int left = 0, right = height.Length - 1;
            var ans = 0;
            while (left < right)
            {
                ans = height[left] < height[right] ? Math.Max(ans, (right - left) * height[left++]) : Math.Max(ans, (right - left) * height[right--]);
            }
            return ans;
        }
    }
}
