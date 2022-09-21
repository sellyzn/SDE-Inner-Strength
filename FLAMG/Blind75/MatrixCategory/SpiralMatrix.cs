using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.MatrixCategory
{
    internal class SpiralMatrix
    {
        // 54. Spiral Matrix
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var order = new List<int>();
            if(matrix == null)
                return order;
            var rows = matrix.Length;
            if(rows == 0)
                return order;
            var cols = matrix[0].Length;
            if (cols == 0)
                return order;
            int left = 0, right = cols - 1, top = 0, bottom = rows - 1;
            while(left <= right && top <= bottom)
            {
                for(int col = left; col <= right; col++)
                    order.Add(matrix[top][col]);
                for (int row = top + 1; row <= bottom; row++)
                    order.Add(matrix[right][row]);
                if(left < right && top < bottom)
                {
                    for (int col = right - 1; col >= left; col--)
                        order.Add(matrix[bottom][col]);
                    for (int row = bottom - 1; row >= top + 1; row--)
                        order.Add(matrix[row][left]);
                }
                left++;
                right--;
                top++;
                bottom--;
            }
            return order;
        }

        // 59. Spiral Matrix II
        public int[][] GenerateMatrix(int n)
        {
            var matrix = new int[n][];
            for(int i = 0; i < n; i++)
                matrix[i] = new int[n];

            int num = 1;
            int left = 0, right = n - 1, top = 0, bottom = n - 1;
            while(left <= right && top <= bottom)
            {
                for(var col = left; col <= right; col++)
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
                    for(var col = right - 1; col >= left; col--)
                    {
                        matrix[bottom][col] = num;
                        num++;
                    }
                    for(var row = bottom - 1; row > = top + 1; row--)
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

        // 885. Spiral Matrix III
        public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
        {
           
          
        }
        
    }
}
