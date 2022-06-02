using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No59SpiralMatrixII
    {
        /// <summary>
        /// 按层模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// T: O(n^2)
        /// S: O(1)
        public int[][] GenerateMatrix(int n)
        {
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
            }
            int num = 1;
            int left = 0, right = n - 1, top = 0, bottom = n - 1;
            while(left <= right && top <= bottom)
            {
                for(int col = left; col <= right; col++)
                {
                    matrix[top][col] = num;
                    num++;
                }
                for(int row = top + 1; row <= bottom; row++)
                {
                    matrix[row][right] = num;
                    num++;
                }
                if(left < right && top < bottom)
                {
                    for(int col = right - 1; col >= left + 1; col--)
                    {
                        matrix[bottom][col] = num;
                        num++;
                    }
                    for(int row = bottom; row >= top + 1; row--)
                    {
                        matrix[row][left] = num;
                        num++;
                    }
                }
                left++;
                right--;
                top++;
                bottom--;
            }
            return matrix;
        }
    }
}
