using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.MockInterview
{
    internal class MaximumCustomerWealth
    {
        public int MaximumWealth(int[][] accounts)
        {
            int row = accounts.Length;
            if(row == 0)
                return 0;
            int col = accounts[0].Length;
            if (col == 0)
                return 0;
            var maxWealth = 0;
            for (int i = 0; i < row; i++)
            {
                var sum = 0;
                for(int j = 0; j < col; j++)
                {
                    sum += accounts[i][j];
                }
                maxWealth = Math.Max(maxWealth, sum);
            }
            return maxWealth;
        }
    }
}
