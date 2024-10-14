using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.BacktrackingProblems
{
    /*
    Backtracking
    时间：O()， M为集合的大小，本题固定为9，一共有(CMk)个组合，每次判断需要的时间代价为O(k)。
    空间：O(M + k) --> O(M)。 track数组的空间代价为O(k)，递归栈空间的代价为O(M)
    */
    internal class P216_CombinationSumIII
    {
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> track = new List<int>();
        int trackSum = 0;
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            BackTrack(k, n, 1);
            return result;
        }
        public void BackTrack(int k, int n, int start)
        {
            if(track.Count == k && trackSum == n)
            {
                result.Add(new List<int>(track));
                return;
            }
            if(track.Count > k ||  trackSum > n)
            {
                return;
            }
            for(int i = start; i <= 9; i++)
            {
                track.Add(i);
                trackSum += i;
                BackTrack(k, n, i + 1);
                track.RemoveAt(track.Count - 1);
                trackSum -= i;
            }
        }
    }
}
