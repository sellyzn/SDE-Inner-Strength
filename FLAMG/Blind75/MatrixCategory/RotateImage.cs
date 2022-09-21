using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.MatrixCategory
{
    internal class RotateImage
    {
        // 48. Rotate Image
        /*
         * n * n
         
        1 2 3        7 4 1
        4 5 6   =>   8 5 2
        7 8 9        9 6 3

                 翻转
        第一行元素 ==> 倒数第一列
        第二行元素 ==> 倒数第二列

        对于矩阵中第i行的第j个元素，在旋转后，它出现在倒数第i列的第j个位置。

                          旋转后新位置
        matrix[row][col]  ==========> matrix[col][n - row - 1]     旋转公式


        temp = matrix[col][n-row-1]
        matrix[col][n-row-1] = matrix[row][col]

        matrix[col][n-row-1]经过旋转后会到哪个位置？

        row = col, col = n - row - 1, 带入旋转公式得：
        matrix[n-row-1][n-col-1] = matrix[col][n-row-1]

        temp=matrix[n−row−1][n−col−1]
        matrix[n−row−1][n−col−1]=matrix[col][n−row−1]
        matrix[col][n−row−1]=matrix[row][col]

        再重复一次之前的操作，matrix[n−row−1][n−col−1] 经过旋转操作之后会到哪个位置呢


        matrix[n−col−1][row]=matrix[n−row−1][n−col−1]​   	​

        temp=matrix[n−col−1][row]
        matrix[n−col−1][row]=matrix[n−row−1][n−col−1]
        matrix[n−row−1][n−col−1]=matrix[col][n−row−1】
        matrix[col][n−row−1]=matrix[row][col]
​
  
        再来一次！matrix[n−col−1][row] 经过旋转操作之后回到哪个位置呢
        matrix[row][col]=matrix[n−col−1][row]
                回到了最初的起点matrix[row][col]，也就是说
  
        matrix[row][col]
        matrix[col][n−row−1]
        matrix[n−row−1][n−col−1]
        matrix[n−col−1][row]
        ​
 
        这四项处于一个循环中，并且每一项旋转后的位置就是下一项所在的位置！因此我们可以使用一个临时变量 \textit{temp}temp 完成这四项的原地交换：

        temp=matrix[row][col]
        matrix[row][col]=matrix[n−col−1][row]
        matrix[n−col−1][row]=matrix[n−row−1][n−col−1]
        matrix[n−row−1][n−col−1]=matrix[col][n−row−1]
        matrix[col][n−row−1]=temp


         */

        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for(int i = 0; i < n / 2; i++)
            {
                for(int j = 0; j < (n + 1) / 2; j++)
                {
                    // {i,j}-->{j,n-1-i}-->{n-1-i,n-1-j}-->{n-1-j,i}--> {i,j}
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
