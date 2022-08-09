using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No135_Candy
    {
        /// <summary>
        /// Two time Traverse
        /// 1. traverse from left to right
        /// 2. traverse from right to left
        /// 
        /// </summary>
        /// <param name="ratings"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public int Candy(int[] ratings)
        {
            if (ratings == null || ratings.Length == 0)
                return 0;
            if (ratings.Length == 1)
                return 1;

            int n = ratings.Length;
            var left = new int[n];
            var right = new int[n];
            left[0] = 1;
            right[n - 1] = 1;
            for (int i = 1; i < n; i++)
            {
                if (ratings[i] > ratings[i - 1])
                    left[i] = left[i - 1] + 1;
                else
                    left[i] = 1;
            }
            var ret = left[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                    right[i] = right[i + 1] + 1;
                else
                    right[i] = 1;
                ret += Math.Max(left[i], right[i]);
            }
            return ret;
        }
    }
}
