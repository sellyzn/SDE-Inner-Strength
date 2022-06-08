using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No50_Powxn
    {
        /// <summary>
        /// 快速幂 + 递归
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        /// T: O(logn)， 即为递归的层数
        /// S: O(logn)
        public double MyPow(double x, int n)
        {
            long N = n;
            return N >= 0 ? QuickMul(x, N) : 1.0 / QuickMul(x, -N);
        }
        /// <summary>
        /// N >= 0
        /// x ^ N: 
        /// N为偶数： [x ^ (N/2)] * [x ^ (N/2)]
        /// N为奇数: [x ^ (N/2)] * [x ^ (N/2)] * x
        /// </summary>
        /// <param name="x"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public double QuickMul(double x, long N)
        {
            if (N == 0)
                return 1.0;
            double y = QuickMul(x, N / 2);
            return N % 2 == 0 ? y * y : y * y * x;
        }
    }
}
