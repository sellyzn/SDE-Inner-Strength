using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzelII
{
    public class SortIntegers
    {
        //Bubble Sort
        public void SortIntegers1(int[] A)
        {
            if (A == null || A.Length == 0)
                return;
            for(int i = A.Length - 1; i >= 0; i--)
            {
                for(int j = 0; j < i; j++)
                {
                    if(A[j] > A[j + 1])
                    {
                        int tmp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = tmp;
                    }
                }
            }
        }
    }
}
