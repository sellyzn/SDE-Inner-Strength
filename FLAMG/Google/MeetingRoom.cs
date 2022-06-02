using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLAMG.Google
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
        public bool CanAttendMeetings(IList<Interval> intervals)
        {
            if (intervals == null || intervals.Count <= 1)
                return true;
            //intervals.OrderBy(x => x.start);
            var newIntervals = intervals.OrderBy(x => x.start).ToList();
            for (int i = 1; i < intervals.Count; i++)
            {
                if(intervals[i].start < intervals[i - 1].end)
                {
                    return false;
                }
            }
            return true;
        }

        public int MinMeetingRooms_II(IList<Interval> intervals)
        {
            //corner case
            if (intervals == null || intervals.Count == 0)
                return 0;

            // start, end
            var n = intervals.Count;
            var start = new int[n];
            var end = new int[n];
            var index = 0;
            foreach (var item in intervals)
            {
                start[index] = item.start;
                end[index] = item.end;
                index++;
            }

            // sort start[] and end[]
            Array.Sort(start);
            Array.Sort(end);

            // 
            int room = 0, pre = 0;
            for(int i = 0; i < n; i++)
            {
                if (start[i] < end[pre])                
                    room++;                
                else
                    pre++;
            }
            return room;
        }

        /// <summary>
        /// 1. sort the interval by the start time in ascending order
        /// 2. use a preorityqueue pq to store the end time
        /// 3. traverse the intervals, put the current interval end time into the preority queue. if the current interval start time is < the top element of the priority queue, the room++, otherwise, Dequeue the top element of the priority queue.
        /// 4. return room number
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int MinMeetingRooms_II_Heap(IList<Interval> intervals)
        {
            if (intervals == null || intervals.Count == 0)
                return 0;
            intervals = intervals.OrderBy(x => x.start).ToList();
            var pq = new PriorityQueue<Interval,int>();
            var room = 0;
            for (int i = 0; i < intervals.Count; i++)
            {
                pq.Enqueue(intervals[i], intervals[i].end);
                if (intervals[i].start < pq.Peek().end)
                    room++;
                else
                    pq.Dequeue();
            }
            return room;
        }

        public bool[] MeetingRoomIII(int[][] intervals, int rooms, int[][] ask)
        {
            // sort intervals by the start time, if the start times are equals, sort the end time (ascending order)
            // traverse ask array, to check if each meeting interval can be placed in the current meeting list without overlapping.
            //      about the check progress:
            //          traverse the intervals, check the end time with the new meeting start time, if the end time is <= the new meeting start time, then we check the next meeting start time in the list and the new meeting end time.
            //          if the 

            // Traverse + PrefixSum

            // Traverse the intervals and find the maxEndTime
            // use a array event[] to record the meeting status, when a meeting start, we mark the start time as 1, when a meeting end, we mark the end time as -1.
            // use numOfMeetings to record the number of meeting rooms used in time node i
            // use a array sum[] to record if there is empty room to use, if there are empty rooms, the sum[i] is 0, otherwise, is 1.
            // use a array prefixSum[] to record the 
            // traverse the ask array, to check each interval, whether its prefixSum[start] == prefixSum[end], if yes, that mean sum[start...end] are all 0, and we can place the [start, end] interval into the meeting lists.
            // if yes, the value is true, otherwise, false.

            var maxEndTime = 0;
            var events = new int[50001];        // record the meeting room satus of each time node
            foreach (var item in intervals)
            {
                events[item[0]]++;
                events[item[1]]--;
                maxEndTime = Math.Max(maxEndTime, item[1]);
            }
            foreach (var item in ask)
            {
                maxEndTime = Math.Max(maxEndTime, item[1]);
            }

            var sum = new int[50001];      // 
            var numOfMeetings = 0;
            for(int i = 0; i <= maxEndTime; i++)
            {
                numOfMeetings += events[i];
                if (numOfMeetings < rooms)
                    sum[i] = 0;     //that means there are empty rooms left to use
                else
                    sum[i] = 1;     //that means there is no empty rooms left to use
            }

            // for interval [l,r], we need sum[l...r-1] are all 0, sum[l...r-1] = 0
            // prefixSum[r-1 + 1] - preixSum[l] = 0 <=> prefixSum[r] = prefixSum[l]
            var prefixSum = new int[sum.Length + 1];
            prefixSum[0] = 0;
            for(int i = 1; i < prefixSum.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + sum[i - 1];
            }

            var result = new bool[ask.Length];
            for (int i = 0; i < ask.Length; i++)
            {
                var start = ask[i][0];
                var end = ask[i][1];
                result[i] = prefixSum[start] == prefixSum[end];
            }
            return result;
        }

        public bool[] MeetingRoomIII_I_II(int[][] intervals, int rooms, int[][] ask)
        {
            int[][] curIntervals;
            var result = new bool[ask.Length];
            var index = 0;
            foreach (var askInterval in ask)
            {
                curIntervals = intervals;
                curIntervals.Append(askInterval);

                var minNumberOfRooms = MinMeetingRoomsIII_II(curIntervals);
                if (minNumberOfRooms <= rooms)
                    result[index] = true;
                else
                    result[index] = false;
                index++;
            }
            return result;
        }
        public bool CanAttendMeetingsIII_I(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 1)
                return true;
            intervals = intervals.OrderBy(x => x[0]).ToArray();
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] < intervals[i - 1][1])
                    return false;
            }
            return true;
        }
        public int MinMeetingRoomsIII_II(int[][] intervals)
        {
            if(intervals == null || intervals.Length == 0)
                return 0;
            intervals = intervals.OrderBy(x => x[0]).ToArray();
            var heap = new PriorityQueue<int[], int>();
            var room = 0;
            for (int i = 0; i < intervals.Length; i++)
            {
                heap.Enqueue(intervals[i], intervals[i][1]);
                if (intervals[i][0] < heap.Peek()[1])
                    heap.Dequeue();
                else
                    room++;
            }
            return room;
        }

        //public int MaxValue(int[][] meetings, int[] value)
        //{

        //}




    }
}
