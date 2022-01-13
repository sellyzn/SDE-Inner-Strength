using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzeI
{
    public class FindTheNumbersII
    {
        public int GetSum(int A, int B)
        {
            int sum = 0;
            for (int i = A; i <= B; i++)
            {
                if (i % 3 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

    }
}
