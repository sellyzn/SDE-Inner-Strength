using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No1492_ThekthFactorOfN
    {
        /// <summary>
        /// Brute Force
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public int KthFactor(int n, int k)
        {
            int i = 1;
            int count = 0;
            while(i <= n)
            {
                if(n % i == 0)
                {
                    count++;
                    if (count == k)
                        return i;
                }
                i++;
            }
            return -1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// T: O(sqrt(n))
        /// S: O(1)
        public int KthFactor1(int n, int k)
        {
            int count = 0, factor;
            for(factor = 1; factor * factor <= n; factor++)
            {
                if(n % factor == 0)
                {
                    count++;
                    if(count == k)
                        return factor;
                }
            }
            factor--;
            if (factor * factor == n)
                factor--;
            for(;factor > 0; factor--)
            {
                if(n % factor == 0)
                {
                    count++;
                    if (count == k)
                        return n / factor;
                }
            }
            return -1;
        }
    }
}
