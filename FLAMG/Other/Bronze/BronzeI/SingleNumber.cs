using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzeI
{
    public class SingleNumber
    {
        public int SingleNumber1(int[] A)
        {
            int res = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                res ^= A[i];
            }
            return res;
        }
    }
}
