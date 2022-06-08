using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No91_DecodeWays
    {
        public int NumDecodeings(string s)
        {
            if (s == null || s.Length == 0)
                return 1;
            int n = s.Length;
            var dp = new int[n + 1];
            dp[0] = 1;
            for(int i = 1; i <= n; i++)
            {
                if (s[i - 1] == '0')
                    dp[i] = dp[i - 1];
                if (i > 1 && s[i - 2] != '0' && ((s[i - 2] - '0') * 10 + s[i - 1] - '0') <= 26)
                    dp[i] += dp[i - 2];     ////?????????????????????/
            }
            return dp[n];
        }
    }
}
