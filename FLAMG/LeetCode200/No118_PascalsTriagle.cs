using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No118_PascalsTriagle
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        /// T: O(numRows ^ 2)
        /// S: O(1), while O(numsRows^2) space is used to store the output, the input and output generally do not count towards the space complexity.
        public IList<IList<int>> Generate(int numRows)
        {
            var triangle = new List<IList<int>>();
            triangle.Add(new List<int>());
            triangle[0].Add(1);
            for(int rowNum = 1; rowNum < numRows; rowNum++)
            {
                var row = new List<int>();
                var preRow = triangle[rowNum - 1];
                row.Add(1);
                for(int j = 1; j < rowNum; j++)
                {
                    row.Add(preRow[j - 1] + preRow[j]);
                }                
                row.Add(1);
                triangle.Add(row);
            }           

            return triangle;
        }
    }
}
