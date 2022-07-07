using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No172_FactorialTrailingZeroes
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// T: O(n)
        /// S: O(1)
        public int TrailingZeroes1(int n)
        {
            int count = 0;
            for(int i = 1; i <= n; i++)
            {
                int N = i;
                while(N > 0)
                {
                    if(N % 5 == 0)
                    {
                        count++;
                        N /= 5;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Find number of 5
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// T: O(logn)
        /// S: O(1)
        public int TrailingZeroes(int n)
        {
            int count = 0;
            while(n > 0)
            {
                count += n / 5;
                n /= 5;
            }
            return count;
        }
        
    }
}
