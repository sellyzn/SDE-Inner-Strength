using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.InternOA
{
    internal class GetSuccessValue
    {
        public static int[] GetSuccessValueSolution(int[] queries, int[] num_viewers)
        {
            // write your code here
            Array.Sort(num_viewers);
            Array.Reverse(num_viewers);
            var result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                var num = queries[i];
                result[i] = 0;
                for (int j = 0; j < num; j++)
                {
                    result[i] += num_viewers[j];
                }

            }
            return result;
        }
    }
}
