using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.MockInterview
{
    internal class AddArrayForm
    {
        public IList<int> AddToArrayForm(int[] num, int k)
        {
            int length = num.Length;
            int index = num.Length - 1;
            int sum = 0, carry = 0;
            var result = new List<int>();
            while (index >= 0)
            {
                sum = num[index] + k % 10 + carry;
                carry = sum / 10;
                result.Insert(0, sum % 10);
                k /= 10;
                index--;
            }
            while (k > 0)
            {
                sum = k % 10 + carry;
                carry = sum / 10;
                result.Insert(0, sum % 10);
                k /= 10;
            }
            if (carry > 0)
                result.Insert(0, carry);
            return result;
        }

        public int[][] MatrixBlockSum(int[][] mat, int k)
        {
            int row = mat.Length;
            if (row == 0)
                return new int[0][];
            int col = mat[0].Length;
            if (col == 0)
                return new int[0][];

            var result = new int[mat.Length][];
            for (int i = 0; i < mat.Length; i++)
            {
                result[i] = new int[mat[i].Length];
            }

            for(int i = 0;i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    var minR = i - k >= 0 ? i - k : 0;
                    var maxR = i + k <= row - 1 ? i + k : row - 1;
                    var minC = j - k >= 0 ? j - k : 0;
                    var maxC = j + k <= col - 1 ? j + k : col - 1;
                    result[i][j] = GetSum(mat, minR, maxR, minC, maxC);
                }
            }
            return result;
        }
        public int GetSum(int[][] mat, int minR, int maxR, int minC, int maxC)
        {
            var sum = 0;
            for(int i = minR; i <= maxR; i++)
            {
                for(int j = minC; j <= maxC; j++)
                {
                    sum += mat[i][j];
                }
            }
            return sum;
        }

        public int[][] MatrixBlockSum_PrefixSum(int[][] mat, int k)
        {
            // get the prefix sum of the 2-D array: prefixSum[m + 1][n + 1]
            // prefixSum[i][j] = prefixSum[i - 1][j] + prefixSum[i][j - 1] - prefixSum[i - 1][j - 1] + mat[i - 1][j - 1]
            // get the range of the subarray block 
            // r: minR, maxR
            // c: minC, maxC
            // result[i][j] = prefixSum[marR + 1][maxC + 1] - prefixSum[maxR + 1][minC] - prefixSum[minR][maxC + 1] + prefixSum[minR][minC]

            int m = mat.Length, n = mat[0].Length;
            var res = new int[m][];
            for(int i = 0; i < m; i++)
            {
                res[i] = new int[n];
            }

            var prefixSum = new int[m + 1, n + 1];

            for(int i = 1; i <= m; i++)
            {
                for(int j = 1; j <= n; j++)
                {
                    prefixSum[i, j] = prefixSum[i - 1, j] + prefixSum[i, j - 1] - prefixSum[i - 1, j - 1] + mat[i - 1][j - 1];
                }
            }

            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    var minR = Math.Max(0, i - k);
                    var maxR = Math.Min(m - 1, i + k);
                    var minC = Math.Max(0, j - k);
                    var maxC = Math.Min(n - 1, j + k);
                    res[i][j] = prefixSum[maxR + 1, maxC + 1] - prefixSum[maxR + 1, minC] - prefixSum[minR, maxR + 1] + prefixSum[minR, minC];
                }
            }
            return res;
        }
    }
}
