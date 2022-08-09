using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No3_LongestSubstringWithoutRepeatingCharacters
    {
        /// <summary>
        /// Sliding Window
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            var window = new Dictionary<char, int>();
            int left = 0, right = 0;
            int res = 0;
            while(right < s.Length)
            {
                char c = s[right];
                right++;
                if (window.ContainsKey(c))
                    window[c]++;
                else
                    window[c] = 1;

                while(window[c] > 1)
                {
                    var d = s[left];
                    left++;
                    window[d]--;
                }
                res = Math.Max(res, right - left);
            }
            return res;
        }
    }
}
