using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No151_ReverseWordsInAString
    {
        /// <summary>
        /// Two Pointers
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public string ReverseWords(string s)
        {
            s.Trim();
            if (s == null || s.Length == 0)
                return s;
            var sb = new StringBuilder();
            int i = s.Length - 1, j = i;
            while(i >= 0)
            {
                while(i >= 0 && s[i] != ' ')
                    i--;
                sb.Append(s.Substring(i + 1, j - i)).Append(" ");
                while (i >= 0 && s[i] == ' ')
                    i--;
                j = i;
            }
            return sb.ToString().Trim();
        }
    }
}
