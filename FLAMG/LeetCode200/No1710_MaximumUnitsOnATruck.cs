using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No1710_MaximumUnitsOnATruck
    {
        /// <summary>
        /// Sorting + greedy
        /// </summary>
        /// <param name="boxTypes"></param>
        /// <param name="truckSize"></param>
        /// <returns></returns>
        /// T: O(nlogn)
        /// S: O(1)
        public int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            boxTypes = boxTypes.OrderByDescending(x => x[1]).ToArray();
            int maxUnits = 0;
            for(int i = 0; i < boxTypes.Length; i++)
            {
                if(truckSize > 0)
                {
                    maxUnits += boxTypes[i][0] <= truckSize ? boxTypes[i][0] * boxTypes[i][1] : truckSize * boxTypes[i][1];
                    truckSize -= boxTypes[i][0];
                }
                else
                {
                    break;
                }
            }
            return maxUnits;
        }
    }
}
