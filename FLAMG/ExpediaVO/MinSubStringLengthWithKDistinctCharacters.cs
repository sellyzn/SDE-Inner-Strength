using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class MinSubStringLengthWithKDistinctCharacters
    {
        public int MinLength(string s, int k)
        {
            if (s.Length < k)
                return -1;
            var window = new Dictionary<char, int>();
            int left = 0, right = 0;
            int minLen = int.MaxValue;
            while(right < s.Length)
            {
                // 移动right
                var ch = s[right];
                right++;
                if (window.ContainsKey(ch))
                    window[ch]++;
                else
                    window[ch] = 1;
                
                while(window.Count == k)
                {
                    minLen = Math.Min(minLen, right - left);
                    var del = s[left];
                    left++;
                    if(window[del] > 1)
                        window[del]--;
                    else
                        window.Remove(del);
                }
            }
            return minLen == int.MaxValue ? -1 : minLen;
        }
    }
}
