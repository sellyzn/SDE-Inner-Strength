using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.StringCategory
{
    // 647. Palindromic Substrings
    internal class PalindromicSubstrings
    {
        public int CountSubstrings(string s)
        {
            int n = s.Length, ans = 0;
            if(n <= 0)
                return 0;
            var dp = new bool[n, n];
            for(int i = 0; i < n; i++)
            {
                dp[i, i] = true;
                ans++;
            }
            //for(int i = 0; i < n - 1; i++)
            //{
            //    dp[i, i + 1] = s[i] == s[i + 1];
            //    ans += dp[i, i + 1] ? 1 : 0;
            //}
            for(int len = 2; len < n; len++)
            {
                for(int i = n - 1; i >= 0; i--)
                {
                    int j = i + len - 1;
                    if (j > n)
                        break;
                    if (s[i] != s[j])
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
                    dp[i, j] = dp[i + 1, j - 1] && (s[i] == s[j]);
                    ans += dp[i, j] ? 1 : 0;
                    
                }
            }
            return ans;
        }
    }
}
