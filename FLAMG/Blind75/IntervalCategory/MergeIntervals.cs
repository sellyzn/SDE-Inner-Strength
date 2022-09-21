using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.IntervalCategory
{
    internal class MergeIntervals
    {
        // 56. Merge Intervals
        public int[][] Merge(int[][] intervals)
        {
            var result = new List<int[]>();
            if (result.Count == 0)
                return result.ToArray();
            intervals = intervals.OrderBy(x => x[0]).ToArray();
            var left = intervals[0][0];
            var right = intervals[0][1];

            foreach (var interval in intervals)
            {
                if(interval[0] > right)
                {
                    result.Add(new int[] {left, right});
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
