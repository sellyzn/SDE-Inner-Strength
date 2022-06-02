using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No73SetMatrixZeroes
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// T: O(MN)
        /// S: O(M + N)
        public void SetZeroes(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            var zeroX = new HashSet<int>();
            var zeroY = new HashSet<int>();
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        zeroX.Add(i);
                        zeroY.Add(j);
                    }                        
                }
            }
            for (int i = 0; i < m; i++)
            {
                if (zeroX.Contains(i))
                {
                    for(int j = 0; j < n; j++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
            for(int j = 0; j < n; j++)
            {
                if (zeroY.Contains(j))
                {
                    for(int i = 0; i < m; i++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }            
        }
    }
}
