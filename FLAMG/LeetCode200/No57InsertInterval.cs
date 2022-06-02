using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No57InsertInterval
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="intervals"></param>
        /// <param name="newInterval"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var left = newInterval[0];
            var right = newInterval[1];
            var result = new List<int[]>();
            var flag = false;
            foreach (var interval in intervals)
            {
                if(interval[0]> right)
                {
                    if (!flag)
                    {
                        result.Add(new int[] { left, right });
                        flag = true;
                    }
                    result.Add(interval);
                }else if(interval[1] < left)
                {
                    result.Add(interval);
                }
                else
                {
                    left =Math.Min(left, interval[0]);
                    right = Math.Max(right, interval[1]);
                }
            }
            if (!flag)
            {
                result.Add(new int[] { left, right });
            }
            return result.ToArray();
        }
    }
}
