using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class CheckIfEveryRowAndColumnContainsAllNumbers
    {
        public bool CheckValid(int[][] matrix)
        {
            var n = matrix.Length;
            var rows = new int[n, n];
            var columns = new int[n, n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    var index = matrix[i][j] - 1;
                    rows[i, index]++;
                    columns[j, index]++;
                    if (rows[i, index] > 1 || columns[j, index] > 1)
                        return false;
                }
            }
            return true;
        }


        /*
         matrix: 1 2 3
                 3 1 2
                 2 3 1

        rowSet: 
        columnet: 
         
         */
        public bool CheckValid1(int[][] matrix)
        {
            var n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                var rowSet = new HashSet<int>();
                var columnSet = new HashSet<int>();
                for( int j = 0; j < n; j++)
                {
                    rowSet.Add(matrix[i][j]);
                    columnSet.Add(matrix[j][i]);
                }
                if (rowSet.Count != n || columnSet.Count != n)
                    return false;
            }
            return true;
        }
    }
}
