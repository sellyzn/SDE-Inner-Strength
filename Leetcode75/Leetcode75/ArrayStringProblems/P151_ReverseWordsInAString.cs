using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.ArrayStringProblems
{
    internal class P151_ReverseWordsInAString
    {
        /*
        双指针
        倒序遍历字符串，记录单词的左右边界索引，没确定一个单词的边界，就将其添加到res.
        time: O(n)
        space: O(n)
         */
        public string ReverseWords(string s)
        {
            s = s.Trim();
            var res = new StringBuilder();
            int right = s.Length - 1, left = right;
            while(left >= 0)
            {
                while(left >= 0 && s[left] != ' ')
                {
                    left--;
                }
                res.Append(s.Substring(left + 1, right - left)).Append(' ');
                while(left >= 0 && s[left] == ' ')
                {
                    left--;
                }
                right = left;
            }
            return res.ToString().Trim();
        }        
    }
}
