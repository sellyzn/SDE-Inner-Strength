using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLAMG.ByteDance.Easy
{
    public class Interval
    {
        public int start, end;
        public Interval(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }
    public class MeetingRoom
    {
        //Meeting Room I
        public bool CanAttendMeetings(int[][] intervals)
        {
            intervals = intervals.OrderBy((x) => x[0]).ToArray();
            //intervals.Sort(
            //    delegate int Compare(int[] x1, int[] x2){
            //    return x2[0] - x1[0];
            //}
            //    );
            for (int i = 0; i < intervals.Length; i++)
            {
                if (intervals[i][1] > intervals[i + 1][0])
                    return false;
            }
            return true;
        }

        //Meeting Room II
        //求所需会议室的最少数量

        public int MinMeetingRooms(List<Interval> intervals)
        {
            if (intervals == null || intervals.Count == 0)
                return 0;

            int n = intervals.Count;
            int index = 0;
            var start = new int[n];
            var end = new int[n];
            foreach (Interval interval in intervals)
            {
                start[index] = interval.start;
                end[index] = interval.end;
                index++;
            }

            Array.Sort(start);
            Array.Sort(end);

            int room = 0, pre = 0;

            for (int i = 0; i < n; i++)
            {
                room++;
                if (start[i] >= end[pre])
                {
                    room--;
                    pre++;
                }
            }

            return room;
        }




        //Meeting Room III
        /*
         * you have a list intervals of current meetings, and some meeting rooms with start and end timestamp.
         * When a stream of new meeting ask coming in, judge one by one whether they can be placed in the current meeting list without overlapping.
         * A meeting room can only hold one meeting at a time. Each inquiry is independent.
         * The meeting asked can be splited to some times. For example, if you want to ask a meeting for [2, 4], you can split it to [2,3] and [3, 4].
         */
        public bool[] MeetingRoomIII(int[][] intervals, int rooms, int[][] ask)
        {
            //另一种的扫描线Event表示法，只是没有另外写 Event class
            int[] events = new int[50001];    //events[i]: +1表示一个会议开始   -1表示一个会议结束
            int maxEndTime = 0;
            foreach (var interval in intervals)
            {
                events[interval[0]]++;
                events[interval[1]]--;
                maxEndTime = Math.Max(maxEndTime, interval[1]);
            }

            foreach (var query in ask)
            {
                maxEndTime = Math.Max(maxEndTime, query[1]);
            }

            //前缀和不断维护当前同时存在的会议；起终点只是会议状态发生变化的时候
            int numOfMeetings = 0;
            int[] sum = new int[50001]; //sum[i] = 0 -> empty; sum[i] = 1  -> not empty
            for (int i = 0; i <= maxEndTime; i++)
            {
                numOfMeetings += events[i];
                //这个世界在进行的会议数量到不到rooms个， 还有空的会议室
                if (numOfMeetings < rooms)
                {
                    sum[i] = 0;
                }
                else
                {
                    sum[i] = 1;
                }
            }

            //[left,right] 要求sum[left...right-1]全为0， sum[left..right-1] = 0
            //prefixSum[right - left + 1] - prefixSum[left] = 0 <=> prefixSum[right] = prefixSum[left]
            int[] prefixSum = new int[sum.Length + 1];
            prefixSum[0] = 0;
            for (int i = 1; i < prefixSum.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + sum[i - 1];
            }

            bool[] result = new bool[ask.Length];
            for (int i = 0; i < ask.Length; i++)
            {
                int[] query = ask[i];
                int start = query[0];
                int end = query[1];

                result[i] = prefixSum[end] == prefixSum[start];
            }

            return result;
        }


        ////Meeting Room IV
        ///*
        // * Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei) and the value of each meeting. 
        // * You can only attend a meeting at the same time. Please calculate the most value you can get.
        // */
        //public int MaxValue(int[][] meeting, int[] value)
        //{

        //}


        ////Merge Intervals

        //public int[][] Merge(int[][] intervals)
        //{
        //    intervals = intervals.OrderBy(x => x[0]).ToArray();
        //    var merged = new List<int[]>();
        //    for (int i = 0; i < intervals.Length; i++)
        //    {
        //        int left = intervals[i][0], right = intervals[i][1];
        //        if (merged.Count == 0 || merged[merged.Count - 1][1] < left)
        //        {
        //            merged.Add(new int[] { left, right });
        //        }
        //        else
        //        {
        //            merged[merged.Count - 1][1] = Math.Max(merged[merged.Count - 1][1], right);
        //        }
        //    }
        //    return merged.ToArray();
        //}


        ////Insert Intervals

        //public int[][] Insert(int[][] intervals, int[] newInterval)
        //{
        //    int left = newInterval[0];
        //    int right = newInterval[1];
        //    var resList = new List<int[]>();
        //    bool placed = false;
        //    foreach (var interval in intervals)
        //    {
        //        if (interval[0] > right)
        //        {
        //            //newInterval is on the right side of the current interval, and no intersection.
        //            if (!placed)
        //            {
        //                resList.Add(new int[] { left, right });
        //                placed = true;
        //            }
        //            resList.Add(interval);
        //        }
        //        else if (interval[1] < left)
        //        {
        //            //newInterval is on the left side of the current interval, and no intersection.
        //            resList.Add(interval);
        //        }
        //        else
        //        {
        //            //newInterval has intersection with the current interval.
        //            left = Math.Min(left, interval[0]);
        //            right = Math.Max(right, interval[1]);
        //        }
        //    }
        //    if (!placed)
        //    {
        //        resList.Add(new int[] { left, right });
        //    }
        //    //int[][] res = new int[resList.Count][];
        //    //for (int i = 0; i < resList.Count; i++)
        //    //{
        //    //    res[i] = resList[i];
        //    //}
        //    //return res;
        //    return resList.ToArray();
        //}



    }
}
