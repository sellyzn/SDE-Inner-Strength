using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Facebook.Medium
{
    public class InsertInterval
    {
        /////////////////////
        // Insert Interval //
        /////////////////////
        
        //Traverse + Simulate
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            int left = newInterval[0];
            int right = newInterval[1];
            var resList = new List<int[]>();
            bool placed = false;
            foreach (var interval in intervals)
            {
                if(interval[0] > right)
                {
                    //newInterval is on the right side of the current interval, and no intersection.
                    if (!placed)
                    {
                        resList.Add(new int[] { left, right });
                        placed = true;
                    }
                    resList.Add(interval);
                }else if(interval[1] < left)
                {
                    //newInterval is on the left side of the current interval, and no intersection.
                    resList.Add(interval);
                }
                else
                {
                    //newInterval has intersection with the current interval.
                    left = Math.Min(left, interval[0]);
                    right = Math.Max(right, interval[1]);
                }
            }
            //newInterval is on the right of all intervals, and no interaction.
            if (!placed)
            {
                resList.Add(new int[] { left, right });
            }
            int[][] res = new int[resList.Count][];
            for (int i = 0; i < resList.Count; i++)
            {
                res[i] = resList[i];                
            }
            return res;
        }
    }
}
