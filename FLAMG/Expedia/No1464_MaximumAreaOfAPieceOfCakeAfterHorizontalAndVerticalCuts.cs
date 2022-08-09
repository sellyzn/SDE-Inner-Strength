using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No1464_MaximumAreaOfAPieceOfCakeAfterHorizontalAndVerticalCuts
    {
        /// <summary>
        /// Sort
        /// 结果太大时，取模 % (1000000007)
        /// long类型，相乘会int溢出
        /// </summary>
        /// <param name="h"></param>
        /// <param name="w"></param>
        /// <param name="horizontalCuts"></param>
        /// <param name="verticalCuts"></param>
        /// <returns></returns>
        /// T: O(MlogM + NlogN)
        /// S: O(1)
        public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            Array.Sort(horizontalCuts);
            Array.Sort(verticalCuts);
            int n = horizontalCuts.Length;
            int m = verticalCuts.Length;

            long maxHeight = Math.Max(horizontalCuts[0], h - horizontalCuts[n - 1]);

            for (int i = 1; i < horizontalCuts.Length; i++)
            {
                maxHeight = Math.Max(maxHeight, horizontalCuts[i] - horizontalCuts[i - 1]);
            }

            long maxWidth = Math.Max(verticalCuts[0], w - verticalCuts[m - 1]);

            for (int i = 1; i < verticalCuts.Length; i++)
            {
                maxWidth = Math.Max(maxWidth, verticalCuts[i] - verticalCuts[i - 1]);
            }

            return (int)((maxHeight * maxWidth) % (1000000007));
        }
    }
}
