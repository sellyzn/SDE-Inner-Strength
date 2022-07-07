using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No159_LongestSubstringWithAtMostTwoDistinctCharacters
    {
        public int LengthOfLongestSubstring(string s)
        {
            if(s == null || s.Length == 0)
                return 0;
            int left = 0;
            int maxLength = 0;
            var curLength = 0;
            var set = new HashSet<char>();
            for(int right = 0; right < s.Length; right++)
            {                
                if (!set.Contains(s[right]))
                {
                    set.Add(s[right]);
                    curLength++;                    
                }
                else
                {
                    while(s[left] != s[right])
                    {
                        set.Remove(s[left]);
                        left++;
                    }                    
                    curLength = right - left;
                }
                maxLength = Math.Max(maxLength, curLength);
            }
            return maxLength;
        }

        /// <summary>
        /// Sliding Window, Two Pointers + HashMap
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// T: (N)
        /// S: (N)
        public int LengthOfLongestSubstringTwoDistinct(string s)
        {
            int n = s.Length;
            if (n < 3)
                return n;
            int left = 0, right = 0;
            var dict = new Dictionary<char, int>();
            int maxLength = 0;
            while(right < n)
            {
                if(dict.Count < 3)
                {
                    if (!dict.ContainsKey(s[right]))
                        dict.Add(s[right], right);
                    else
                        dict[s[right]] = right;
                    
                    right++;
                }                
                if(dict.Count == 3)
                {
                    var delIndex = int.MaxValue;
                    foreach (var index in dict.Values)
                    {
                        delIndex = Math.Min(delIndex, index);
                    }
                    dict.Remove(s[delIndex]);
                    left = delIndex + 1;
                }
                maxLength = Math.Max(maxLength, right - left);
            }
            return maxLength;
        }


    }
}
