using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.HighestFrequency
{
    internal class MinimumTimeDifference
    {
        public int FindMinDifference(IList<string> timePoints)
        {
            if(timePoints == null || timePoints.Count <= 1)
                return 0;
            int length = timePoints.Count;
            var minDifference = int.MaxValue;
            for(int i = 0; i < length; i++)
            {
                for(int j = i + 1; j < length; j++)
                {
                    minDifference = Math.Min(minDifference, Difference(timePoints[i], timePoints[j]));
                }
            }
            return minDifference;
        }
        // Calculate the difference between two timepoints
        public int Difference(string time1, string time2)
        {
            var time1Hour = int.Parse(time1.Substring(0, 2));
            var time1Minus = int.Parse(time1.Substring(3, 2));
            var time2Hour = int.Parse(time2.Substring(0, 2));
            var time2Minus = int.Parse(time2.Substring(3, 2));

            //var hourDiff = time1Hour - time2Hour;
            //var minusDiff = time1Minus - time2Minus;
            int hourDiff = 0;
            int minusDiff = 0;
            if (time1Hour > time2Hour)
            {
                hourDiff = time1Hour - time2Hour;
                minusDiff = time1Minus - time2Minus;
            }
            else if (time1Hour - time2Hour == 0)
            {
                hourDiff = 0;
                minusDiff = Math.Abs(time1Minus - time2Minus);
            }
            else if (time1Hour - time2Hour < 0)
            {
                hourDiff = time2Hour - time1Hour;
                minusDiff = time2Minus - time1Minus;
            }

            var diff = 0;
            
            if (hourDiff < 12)
            {
                diff = hourDiff * 60 + minusDiff;

            }
            else if(hourDiff == 12)
            {                
                diff = (24 - hourDiff) * 60 - Math.Abs(minusDiff);
               
            }
            else if(hourDiff > 12)
            {
                diff = (24 - hourDiff) * 60 - minusDiff;
            }
            Console.WriteLine($"diff: {diff}");
            return diff;
        }


        public int FidMinDifference_ON(IList<string> timePoints)
        {
            var timeList = new int[timePoints.Count];
            var index = 0;
            foreach (var timePoint in timePoints)
            {
                int hour = int.Parse(timePoint.Substring(0, 2));
                int minus = int.Parse(timePoint.Substring(3, 2));
                timeList[index++] = hour * 60 + minus;
            }
            Array.Sort(timeList);

            int minDiff = int.MaxValue;
            int n = timeList.Length;
            for(int i = 0; i < n; i++)
            {
                int diff = Math.Abs(timeList[(i + 1) % n] - timeList[i]);
                diff = Math.Min(diff, 1440 - diff);
                minDiff = Math.Min(minDiff, diff);
            }
            return minDiff;
        }

        // 1200. Minimum Absolute Difference
        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            // sorting
            Array.Sort(arr);
            var minDiff = int.MaxValue;
            var res = new List<IList<int>>();
            //traverse arr
            for (int i = 0; i < arr.Length - 1; i++)
            {
                minDiff = Math.Min(minDiff, arr[i + 1] - arr[i]);
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i + 1] - arr[i] == minDiff)
                    res.Add(new List<int>() { arr[i], arr[i + 1] });
            }
            return res;
        }

    }
}
