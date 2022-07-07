using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{    
    internal class No1229_MeetingScheduler
    {      
        /// <summary>
        /// Two Pointers
        /// </summary>
        /// <param name="slots1"></param>
        /// <param name="slots2"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        /// T: O(MlogM + NlogN), sorting arrays
        /// S: O(1)
        public IList<int> MinAvailableDuration(int[][] slots1, int[][] slots2, int duration)
        {
            slots1 = slots1.OrderBy(x => x[0]).ToArray();
            slots2 = slots2.OrderBy(x => x[0]).ToArray();
            int pointer1 = 0, pointer2 = 0;
            while(pointer1 < slots1.Length && pointer2 < slots2.Length)
            {
                // find the boundaries of the intersection, or the common slot
                int intersectLeft = Math.Max(slots1[pointer1][0], slots2[pointer2][0]);
                int intersectRight = Math.Min(slots1[pointer1][1], slots2[pointer2][1]);
                if(intersectRight - intersectLeft >= duration)
                {
                    var result = new List<int>();
                    result.Add(intersectLeft);
                    result.Add(intersectLeft + duration);
                    return result;
                }                    

                // always move the one that ends earlier
                if(slots1[pointer1][1] < slots2[pointer2][1])
                    pointer1++;
                else
                    pointer2++;               
            }
            return new List<int>();
        }
    }
}
