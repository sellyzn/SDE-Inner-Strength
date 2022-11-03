using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.BinarySearch
{
    internal class SearchATwoDMatrixII
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            // search from the left-bottom or the top-right location
            // search from left-bottom location, if matrix[i][j] < target, j++, else i--
            var row = matrix.Length;
            if (row == 0)
                return false;
            var col= matrix[0].Length;
            if (col == 0)
                return false;
            var i = row - 1;
            var j = 0;
            while(i >= 0 && j < col)
            {
                if (matrix[i][j] == target)
                    return true;
                else if (matrix[i][j] < target)
                    j++;
                else if (matrix[i][j] > target)
                    i--;
            }
            return false;
        }
    }
}
