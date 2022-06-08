using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No304_RangeSumQuery2DImmutable
    {
        /// <summary>
        /// Prefix Sum
        /// </summary>
        int[,] sums;  
        public No304_RangeSumQuery2DImmutable(int[][] matrix)
        {
            int m = matrix.Length;
            if(m > 0)
            {
                int n = matrix[0].Length;
                sums = new int[m, n + 1];
                for(int i = 0; i < m; i++)
                {
                    for(int j = 0; j < n; j++)
                    {
                        sums[i, j + 1] = sums[i, j] + matrix[i][j];
                    }
                }
            }
        }
        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            int sum = 0;
            for(int i = row1; i <= row2; i++)
            {
                sum += sums[i, col2 + 1] - sums[i, col1];
            }
            return sum;
        }
    }
}
