using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No191NumbersOf1Bits
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// T: O(K), k = 32
        /// S: O(1)
        public int HammingWeight(uint n)
        {
            int bits = 0;
            int mask = 1;
            for(int i = 0; i < 32; i++)
            {
                if((n & mask) != 0)
                    bits++;
                mask <<= 1;
            }
            return bits;
        }
    }
}
