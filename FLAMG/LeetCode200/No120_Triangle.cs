using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No120_Triangle
    {
        /// <summary>
        /// dp[i,j]: 从三角形底部走到位置(i, j)的最小路径和。这里的位置(i, j)是指三角形中第i行第j列的位置，均从0开始编号。
        /// j为第i行的元素的下标，第 i 行有i + 1个元素，因此 j 的范围为 [0, i] 
        /// 状态转移方程：
        /// 当 j = 0 时： dp[i,j] = dp[i - 1, 0] + c[i][0]
        /// 当 j = i 时： dp[i,j] = dp[i - 1, i - 1] + c[i][i]
        /// 当 0 < j < i时：dp[i,j] = Min(dp[i - 1, j - 1], dp[i - 1][j]) + c[i][j]
        /// 
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        /// T: O(n^2)
        /// S: O(n^2)
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int n = triangle.Count;
            var dp = new int[n, n];
            dp[0, 0] = triangle[0][0];
            for(int i = 1; i < n; i++)
            {
                // 第i行有i + 1个位置，对应j的范围为[0,i]
                //当j=0时：
                dp[i, 0] = dp[i - 1, 0] + triangle[i][0];
                //当0 < j < i时：
                for(int j = 1; j  < i; j++)
                {
                    dp[i,j] = Math.Min(dp[i - 1, j - 1], dp[i - 1, j]) + triangle[i][j];
                }
                //当j=i时：
                dp[i, i] = dp[i - 1, i - 1] + triangle[i][i];
            }
            // 最终答案为dp[n - 1, 0] 到 dp[n - 1, n - 1]中的最小值。n为三角形的行数。
            int minTotal = dp[n - 1, 0];
            for(int i = 1; i < n; i++)
            {
                minTotal = Math.Min(minTotal, dp[n - 1, i]);
            }
            return minTotal;
        }
       
    }
}
