using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.HighestFrequency
{
    internal class InsertIntervals
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if (newInterval == null)
                return intervals;
            if (intervals.Length == 0)
                return new int[][] { newInterval };

            var result = new List<int[]>();
            int left = newInterval[0], right = newInterval[1], length = intervals.Length, i = 0;
            while (i < length && intervals[i][1] < left)
                result.Add(intervals[i++]);
            while(i < length && intervals[i][0] <= right)
            {
                left = Math.Min(left, intervals[i][0]);
                right = Math.Min(right, intervals[i][1]);
            }
            result.Add(new int[] { left, right });
            while (i < length)
                result.Add(intervals[i++]);
            return result.ToArray();

            var pool = new HashSet<int>();
            pool.iterator,
        }
    }
}
