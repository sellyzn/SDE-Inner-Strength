using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No1229_MeetingScheduler
    {
        /// <summary>
        /// Sorting + Two Pointers
        /// </summary>
        /// <param name="slots1"></param>
        /// <param name="slots2"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        /// T: O(M + N)
        /// S: O(1)
        public IList<int> MinAvailableDuration(int[][] slots1, int[][] slots2, int duration)
        {
            var result = new List<int>();
            slots1 = slots1.OrderBy(x => x[0]).ToArray();
            slots2 = slots2.OrderBy(x => x[0]).ToArray();
            int pointer1 = 0, pointer2 = 0;
            while (pointer1 < slots1.Length && pointer2 < slots2.Length)
            {
                int intersectionLeft = Math.Max(slots1[pointer1][0], slots2[pointer2][0]);
                int intersectionRight = Math.Min(slots1[pointer1][1], slots2[pointer2][1]);
                if (intersectionRight - intersectionLeft >= duration)
                {
                    result.Add(intersectionLeft);
                    result.Add(intersectionLeft + duration);
                    return result;
                }
                if (slots1[pointer1][1] < slots2[pointer2][1])
                    pointer1++;
                else
                    pointer2++;
            }
            return result;
        }
    }
}
