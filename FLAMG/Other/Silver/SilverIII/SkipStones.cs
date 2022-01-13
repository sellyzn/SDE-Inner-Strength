using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverIII
{
    public class SkipStones
    {       
        ///////不会不会不会///////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param stone numbers>
        /// <param name="m"></param remove stones numbers>
        /// <param name="target"></param the distance between the starting point and end point>
        /// <param name="d"></param the distance between the starting point and the ith( i start from 0) stone>
        /// <returns></returns>
        public int GetDistance(int n, int m, int target, List<int> d)
        {
            // handle corner cases
            if (m >= n)
            {
                return target;
            }

            // binarySearch on the result space. 
            int begin = 0, end = target;
            while (begin + 1 < end)
            {
                int mid = (end - begin) / 2 + begin;
                if (NumberOfRemovals(n, mid, target, d) <= m)
                {
                    begin = mid;
                }
                else
                {
                    end = mid;
                }
            }            

            if (NumberOfRemovals(n, end, target, d) <= m)
            {
                return end;
            }
            if (NumberOfRemovals(n, begin, target, d) <= m)
            {
                return begin;
            }

            return target;
        }

        public int NumberOfRemovals(int n, int minDistanceRequired, int target, List<int> d)
        {
            // calculating the numberOfRemovals, if we were to achieve that minDistanceRequired. 
            int removalCounter = 0;
            int lastLocation = 0;
            foreach (int currentLocation in d)
            {
                if (currentLocation - lastLocation < minDistanceRequired)
                {
                    removalCounter++;
                }
                else
                {
                    lastLocation = currentLocation;
                }
            }
           
            return removalCounter;
        }



    }
}
