using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldIV
{
    public class MinimumPathSum
    {
        /// <summary>
        /// You can only move one step down or right or Lower right at the same time.
        /// </summary>
        /// <param name="grid"></param> m x n grid with integers
        /// <returns></returns> a path from the upper left to the lower right which minimizes the sum of all integers along its path
        public int MinimumPathSumIII(int[][] grid)
        {
            //var dp = new int[1010,1010];
            //int n = grid.Length;
            //int m = grid[0].Length;
            //for (int i = 0; i < n; i++)
            //    for (int j = 0; j < m; j++)
            //    {
            //        if (i == 0 && j == 0) dp[i,j] = grid[0][0];
            //        else if (i == 0) dp[i,j] = dp[i,j - 1] + grid[i][j];
            //        else if (j == 0) dp[i,j] = dp[i - 1,j] + grid[i][j];
            //        else
            //        {
            //            dp[i,j] = Math.Min(dp[i,j - 1] + grid[i][j], dp[i - 1,j] + grid[i][j]);
            //            dp[i,j] = Math.Min(dp[i - 1,j - 1] + grid[i][j], dp[i,j]);
            //        }
            //    }
            //return dp[n - 1, m - 1];

            if (grid == null || grid.Length == 0)
            {
                return -1;
            }

            int rowLength = grid.Length;
            int colLength = grid[0].Length;
            var dp = new int[rowLength,colLength];    // dp[i,j] : the minimum path sum of all integers along the path from [0,0] to [i, j] 从坐标[0,0]到坐标[i,j]，最小路径和

            // initialization
            dp[0,0] = grid[0][0];
            // initialize the first column (col = 0)
            for (int i = 1; i < rowLength; i++)
            {
                dp[i,0] = dp[i - 1,0] + grid[i][0];
            }
            // initialize the first row (row = 0)
            for (int i = 1; i < colLength; i++)
            {
                dp[0,i] = dp[0,i - 1] + grid[0][i];
            }

            // function
            for (int i = 1; i < rowLength; i++)
            {
                for (int j = 1; j < colLength; j++)
                {
                    dp[i,j] = Math.Min(
                        dp[i - 1,j - 1],
                        Math.Min(dp[i,j - 1], dp[i - 1,j])
                    ) + grid[i][j];
                }
            }

            return dp[rowLength - 1,colLength - 1];
        }
    }
}
