using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Pramp
{
    internal class PairsWithSpecificDifference
    {
        /// <summary>
        /// HashMap
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// T: O(n)
        /// S: O(n)
        public int[][] FindPairsWithGivenDifference(int[] arr, int k)
        {
            var result = new List<int[]>();
            if (k == 0)
                return null;
            var map = new Dictionary<int, int>();
            foreach (var x in arr)
            {
                map[x - k] = x;
            }
            foreach (var y in arr)
            {
                if (map.ContainsKey(y))
                    result.Add(new int[] { map[y], y });
            }
            return result.ToArray();
        }
    }
}
