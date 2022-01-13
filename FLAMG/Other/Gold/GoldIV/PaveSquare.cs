using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldIV
{
    public class PaveSquare
    {
        public long GetTotalSchemes(int n)
        {
            if (n <= 2)
                return n;
            var dp = new long[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            for(int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }
    }
}
