using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No3LongestSubstringWithoutRepeatingCharacters
    {
        // brute force
        // T: O(N^2), we use 2 for loops
        // S: O(N), we use a set, the length of set is most s.Length

        public int LengthOfLongestSubstring(string s)
        {
            var maxLength = int.MinValue;
            if (s == null || s.Length == 0)
                return 0;
            for (int i = 0; i < s.Length; i++)
            {
                var set = new HashSet<int>();
                var curLength = 0;
                for (int j = i; j < s.Length; j++)
                {
                    if (!set.Contains(s[j]))
                    {
                        set.Add(s[j]);
                        curLength++;
                    }
                    else
                    {
                        break;
                    }
                    maxLength = Math.Max(maxLength, curLength);

                }
            }
            return maxLength;
        }


        // Sliding Window
        // Note the index, left < s.Length, right < s.Length
        // dict.Remove(s[left])

        // T: O(N), we traverse s for one time
        //S: O(N), we use a dictionary to store, the count dict is most N

        public int LengthOfLongestSubstring_SlidingWindow(string s)
        {
            var maxLength = int.MinValue;
            if (s == null || s.Length == 0)
                return 0;
            int left = 0, right = 0;
            while (left < s.Length && right < s.Length)
            {
                right = left;
                var dict = new Dictionary<char, int>();
                var curLength = right - left;
                while (right < s.Length && !dict.ContainsKey(s[right]))
                {
                    dict.Add(s[right], right);
                    curLength++;
                    right++;
                    maxLength = Math.Max(maxLength, curLength);
                }
                while (left < s.Length && right < s.Length && dict.ContainsKey(s[right]))
                {
                    dict.Remove(s[left]);
                    left++;
                }
            }
            return maxLength;
        }
        

    }
}
