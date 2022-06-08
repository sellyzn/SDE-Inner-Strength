using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No97_InterleavingString
    {
        /// <summary>
        /// DP
        /// dp[i, j] : s1的前i个元素和s2的前j个元素是否能够交错组成s3的前i+j个元素。
        /// 如果 s1[i] = s3[i + j]， 则dp[i,j]取决于dp[i - 1, j]， 即 s1 的前 i - 1 个元素和 s2 的前 j 个元素是否能够交错组成 s3的前 i + j - 1 个元素。
        /// 同理， 如果 s2[j] = s3[i + j]， 则dp[i,j]取决于dp[i, j - 1]， 即 s1 的前 i 个元素和 s2 的前 j - 1 个元素是否能够交错组成 s3的前 i + j - 1 个元素。
        /// 
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <returns></returns>
        /// T: O(mn)
        /// S: O(mn)
        public bool IsInterleave(string s1, string s2, string s3)
        {
            //if (s1.Length + s2.Length != s3.Length)
            //    return false;
            //var dp = new bool[s1.Length + 1, s2.Length + 1];
            //dp[0, 0] = true;

            //for (int i = 1; i <= s1.Length; i++)
            //{
            //    dp[i, 0] = s1[i - 1] == s3[i - 1] && dp[i - 1, 0];
            //}
            //for (int j = 1; j <= s2.Length; j++)
            //{
            //    dp[0, j] = s2[j - 1] == s3[j - 1] && dp[0, j - 1];
            //}
            //for (int i = 1; i <= s1.Length; i++)
            //{
            //    for (int j = 1; j <= s2.Length; j++)
            //    {
            //        char ch1 = s1[i - 1], ch2 = s2[j - 1], ch3 = s3[i + j - 1];
            //        dp[i, j] = (ch1 == ch3 && dp[i - 1, j]) || (ch2 == ch3 && dp[i, j - 1]);
            //    }
            //}
            //return dp[s1.Length, s2.Length];

            if (s3.Length != s1.Length + s2.Length)
            {
                return false;
            }
            var dp = new bool[s1.Length + 1, s2.Length + 1];
            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i, j] = true;
                    }
                    else if (i == 0)
                    {
                        dp[i, j] = dp[i, j - 1] && s2[j - 1] == s3[i + j - 1];
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = dp[i - 1, j] && s1[i - 1] == s3[i + j - 1];
                    }
                    else
                    {
                        dp[i, j] = (dp[i - 1, j] && s1[i - 1] == s3[i + j - 1]) || (dp[i, j - 1] && s2[j - 1] == s3[i + j - 1]);
                    }
                }
            }
            for (int i = 0; i < s1.Length + 1; i++)
            {
                Console.WriteLine($"Row {i}:");
                for (int j = 0; j < s2.Length + 1; j++)
                {
                    Console.WriteLine(dp[i, j]);
                }
            }
            return dp[s1.Length, s2.Length];
        }
    }
}
