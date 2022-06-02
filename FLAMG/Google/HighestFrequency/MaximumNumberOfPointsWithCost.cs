using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.HighestFrequency
{
    internal class MaximumNumberOfPointsWithCost
    {
        // dp[i][j]表示第i行第j列的元素所能得到的最大分数
        // 遍历第i-1行的所有列，求max(dp[i-1][k] - abs(j-k))
        // dp[i][j] = max{dp[i-1][k] - abs(j - k)} + points[i][j]
        // 最终答案为： dp[m-1][0...n-1]中的最大值
        public long MaxPoints(int[][] points)
        {
            int m = points.Length;
            if(m == 0)
                return 0;
            int n = points[0].Length;
            if (n == 0)
                return 0;
            var dp = new long[m, n];
            long result = int.MinValue;
            for(int j = 0; j < n; j++)
            {
                dp[0, j] = points[0][j];
            }

            for(int i = 1; i < m; i++)
            {                
                for(int j = 0;j < n; j++)
                {
                    long max = 0;       // 注意位置
                    for (int k = 0; k < j; k++)
                    {
                        max = Math.Max(max, dp[i - 1, k] - Math.Abs(j - k));
                    }
                    
                    dp[i, j] = max + points[i][j];
                }
            }
            for(int j = 0; j < n; j++)
            {
                result = Math.Max(result, dp[m - 1, j]); 
            }
            return result;
            
        }

        //优化：dp空间
        // dp[i]的解之和dp[i-1]相关
        public long MaxPoints_OptSpace(int[][] points)
        {
            int m = points.Length;
            if (m == 0)
                return 0;
            int n = points[0].Length;
            if (n == 0)
                return 0;
            var dp = new long[n];
            long result = int.MinValue;
            for (int j = 0; j < n; j++)
            {
                dp[j] = points[0][j];
            }

            for (int i = 1; i < m; i++)
            {
                var tmpDp(); 
                for (int j = 0; j < n; j++)
                {
                    
                    for (int k = 0; k < j; k++)
                    {
                        dp[j] = Math.Max(dp[j], tmpDp[k] + points[i][j] - Math.Abs(j - 1);
                    }

                    
                }
            }
            for (int j = 0; j < n; j++)
            {
                result = Math.Max(result, dp[j]);
            }
            return result;
        }

        // 优化：
        // dp[i][j] = max{dp[i-1][k] - abs(j - k)} + points[i][j]
        //          = max{dp[i-1][k] + k} + points[i][j] - j  -> (j > k, 即在上方左侧)
        //          = max{dp[i-1][k] - k} + points[i][j] + j  -> (j < k, 即在上方右侧)
        // dp[i][j] 出现在这两个方向遍历中，最大的值   ?????

        public long MaxPoints_OPT(int[][] points)
        {
            int m = points.Length;
            if (m == 0)
                return 0;
            int n = points[0].Length;
            if (n == 0)
                return 0;

            var dp = new long[n];
            long result = int.MinValue;

            for (int j = 0; j < n; j++)
            {
                dp[j] = points[0][j];
            }

            for (int i = 1; i < m; i++)
            {                
                long max = int.MinValue;
                long[] row = new long[n];
                // 上一行，大致出现在档期那行选择的列的左侧， 去绝对值 dp[i] + j
                for(int j = 0; j < n; j++)
                {
                    // 从左边遍历
                    max = Math.Max(max, dp[j] + j);
                    row[j] = max + points[i][j] - j;
                    result = Math.Max(result, row[j]);
                }
                max = int.MinValue;
                // 上一行，大致出现在当前行选择的列的右侧，去绝对值 dp[i] - j
                for (int j = n - 1; j >= 0; j--)
                {
                    // 从右边遍历
                    max = Math.Max(max, dp[j] - j);
                    row[j] = Math.Max(row[j], max + points[i][j] + j);
                    result = Math.Max (result, row[j]);

                }
                dp = row;                
            }
            
            for (int j = 0; j < n; j++)
            {
                result = Math.Max(result, dp[j]);
            }
            return result;

        }
    }
}
