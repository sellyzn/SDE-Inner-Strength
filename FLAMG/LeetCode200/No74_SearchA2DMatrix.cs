using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No74_SearchA2DMatrix
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        /// T: O(m+n)
        /// S: O(1)
        public bool SearchMatrix(int[][] matrix, int target)
        {
            // search from left-bottom or right-top
            int m = matrix.Length;
            int n = matrix[0].Length;
            int i = m - 1, j = 0;
            while(i >= 0 && j < n)
            {
                if (matrix[i][j] == target)
                    return true;
                else if (matrix[i][j] > target)
                    i--;
                else if(matrix[i][j] < target)
                    j++;
            }
            return false;              
        }
    }
}
