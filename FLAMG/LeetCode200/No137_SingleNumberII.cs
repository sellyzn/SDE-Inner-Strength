using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No137_SingleNumberII
    {
        /// <summary>
        /// HashTable
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public int SingleNumber(int[] nums)
        {
            var freq = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (freq.ContainsKey(num))
                    freq[num]++;
                else
                    freq[num] = 1;
            }
            int ans = 0;
            foreach (var item in freq)
            {
                var num = item.Key;
                var occ = item.Value;
                if(occ == 1)
                {
                    ans = num;
                    break;
                }
            }
            return ans;
        }
        /// <summary>
        /// 依次确定每一个二进制位
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(NlogC), C是元素的数据范围，logC = 32, 遍历0~31个二进制位
        /// S: O(1)
        /// 
        public int SingleNumber1(int[] nums)
        {
            int ans = 0;
            for(int i = 0; i < 32; i++)
            {
                int total = 0;
                foreach (var num in nums)
                {
                    total += (num >> i) & 1;
                }
                if(total % 3 != 0)
                {
                    ans |= (1 << i);
                }
            }
            return ans;
        }

        /// <summary>
        /// 数字电路设计： 有限状态自动机
        /// 异或运算：x^0 = x, x^1 = ~x
        /// 与运算：x&0 = 0, x&1 = x
        /// 
        /// if two == 0:
        ///    if n == 0:
        ///        one = one
        ///    if n == 1:
        ///        one = ~one
        /// if two == 1:
        ///    one = 0

        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public int SingleNumberII(int[] nums)
        {
            int ones = 0, twos = 0;
            foreach(var num in nums)
            {
                ones = ones ^ num & ~twos;
                twos = twos ^ num & ~ones;
            }
            return ones;
        }
    }
}
