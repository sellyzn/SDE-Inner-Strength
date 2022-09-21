using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.IntervalCategory
{
    internal class InsertInterval
    {
        // 57. Insert Interval
        /*
        intervals is sorted in asceding order by starti

                            i 
        intervals: [1,3],[6,9],[10,12],[15,19]
        newInterval: [2,5]
        left:  1
        right: 5
        flag: true
        result: [1,5]



        interval:          ----      -----         ---
        newInterval:  ---
                                ---
                                                         ---
                             --------

         1. traverse intervals, update starti, endi                  

         */
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var result = new List<int[]>();
            var left = newInterval[0];
            var right = newInterval[1];
            var flag = false;
            if(intervals == null || intervals.Length == 0)
            {
                result.Add(newInterval);
                return result.ToArray();
            }
            foreach (var interval in intervals)
            {
                if(interval[0] > right)
                {
                    if (!flag)
                    {
                        result.Add(new int[] {left, right});
                        flag = true;
                    }
                    result.Add(interval);
                }else if(interval[1] < left)
                {
                    result.Add(interval);
                }
                else
                {
                    left = Math.Min(left, interval[0]);
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
