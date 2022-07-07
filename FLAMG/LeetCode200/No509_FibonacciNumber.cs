using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No509_FibonacciNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public int Fib(int n)
        {
            if (n <= 1)
                return n;
            int prev1 = 0, prev2 = 1;
            int current = 0;
            for(int i = 2; i <= n; i++)
            {
                current = prev1 + prev2;
                prev1 = prev2;
                prev2 = current;
            }
            return current;
        }
    }
}
