using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.IntervalCategory
{
    internal class MeetingRooms
    {
        // 252. Meeting Rooms
        public bool CanAttendMeetings(int[][] intervals)
        {
            intervals = intervals.OrderBy(x => x[0]).ToArray();
            if (intervals.Length == 1)
                return true;
            for(int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] < intervals[i - 1][1])
                    return false;
            }
            return true;
        }
    }
}
