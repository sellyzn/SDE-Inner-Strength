using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No38_CountAndSay
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// T: O(N * M), N为给定的正整数，M为生成的字符串的最大长度
        /// S: O(M)
        public string CountAndSay(int n)
        {            
            string str = "1";
            for(int i = 2; i <= n; i++)
            {
                var sb = new StringBuilder();
                int start = 0, pos = 0;     // 两个指针遍历str，记录相同字符的起始位置和终止位置
                while(pos < str.Length)
                {
                    while (pos < str.Length && str[pos] == str[start])
                        pos++;
                    sb.Append(pos - start).Append(str[start]);
                    start = pos;
                }
                str = sb.ToString();        //每次要更新str
            }

            return str;
        }
    }
}
