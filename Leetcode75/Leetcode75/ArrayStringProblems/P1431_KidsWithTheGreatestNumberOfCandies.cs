using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.ArrayStringProblems
{
    internal class P1431_KidsWithTheGreatestNumberOfCandies
    {
        /*
          1. 遍历candies数组，找到最大值maxValue
          2. 遍历candies数组，比较maxValue与candies[i] + extraCandies之间的大小，确定list result加入的值是true还是false。
          time: O(n)
          space: O(n)
         */
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            // Find the max value in the candies array
            int maxValue = candies[0];
            for(int i = 1; i < candies.Length; i++)
            {
                maxValue = Math.Max(maxValue, candies[i]);
            }
            var result = new List<bool>();
            for(int i = 0; i < candies.Length; i++)
            {
                if(maxValue <= candies[i] + extraCandies)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
            }
            return result;
        }
    }
}
