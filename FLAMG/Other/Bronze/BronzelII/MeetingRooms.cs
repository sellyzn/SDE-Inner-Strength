using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLAMG.Other.Bronze.BronzelII
{
    public class MeetingRooms
    {
        public bool CanAttendMeetings(int[][] intervals)
           
        {
            intervals = intervals.OrderBy((x) => x[0]).ToArray();
            for(int i = 0; i < intervals.Length - 1; i++)
            {
                if (intervals[i][1] > intervals[i + 1][0])
                    return false;
            }
            return true;
        }
    }
}
