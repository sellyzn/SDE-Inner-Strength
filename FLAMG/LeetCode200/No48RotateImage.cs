using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No48RotateImage
    {
        /// <summary>
        /// 对于矩阵中第i行的第j个元素，旋转后，它出现在倒数第i列的第j个位置。
        /// matrix[row][col]，旋转后的新位置位matrix[col][n - row - 1]
        /// 即， temp = matrix[col][n - row - 1], matrix[col][n - row - 1] = matrix[row][col]
        /// 
        /// matrix[col][n - row - 1]经过旋转之后到哪个位置？ 
        /// 同样使用上述关键等式，将row = col, col = n - row - 1带入上述等式，得到 matrix[n - row - 1][n - col - 1] = matrix[col][n - row - 1]. 
        /// 同样，直接赋值会覆盖掉matrix[n - row - 1][n - col - 1]，原来的值， 需要临时变量，所以直接使用之前的临时变量temp: 
        /// temp = matrix[n - row - 1][n - col - 1]
        /// matrix[n - row - 1][n - col - 1] = matrix[col][n - row - 1]
        /// matrix[col][n - row - 1] = matrix[row][col]
        /// 
        /// 重复，重复,完成一个循环
        /// 
        /// temp = matrix[row][col]
        /// matrix[row][col] = matrix[n - col - 1][row]
        /// matrix[n - col - 1][row] = matrix[n - row - 1][n - col - 1]
        /// matrix[n - row - 1][n - col - 1] = matrix[col][n - row - 1]
        /// matrix[col][n - row - 1] = matrix[row][col]
        /// 
        /// 
        /// n位偶数时，需要枚举(n/2)*(n/2)个位置
        /// n位偶数时，中心位置经过旋转后位置不变，需要枚举((n - 1) / 2)*((n + 1) / 2)个位置
        /// 
        /// </summary>
        /// <param name="matrix"></param> n * n matrix
        /// T: O(N^2)
        /// S: O(1)
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for(int i = 0; i < n / 2; i++)
            {
                for(int j = 0; j < (n + 1) / 2; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[n - j - 1][i];
                    matrix[n - j - 1][i] = matrix[n - i - 1][n - j - 1];
                    matrix[n - i - 1][n - j - 1] = matrix[j][n - i - 1];
                    matrix[j][n - i - 1] = temp;
                }
            }
        }
    }
}
