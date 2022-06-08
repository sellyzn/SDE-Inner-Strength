using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No216_CombinationSumIII
    {
        /// <summary>
        /// 找到所有k个数字和为n的组合。限制：只有数字1-9可用，每个数字最多使用一次。
        /// </summary>
        /// <param name="k"></param>
        /// <param name="n"></param>
        /// <returns></returns>
       
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> track = new List<int>();
        int trackSum = 0;        
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            Backtrack(k, n, 1);
            return result;
        }
        public void Backtrack(int k, int n, int start)
        {
            if(track.Count == k && trackSum == n)
            {
                result.Add(new List<int>(track));
                return;
            }
            if(track.Count > k || trackSum > n)
            {
                return;
            }
            for(int i = start; i <= 9; i++)
            {
                track.Add(i);
                trackSum += i;
                Backtrack(k, n, i + 1);
                track.RemoveAt(track.Count - 1);
                trackSum -= i;
            }
        }        
    }
}
