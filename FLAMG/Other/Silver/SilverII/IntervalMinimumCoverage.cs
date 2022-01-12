using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLAMG.Other.Silver.SilverII
{
    public class IntervalMinimumCoverage
    {
        public int GetAns(int[][] intervals)
        {            
            intervals = intervals.OrderBy(x => x[1]).ToArray();

            //Collections.Sort(interval, new Comparator<int[]>()
            //{
            //public int Compare(int[] interval1, int[] interval2)
            //{
            //    if (interval1[1] == interval2[1])
            //    {
            //        return interval1[0] - interval1[0];
            //    }
            //    return interval1[1] - interval2[1];
            //}
            //});


            //var merged = new List<int[]>();
            //for(int i = 0; i < intervals.Length; i++)
            //{
            //    int left = intervals[i][0], right = intervals[i][1];
            //    if (merged.Count == 0 || merged[merged.Count - 1][1] < left)
            //    {
            //        merged.Add(new int[] { left, right });
            //    }
            //    else
            //    {
            //        merged[merged.Count - 1][1] = Math.Max(merged[merged.Count - 1][1], right);
            //    }
            //}
            //return merged.Count;
            int n = intervals.Length;
            int answer = 0, index = -1;
            for (int i = 0; i < n; i++)
            {
                if (intervals[i][0] > index)
                {
                    index = intervals[i][1];
                    answer++;
                }
            }
            return answer;
        }
    }
}
