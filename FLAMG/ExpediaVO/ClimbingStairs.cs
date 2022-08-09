using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class ClimbingStairs
    {
        // n == 1, result = 1;
        // n == 2, result = 1 + 1 = 2;
        // n == 3, result = f(1) + f(2);
        // n == 4, result = f(2) + f(3);
        // ...
        // n == n, f(n) = f(n - 2) + f(n - 1)
        public int ClimbStairs(int n)
        {
            if (n == 1)
                return 1;
            var dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 2;
            for(int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        public int ClimbStairsOp(int n)
        {
            if (n == 1)
                return 1;
            var preStep1 = 2;
            var preStep2 = 1;
            int result = 2;
            for(int i = 3; i <= n; i++)
            {
                result = preStep1 + preStep2;
                preStep2 = preStep1;
                preStep1 = result;
            }
            return result;
        }
    }
}
