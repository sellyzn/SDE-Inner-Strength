using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.MockInterview
{
    public class NumberOfPaths
    {
        public int NumOfPathsToDest_DP(int n)
        {
            var matrix = new int[n,n];
            for(int i = 1; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];

                }
            }
            return matrix[n - 1, n - 1];
        }
    }
}
