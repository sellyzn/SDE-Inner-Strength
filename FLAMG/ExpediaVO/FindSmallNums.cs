using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class FindSmallNums
    {
        /// <summary>
        /// 遍历B中每一个值Bi，求A中比Bi小的数有几个
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        /// T: O((m + n)logm), m is the length of A, n is the length of B
        /// S: O(1), if we consider the result in it, it will be O(n)
        public int[] FindSmalls(int[] A, int[] B)
        {
            // Edge case: A, B is null            

            Array.Sort(A);
            var result = new int[B.Length];
            for(int i = 0; i < A.Length; i++)
            {
                result[i] = FindSmallEqualElementsNums(A, B[i]);
            }
            return result;
        }
        /*
         *           l
         * A: [1,2,3,4,6,7], target: 4
         *               r
         */
        public int FindSmallEqualElementsNums(int[] A, int target)
        {
            int left = 0, right = A.Length - 1;
            while(left < right)
            {
                int mid = left + (right - left) / 2;
                if(A[mid] <= target)
                    left = mid + 1;
                else if(A[mid] > target)
                    right = mid - 1;
            }
            return left;
        }
    }
}
