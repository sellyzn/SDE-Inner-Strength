using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No1481_LeastNumberOfUniqueIntegersAfterKRemovals
    {
        /// <summary>
        /// Dictionary + Sorting
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// T: O(NlogN)
        /// S: O(N)
        public int FindLeastNumOfUniqueInts(int[] arr, int k)
        {
            var freqMap = new Dictionary<int, int>();
            foreach (var num in arr)
            {
                if (freqMap.ContainsKey(num))
                    freqMap[num]++;
                else
                    freqMap[num] = 1;
            }
            var list = freqMap.OrderBy(x => x.Value).ToList();
            var length = list.Count;
            for(int i = 0; i < list.Count; i++)
            {                
                if(k > 0)
                {
                    k -= list[i].Value;
                    length--;
                }
                if (k == 0)
                    return length;
            }
            return length + 1;
        }
    }
}
