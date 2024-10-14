using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.HashMapSetProblems
{
    internal class P2452_EqualRowAndColumnPairs
    {
        /*
        哈希表HashMap
        时间：O(N*2)
        空间：O(N)
        */
        public int EqualPairs(int[][] grid)
        {
            var dict = new Dictionary<string, int>();
            for (int i = 0; i < grid.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < grid[i].Length; j++)
                {
                    sb.Append(grid[i][j].ToString());
                }
                if (dict.ContainsKey(sb.ToString()))
                {
                    dict[sb.ToString()]++;
                }
                else
                {
                    dict.Add(sb.ToString(), 0);
                }
            }
            var result = 0;
            for (int j = 0; j < grid[0].Length; j++)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < grid.Length; i++)
                {
                    sb.Append(grid[i][j].ToString());
                }
                if (dict.ContainsKey(sb.ToString()))
                {
                    result += dict[sb.ToString()];
                }
            }
            return result;
        }
    }
}
