using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.HighestFrequency
{
    internal class MatricBlockSum
    {
        // 1314. MatrixBlockSum
        // 2-D array prefixSum
        public int[][] MatrixBlockSum(int[][] mat, int k)
        {
            int m = mat.Length, n = mat[0].Length;
            var res = new int[m][];
            for (int i = 0; i < m; i++)
            {
                res[i] = new int[n];
            }

            var prefixSum = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    prefixSum[i, j] = prefixSum[i - 1, j] + prefixSum[i, j - 1] - prefixSum[i - 1, j - 1] + mat[i - 1][j - 1];
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var minR = Math.Max(0, i - k);
                    var maxR = Math.Min(m - 1, i + k);
                    var minC = Math.Max(0, j - k);
                    var maxC = Math.Min(n - 1, j + k);
                    res[i][j] = prefixSum[maxR + 1, maxC + 1] - prefixSum[maxR + 1, minC] - prefixSum[minR, maxC + 1] + prefixSum[minR, minC];
                }
            }
            return res;
        }
    }
}
