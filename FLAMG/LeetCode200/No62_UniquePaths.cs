using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No62_UniquePaths
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        /// T: O(MN)
        /// S: O(MN)
        public int UniquePaths(int m, int n)
        {            
            var dp = new int[m, n];
            dp[0, 0] = 1;
            for (int i = 0; i < m; i++)
                dp[i, 0] = 1;
            for(int i = 0; i < n; i++)
                dp[0, i] = 1;
            for(int i = 1; i < m; i++)
            {
                for(int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i, j - 1] + dp[i - 1, j];
                }
            }
            return dp[m - 1, n - 1];            
        }
        
    }
}
