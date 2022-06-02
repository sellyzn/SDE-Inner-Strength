using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.DynamicProgramming
{
    internal class MinimumPathSum
    {
        public int MinPathSum(int[][] grid)
        {
            // dp[i,j]: from start point (0, 0) to point (i, j), the minimum sum of all numbers along its path.
            // dp[i,j] = Min(dp[i, j - 1], dp[i - 1, j]) + grid[i - 1][j - 1]
            // dp[m + 1, n + 1]

            // dp
            if (grid == null)
                return -1;
            var m = grid.Length;
            if (m == 0)
                return -1;
            var n = grid[0].Length;
            if (n == 0)
                return -1;
            var dp = new int[m, n];
            //initialization
            dp[0, 0] = grid[0][0];    
            //initialize the first column
            for (var i = 1; i < m; i++) 
                dp[i,0] = dp[i - 1, 0] + grid[i][0];
            // initialize the first row
            for (int j = 1; j < n; j++)
                dp[0,j] = dp[0,j - 1] + grid[0][j];

            // function
            for(int i = 1;i < m; i++)
            {
                for(int j = 1;j < n; j++)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
                }
            }
            return dp[m - 1, n - 1];
        }
    }
}
