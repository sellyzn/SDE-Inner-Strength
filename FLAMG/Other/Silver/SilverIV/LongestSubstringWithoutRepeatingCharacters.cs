using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverIV
{
    public class LongestSubstringWithoutRepeatingCharacters
    {
        //Sliding window
        public int LengthOfLongestSubstring(string s)
        {
            if (s == null || s.Length == 0)
                return 0;
            Dictionary<char, int> window = new Dictionary<char, int>();
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
                    char d = s[left];
                    left++;
                    window[d]--;
                }
                res = Math.Max(res, right - left);
            }
            return res;
        }

        public string MinWindow(string s, string t)
        {
            var need = new Dictionary<char, int>();
            var window = new Dictionary<char, int>();
            foreach (var ch in t)
            {
                if (need.ContainsKey(ch))
                    need[ch]++;
                else
                    need[ch] = 1;
            }

            int left = 0, right = 0;
            var valid = 0;
            int start = 0, len = int.MaxValue;
            while(right < s.Length)
            {
                var c = s[right];
                right++;
                if (need.ContainsKey(c))
                {
                    if (window.ContainsKey(c))
                        window[c]++;
                    else
                        window[c] = 1;
                    if (window[c] == need[c])
                        valid++;
                }
                while(valid == need.Count)
                {
                    if(right - left < len)
                    {
                        start = left;
                        len = right - left;
                    }
                    var d = s[left];
                    left++;
                    if (need.ContainsKey(d))
                    {
                        if (window[d] == need[d])
                            valid--;
                        window[d]--;
                    }                       
                }
            }
            return len == int.MaxValue ? "" : s.Substring(start, len);
        }

        public int LongestLength(string s)
        {
            if (s == null || s.Length == 0)
                return 0;
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
                    char d = s[left];
                    left++;
                    window[d]--;
                }
                res = Math.Max(res, right - left);
            }
            return res;
        }

    }
}
