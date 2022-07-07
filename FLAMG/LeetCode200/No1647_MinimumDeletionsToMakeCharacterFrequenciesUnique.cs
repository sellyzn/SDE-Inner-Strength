using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No1647_MinimumDeletionsToMakeCharacterFrequenciesUnique
    {
        /// <summary>
        /// HashMap + HashSet
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public int MinDeletions(string s)
        {
            // use a hashmap to record the character and its frequency

            //  traverse the hashmap, use a set to record the frequency, if the frequency has exist in the set, decrease it till it not exist in the set

            var map = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (map.ContainsKey(c))
                    map[c]++;
                else
                    map.Add(c, 1);
            }

            var set = new HashSet<int>();
            var count = 0;
            foreach (char c in map.Keys)
            {
                while (set.Contains(map[c]))
                {
                    count++;
                    map[c]--;
                }
                if(map[c] == 0)
                    map.Remove(c);
                else
                    set.Add(map[c]);
            }
            return count;
        }
    }
}
