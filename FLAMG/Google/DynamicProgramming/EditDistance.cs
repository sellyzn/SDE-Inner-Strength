using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.DynamicProgramming
{
    public class EditDistance
    {
        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length, n = word2.Length;
            // 
            // dp[i,j]: returns the min distance of word1[0...i] and word2[0...j]
            // if word1[i] == word2[j]  dp[i, j] = dp[i - 1, j - 1]
            // if word1[i] != word2[j], dp[i, j] = Min(插入，删除，替换)
            // 插入：dp[i, j - 1] + 1 : 直接在word1[i]插入一个和word2[j]一样的字符，那么word2[j]就被匹配了，前移j， 继续跟i对比，操作数加1
            // 删除：dp[i - 1, j] + 1 : 直接把word[i]这个字符删掉，前移i， 继续跟j对比，操作数加1
            // 替换： dp[i-1, j-1] + 1 ： 直接把word1[i]替换成word2[j]，这样它俩就匹配了，同时前移i, j继续对比，操作数加1
            int[,] dp = new int[m + 1, n + 1];

            // base case
            for (int i = 1; i <= m; i++)
                dp[i, 0] = i;
            for (int j = 1; j <= n; j++)
                dp[0, j] = j;

            // 自底向上求解
            for(int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                        dp[i, j - 1] = Math.Min(dp[i - 1, j] + 1, Math.Min(dp[i, j - 1] + 1, dp[i - 1, j - 1] + 1));
                }
            }
            return dp[m, n];
        }
    }
}
