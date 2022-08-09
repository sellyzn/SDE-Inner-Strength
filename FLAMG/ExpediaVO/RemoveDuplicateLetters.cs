using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class RemoveDuplicateLetters
    {
        public string RemoveDuplicateLetters(string s)
        {
            var vis = new bool[26];
            var num = new int[26];
            // 记录每个字符对应的频率
            for(int i = 0; i < s.Length; i++)
            {
                num[s[i] - 'a']++;
            }
            var sb = new StringBuilder();
            for(int i = 0; i < s.Length; i++)
            {

            }
        }
    }
}
