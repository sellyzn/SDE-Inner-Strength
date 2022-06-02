using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No77Combinations
    {
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> track = new List<int>();
        public IList<IList<int>> Combine(int n, int k)
        {
            Backtrack(n, k, 1);
            return result;
        }
        public void Backtrack(int n, int k, int start)
        {
            // base case
            if(k == track.Count)
            {
                // 遍历到了第k层，收集当前节点的值
                result.Add(new List<int>(track));
                return;
            }
            for(int i = start; i <= n; i++)
            {
                // 做选择
                track.Add(i);
                // 通过start参数控制树枝的遍历，避免产生重复的子集
                Backtrack(n, k, i + 1);
                // 撤销选择
                track.RemoveAt(track.Count - 1);
            }
        }
    }
}
