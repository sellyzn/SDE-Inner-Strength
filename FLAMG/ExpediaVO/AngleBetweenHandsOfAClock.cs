using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class AngleBetweenHandsOfAClock
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public double AngleClock(int hour, int minutes)
        {
            int oneMinAngle = 6;
            int oneHourAngle = 30;
            double minutesAngle = oneMinAngle * minutes;
            double hourAngle = (hour % 12 + minutes / 60.0) * oneHourAngle;
            double diff = Math.Abs(hourAngle - minutesAngle);
            return Math.Min(diff, 360 - diff);
        }
    }
}
