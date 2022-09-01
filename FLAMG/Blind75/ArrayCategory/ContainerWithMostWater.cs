using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.ArrayCategory
{
    internal class ContainerWithMostWater
    {
        // 11. Container With Most Water
        /*
        设两指针 i , j ，指向的水槽板高度分别为 h[i] , h[j] ，此状态下水槽面积为 S(i, j) 。由于可容纳水的高度由两板中的 短板 决定，因此可得如下 面积公式：
               S(i, j) = min(h[i], h[j]) × (j - i)

        在每个状态下，无论长板或短板向中间收窄一格，都会导致水槽 底边宽度 -1 变短：
        若向内 移动短板 ，水槽的短板 min(h[i], h[j])min(h[i],h[j]) 可能变大，因此下个水槽的面积 可能增大 。
        若向内 移动长板 ，水槽的短板 min(h[i], h[j])min(h[i],h[j])​ 不变或变小，因此下个水槽的面积 一定变小 。
        因此，初始化双指针分列水槽左右两端，循环每轮将短板向内移动一格，并更新面积最大值，直到两指针相遇时跳出；即可获得最大面积。   
         */

        // 感觉这个移动有点博弈论的味了，每次都移动自己最差的一边，虽然可能变得更差，但是总比不动（或者减小）强，动最差的部分可能找到更好的结果，但是动另一边总会更差或者不变，兄弟们，这不是题，这是人生，逃离舒适圈！！
        public int MaxArea(int[] height)
        {
            if (height == null || height.Length == 0)
                return 0;
            int left = 0, right = height.Length - 1;
            var ans = 0;
            while (left < right)
            {
                ans = height[left] < height[right] ? Math.Max(ans, (right - left) * height[left++]) : Math.Max(ans, (right - left) * height[right--]);
            }
            return ans;
        }

        // 407. Trapping Rain Water II
        public int TrapRainWater(int[][] heightMap)
        {

        }
    }
}
