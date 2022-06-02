using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No63UniquePathsII
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        /// T: O(MN)
        /// S: O(MN)
        public int UniquePathWithObstacles(int[][] obstacleGrid)
        {
            int rows = obstacleGrid.Length;
            int columns = obstacleGrid[0].Length;
            var dp = new int[rows, columns];
            for(int i = 0; i < rows; i++)
            {
                if (obstacleGrid[i][0] == 1)
                    break;
                dp[i, 0] = 1;
            }
            for(int i = 0;i < columns; i++)
            {
                if (obstacleGrid[0][i] == 1)
                    break;
                dp[0,i] = 1;
            }

            dp[0, 0] = obstacleGrid[0][0] == 0 ? 1 : 0;
            for(int i = 1; i < rows; i++)
            {
                for(int j = 1; j < columns; j++)
                {
                    dp[i, j] = obstacleGrid[i][j] == 1 ? 0 : dp[i, j - 1] + dp[i - 1, j];
                }
            }
            return dp[rows - 1, columns - 1];
        }
        
    }
}
