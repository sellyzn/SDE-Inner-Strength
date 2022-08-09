using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No473_MatchsticksToSquare
    {
        /// <summary>
        /// Backtracking
        /// </summary>
        /// <param name="matchsticks"></param>
        /// <returns></returns>
        /// T: O(4^n)，n是火柴是数目。每根火柴都可以选择放在4条边上，因此时间复杂度位O(4^n)
        /// S: O(n)，递归栈需要占用O(n)的空间
        public bool Makesquare(int[] matchsticks)
        {
            int sum = 0;
            if(matchsticks == null || matchsticks.Length < 4)
                return false;
            for(int i = 0; i < matchsticks.Length; i++)
            {
                sum += matchsticks[i];
            }
            // 
            matchsticks = matchsticks.OrderByDescending(x => x).ToArray();
            if(sum % 4 != 0)
                return false;
            int squareLength = sum / 4;
            int[] edges = new int[4];
            return Backtrack(matchsticks, 0, edges, squareLength);
        }
        public bool Backtrack(int[] matchsticks, int index, int[] edges, int squareLength)
        {
            if (index == matchsticks.Length)
                return true;
            for(int i = 0;i < edges.Length; i++)
            {
                edges[i] += matchsticks[index];
                if(edges[i] <=squareLength && Backtrack(matchsticks, index + 1, edges, squareLength))
                    return true;
                edges[i] -= matchsticks[index];
            }
            return false;
        }
        public bool Backtrack1(int[] matchsticks, int index, int target, int[] edges)
        {
            if(index == matchsticks.Length)
            {
                //如果火柴都访问完了，并且size的4个边的长度都相等，说明是正方形，直接返回true，否则返回false
                if (edges[0] == edges[1] && edges[1] == edges[2] && edges[2] == edges[3])
                    return true;
                else
                    return false;
            }
            // 到这一步说明火柴还没访问完
            for(int i = 0; i < edges.Length; i++)
            {
                // 剪枝
                // 如果把当前的火柴放到edges[i]这个边上，它的长度大于target，直接跳过
                // edges[i] == edges[i - 1])即上一个分支的值和当前分支的一样，上一个没有成功，说明这个分支也不会成功，直接跳过即可
                // if (edges[i] + matchsticks[index] > target)
                if (edges[i] + matchsticks[index] > target || (i > 0 && edges[i] == edges[i - 1]))
                    continue;
                // 如果当前火柴放到edges[i]这个边上，它的长度不大于target，我们就放上面
                edges[i] += matchsticks[index];
                // 然后再放下一个火柴，如果最终能变成正方形，直接返回true
                if (Backtrack1(matchsticks, index + 1, target, edges))
                    return true;
                // 如果当前火柴放到edges[i]这个边上，最终不能构成正方形，我们就把它从edges[i]这个边上给移除，然后再试其他的边
                edges[i] -= matchsticks[index];
            }
            return false;
        }
    }
}
