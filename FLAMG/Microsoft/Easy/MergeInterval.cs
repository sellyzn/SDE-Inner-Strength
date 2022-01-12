using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace FLAMG.Microsoft.Easy
{

    //public class IntervalComparer : IComparer
    //{
    //    public int Compare(object x, object y)
    //    {
    //        int[] left = (int[])x;
    //        int[] right = (int[])y;
    //        return left[0] - right[0];

    //    }
    //}
    public class MergeInterval
    {
        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0)
                return new int[0][];

            intervals = intervals.OrderBy((x) => x[0]).ToArray();

            //Array.Sort(intervals, new IntervalComparer());
            //Array.Sort(intervals, new Comparator<int[]>()
            //{
            //    public int Compare(int[] interval1, int[] interval2)
            //{
            //    return interval1[0] - interval2[0];
            //}
            //});

            


            var merged = new List<int[]>();
            for (int i = 0; i < intervals.Length; i++)
            {
                int left = intervals[i][0], right = intervals[i][1];
                if(merged.Count == 0 || merged[merged.Count - 1][1] < left)
                {
                    merged.Add(new int[] { left, right });
                }
                else
                {
                    merged[merged.Count - 1][1] = Math.Max(merged[merged.Count - 1][1], right);
                }
            }
            return merged.ToArray();
        }
    }
}
