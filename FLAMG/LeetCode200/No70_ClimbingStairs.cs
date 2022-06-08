using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No70_ClimbingStairs
    {
        /// <summary>
        /// Dynamic Programming
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public int Climbstairs(int n)
        {
            if (n == 1)
                return 1;
            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            for(int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }
        /// T: O(N)
        /// S: O(1)
        public int ClimbStairs_OptS(int n)
        {
            if (n == 1)
                return 1;
            if (n == 2)
                return 2;
            int dp1 = 1, dp2 = 2;
            int dp = 1;
            for (int i = 3; i <= n; i++)
            {
                dp = dp1 + dp2;
                dp1 = dp2;
                dp2 = dp;
            }
            return dp;
        }
    }
}
