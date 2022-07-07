using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No186_ReverseWodsInAStringII
    {
        /// <summary>
        /// Two Pointers
        /// </summary>
        /// <param name="s"></param>
        /// T: O(N)
        /// S: O(1)
        public void ReverseWords(char[] s)
        {
            if (s == null || s.Length == 0)
                return;
            int i = 0, j = s.Length - 1;
            while(i < j)
            {
                var ch = s[i];
                s[i] = s[j];
                s[j] = ch;
                i++;
                j--;
            }
            i = 0;
            j = 0;
            while(j < s.Length)
            {
                while (j < s.Length && s[j] != ' ')
                    j++;
                int left = i, right = j - 1;
                while(left < right)
                {
                    var ch = s[left];
                    s[left] = s[right];
                    s[right] = ch;
                    left++;
                    right--;
                }
                while (j < s.Length && s[j] == ' ')
                    j++;
                i = j;
            }
        }
    }
}
