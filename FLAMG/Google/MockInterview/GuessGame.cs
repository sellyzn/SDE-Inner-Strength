using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.MockInterview
{
    public class GuessGame
    {
        // DFS + DP
        // dp(i,j) = minimum money required to guess the correct number from range i to j.
        // dp(1, n) = Min((i + MAX(dp(1,i - 1), dp(i + 1, n)))) from all i from 1 to n.
        // why MAX? the worst case cost after guessing i, we do not know where is our solution, the solution can be in sub-problem dp(1,i  - 1) or dp(i + 1, n)
        // thus, we have to prepared for the worst case cost. thus taking max of the cost from sub-problems.
        // base case: dp(i, j) = 0 if i >= j

        // 

        public int GetMoneyAmount(int n)
        {
            int[][] dp = new int[n + 1][];
            for (int i = 0; i <= n; i++)
            {
                dp[i] = new int[n + 1];                
            }
            return DFS(1, n, dp);
        }
        // DFS(start,end): return the minimum amount of money to guarrantee a win regardless of what number i pick from start to end
        // use dp to record the minimum amount of money: dp[start][end]: minimum amount of money to win, choosing a number from start to end
        public int DFS(int start, int end, int[][] dp)
        {
            if (start >= end)
                return 0;
            if (dp[start][end] > 0)
                return dp[start][end];

            var minValue = int.MaxValue;
            for (int i = start; i <= end; i++)
            {
                var lower = i + DFS(start, i - 1, dp);
                var higher = i + DFS(i + 1, end, dp);
                
                minValue = Math.Min(minValue, Math.Max(lower, higher));
            }
            dp[start][end] = minValue;
            return minValue;
        }

        public int GetMoneyAmount_one(int n)
        {
            return DFS_one(1, n);
        }
        public int DFS_one(int start, int end)
        {
            if (start >= end)
                return 0;
            var res = int.MaxValue;
            for (int i = start; i <= end; i++)
            {
                res = Math.Min(res, Math.Max(DFS_one(start, i - 1), DFS_one(i + 1, end)));
            }
            return res;
        }

        public int GetMoneyAmount_I(int n)
        {
            var dp = new int[n + 1][];
            for (int i = 0; i < n + 1; i++)
            {
                dp[i] = new int[n + 1];
            }
            
            for (int len = 2; len < n + 1; len++)
            {
                int l = 1, r = len;
                while(r <= n)
                {
                    var ans = int.MaxValue;
                    for(int i = l; i <= r; i++)
                    {
                        ans = Math.Min(ans, i + Math.Max(dp[l][i - 1], dp[i + 1][r]));
                    }
                    dp[l][r] = ans;
                    l++;
                    r++;
                }
            }
            return dp[1][n];
        }
    }
}
