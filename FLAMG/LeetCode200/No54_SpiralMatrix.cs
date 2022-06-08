using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No54_SpiralMatrix
    {
        /// <summary>
        /// 按层模拟
        /// left, right, top, bottom
        /// 上:(top, left)...(top,right)
        /// 右：(top+1, right)...(bottom,right)
        /// 下：(bottom, right - 1)...(bottom, left + 1)
        /// 左：(bottom, left)...(top + 1, left)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        /// T: O(mn)
        /// S: O(1)
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var order = new List<int>();
            if(matrix == null)
                return order;
            var rows = matrix.Length;
            if (rows == 0)
                return order;
            var columns = matrix[0].Length;
            if (columns == 0)
                return order;

            int left = 0, right = columns - 1, top = 0, bottom = rows - 1;
            while(left <= right && top <= bottom)
            {
                for(int col = left; col <= right; col++)
                {
                    order.Add(matrix[top][col]);
                }
                for(int row = top + 1; row <= bottom; row++)
                {
                    order.Add(matrix[row][right]);
                }
                if(left < right && top < bottom)
                {
                    for(int col = right - 1; col > left; col--)
                    {
                        order.Add(matrix[bottom][col]);
                    }
                    for(int row = bottom; row > top; row--)
                    {
                        order.Add(matrix[row][left]);
                    }
                }
                left++;
                right--;
                top++;
                bottom--;
            }
            return order;
        }
    }
}
