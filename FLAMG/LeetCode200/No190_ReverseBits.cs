using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No190_ReverseBits
    {
        public uint ReverseBit(uint n)
        {
            //var sb = new StringBuilder();
            //while(n > 0)
            //{
            //    var num = (uint)n & 1;
            //    sb.Append(num);
            //    n >>= 1;
            //}
            //return uint.Parse(sb.ToString());
            var s = n.ToString();
            int left = 0;
            var reversedStr = new StringBuilder();
            while(left < s.Length)
            {
                reversedStr.Insert(0, s[left]);
                left++;
            }
            return uint.Parse(reversedStr.ToString());
        }
    }
}
