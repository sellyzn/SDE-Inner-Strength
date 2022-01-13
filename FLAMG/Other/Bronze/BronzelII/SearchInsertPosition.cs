using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzelII
{
    public class SearchInsertPosition
    {
        public int SearchIntert(int[] A, int target)
        {
            if (A == null || A.Length == 0 || A[0] >= target)
                return 0;
            if (A[A.Length - 1] < target)
                return A.Length;
            int left = 0, right = A.Length - 1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (A[mid] == target)
                    return mid;
                else if (A[mid] < target)
                    left = mid + 1;
                else if (A[mid] > target)
                    right = mid - 1;
            }
            return left;
        }
    }
}
