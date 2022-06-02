using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    /// <summary>
    /// Sorting + Two Pointers
    /// T: Add: O(1), Find: O(NlogN)
    /// S: O(N)
    /// 
    /// HashTable
    /// T: Add:O(1), Find: O(N)
    /// S: O(N)
    /// </summary>
    internal class No170TwoSumIII
    {
        IList<int> list;
        public No170TwoSumIII()
        {
            list = new List<int>();
        }

        public void Add(int number)
        {
            list.Add(number);
        }

        public bool Find(int value)
        {
            var dict = new Dictionary<int, int>();
            
            for(int i = 0; i < list.Count; i++)
            {
                var diff = value - list[i];
                if (dict.ContainsKey(diff))
                    return true;
                else
                    dict[list[i]] = 1;
            }
            return false;
        }
    }
}
