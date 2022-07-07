using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No583_DeleteOperationForTwoStrings
    {
        int[,] memo;
        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;
            if (m == 0 && n == 0)
                return 0;
            if (m == 0 && n != 0)
                return n;
            if (m != 0 && n == 0)
                return m;
            int lcs = LongestCommonSubsequence(word1, word2);
            return m - lcs + n - lcs;
        }
        public int LongestCommonSubsequence(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;
            memo = new int[m, n];
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    memo[i, j] = -1;
                }
            }
            return DP(word1, 0, word2, 0);
        }
        
        public int DP(string word1, int i, string word2, int j)
        {
            if (i == word1.Length || j == word2.Length)
                return 0;
            if (memo[i, j] != -1)
                return memo[i, j];
            if (word1[i] == word2[j])
                memo[i, j] = 1 + DP(word1, i + 1, word2, j + 1);
            else
                memo[i, j] = Math.Max(DP(word1, i + 1, word2, j), DP(word1, i, word2, j + 1));

            return memo[i, j];
        }

        /// <summary>
        /// dp二维数组m + 1行，n + 1列
        /// DP[i, j]: 表示word1[0:i] 和word2[0:j]的最长公共子序列的长度
        /// word1[0:i]表示word1的长度为i的前缀
        /// word2[0:j]表示word2的长度为j的前缀
        /// 
        /// 边界条件：
        /// 当i = 0时，word1[0:0]为空， 空字符串和任何字符串的最长公共子序列的长度都为0，因此，对于任意0 <= j <= n， dp[0,j] = 0；
        /// 当j = 0时，同理， 对于任意0 <= i <= m， dp[i,0] = 0；
        /// 
        /// 因此动态规划的边界情况是： 当i = 0或j = 0是，dp[i,j] = 0。
        /// 
        /// 当i > 0 且j > 0时：
        /// dp[i,j] = dp[i-1,j-1] + 1               word1[i-1] == word2[j-1]
        /// dp[i,j] = max(dp[i-1,j], dp[i,j-1])     word1[i-1] != word2[j-1]
        /// 
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="i"></param>
        /// <param name="word2"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        /// T: O(mn)
        /// S: O(mn)
        public int LongestCommonSubsequence_1(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;
            var dp = new int[m + 1, n + 1];
            for(int i = 1; i <= m; i++)
            {
                for(int j = 1; j <= n; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
            return dp[m, n];
        }
    }
}
