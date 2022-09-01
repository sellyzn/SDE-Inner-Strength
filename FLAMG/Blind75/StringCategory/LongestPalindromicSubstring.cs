using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.StringCategory
{
    internal class LongestPalindromicSubstring
    {
        // 5. Longest Palindrome Substring
        // 
        public string LongestPalindrome(string s)
        {
            if (s == null || s.Length == 0)
                return "";
            //int start = 0, end = 0;
            var maxLen = 0;
            var index = 0;
            for(int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                index = maxLen > len ? index : i - (len - 1) / 2;
                maxLen = Math.Max(maxLen, len);
                //if(len > end - start)
                //{
                //    start = i - (len - 1) / 2;
                //    end = i + len / 2;
                //}
            }
            //return s.Substring(start, end - start + 1);
            return s.Substring(index, maxLen);
        }
        public int ExpandAroundCenter(string s, int left, int right)
        {
            while(left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        }

        /*
        dp[i, j] 表示字符串s的子串s[i, j]是否是回文串
            dp[i, j] = true, 如果子串si...sj是回文串
            dp[i, j] = false, 其他情况
        其他情况包含两种可能：
            s[i, j] 本身不是一个回文串
            i < j，此时s[i, j]本身不合法。
        动态规划的状态转移方程：
        dp[i, j] = dp[i + 1, j - 1] && (s[i] == s[j])
        上述是建立在子串长度大于2的基础上
        边界条件，子串长度为1或2：
        字串长度为1，是回文串
        字串长度为2，只要两个字符相同，他就是一个回文串
        边界条件：
        dp[i, i] = true
        dp[i, i + 1] = (s[i] == s[i + 1])

        最终的答案为，所有dp[i,j]=true中j-i+1（即字串长度）的最大值。
        注意：在状态转移方程中，我们是从长度较短的字符串向长度较长的字符串进行转移的，因此一定要注意动态规划的循环顺序。

         */
        public string LongestPalindrome_DP(string s)
        {
            int n = s.Length;
            if (n < 2)
                return s;

            int maxLen = 1;
            int begin = 0;
            // dp[i, j] 表示s[i, j]是否是回文串
            var dp = new bool[n, n];
            for (int i = 0; i < n; i++)
                dp[i, i] = true;

            var charArray = s.ToCharArray();
            // 先枚举子串长度
            for(int L = 2; L <= n; L++)
            {
                // 枚举左边界，左边界的上线设置可以宽松些
                for(int i = 0; i < n; i++)
                {
                    // 由L和i可以确定右边界，即j-i+1=L得
                    int j = L + i - 1;
                    // 如果右边界越界，就可以退出当前循环
                    if (j >= n)
                        break;
                    
                    if(charArray[i] != charArray[j])
                    {
                        dp[i, j] = false;
                    }
                    else
                    {
                        if (j - i < 3)
                            dp[i, j] = true;
                        else
                            dp[i, j] = dp[i + 1, j - 1];
                    }

                    // 只要dp[i, L] = true 成立，就表示子串s[i..L]是回文，此时记录回文长度和起始位置
                    if(dp[i, j] && j - i + 1 > maxLen)
                    {
                        maxLen = j - i + 1;
                        begin = i;
                    }
                }
            }
            return s.Substring(begin, maxLen);
        }



        // 516. Longest Palindromic Subsequence
        /*
        对于一个子序列而言，如果它是回文子序列，并且长度大于 2，那么将它首尾的两个字符去除之后，它仍然是个回文子序列。
        因此可以用动态规划的方法计算给定字符串的最长回文子序列。

        dp[i, j] 表示字符串s的下标范围[i, j]内的最长回文子序列长度。
        只有当0 < i < j < n时，才会有dp[i,j] > 0 否则dp[i,j] = 0.
        dp[i,i] = 1，长度为1的子序列都是回文子序列
        i<j时
        s[i] == s[j]： dp[i,j] = dp[i+1,j-1] + 2

        s[i] != s[j]： max(dp[i+1,j], dp[i,j-1])，因为s[i]和s[j]不可能同时作为同一个回文子序列的首尾。

        注意，状态转移方程都是从长度较短的子序列向长度较长的子序列转移，因此需要注意动态规划的循环顺序。
        求dp[i,..]时，需要知道dp[i+1,...]的值，因此，i从大到小循环，即for(i = n-1; i >= 0; i--)
        求dp[..,j]时，需要知道dp[...,j-1]的值，因此，j从小到达循环，接for(j = i+1; j < n; j++)
        为什么j从i+1开始而不从i开始，因为j==i时，dp[i,i]=1
        */

        public int LongestPalindromeSubseq_DP(string s)
        {
            int n = s.Length;
            var dp = new int[n, n];
            for(int i = n - 1; i >= 0; i--)
            {
                dp[i, i] = 1;
                var c1 = s[i];
                for(int j = i + 1; j < n; j++)
                {
                    var c2 = s[j];
                    if(c1 == c2)
                    {
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j + 1]);
                    }
                }
            }
            return dp[0, n - 1];
        }
    }
}
