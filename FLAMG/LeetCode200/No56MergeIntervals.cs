using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No56MergeIntervals
    {
        /// <summary>
        /// Sort
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        /// T: O(nlogn), n为区间的数量，排序+一次线性扫描，所以主要时间开销是排序的O(nlogn)
        /// S: O(nlogn)， 排序所需要的空间复杂度O(nlogn)
        public int[][] Merge(int[][] intervals)
        {
            var result = new List<int[]>();
            if(intervals == null)
                return result.ToArray();
            intervals = intervals.OrderBy(x => x[0]).ToArray();

            var left = intervals[0][0];
            var right = intervals[0][1];
            foreach (var interval in intervals)
            {
                if(interval[0] > right)
                {
                    result.Add(new int[] { left, right });
                    left = interval[0];
                    right = interval[1];
                }
                else
                {
                    left = Math.Min(left, interval[0]);
                    right = Math.Max(right, interval[1]);
                }
            }
            result.Add(new int[] {left, right});
            return result.ToArray();
        }
    }
}
