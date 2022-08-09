using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No647_PalindromicSubstrings
    {
        /// <summary>
        /// Brute Force
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// T: O(N^3)
        /// S: O(1)
        public int CountSubstrings(string s)
        {
            int count = 0;
            for(int i = 0; i < s.Length; i++)
            {
                for(int j = i; j < s.Length; j++)
                {
                    var str = s.Substring(i, j - i + 1);
                    if(IsPalindrome(str))
                        count++;
                }
            }
            return count;
        }
        public bool IsPalindrome(string s)
        {            
            int left = 0, right = s.Length - 1;
            while(left < right)
            {
                if(s[left] != s[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }

        /// <summary>
        /// DP
        /// dp[i][j]表示从i到j的字符串能否构成回文串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// T: O(N^2)
        /// S: O(N^2)
        public int CountSubstringsDP(string s)
        {
            int n = s.Length, ans = 0;
            if(n <= 0)
                return 0;
            var dp = new bool[n, n];

            // base case: single letter substrings
            for(int i = 0; i < n; i++)
            {
                dp[i, i] = true;
                ans++;
            }

            // base case: double letter substrings
            for(int i = 0; i < n - 1; i++)
            {
                dp[i, i + 1] = (s[i] == s[i + 1]);
                ans += dp[i,i + 1] ? 1 : 0;
            }

            // All other cases:
            for(int len = 3; len <= n; len++)
            {
                for(int i = 0, j = i + len - 1; j < n; i++, j++)
                {
                    dp[i, j] = dp[i + 1, j - 1] && (s[i] == s[j]);
                    ans += dp[i,j] ? 1 : 0;
                }
            }
            return ans;
        }
    }
}
