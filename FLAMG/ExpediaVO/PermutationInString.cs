using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class PermutationInString
    {
        /*
        s1: ab
        s1.Length: 2

        valid: 2 
        window: [l,r)
                  l
        s2: eidbaooo
        s2: eidboaoo
                    r

        T: O(N), N is the length of s2
        s: O(M + N)， M is the length of s1, N is the length of s2
            
                  l
        s2: eidbaooo
        s2: eidboaoo
                    r
        need:   {{a,1}, {b,1}}
        window: {{o,2})}
        valid : 0

        */
        public bool CheckInclusion(string s1, string s2)
        {
            // s2 contains s1
            // Corner Case
            if (s1.Length > s2.Length)
                return false;
            if(s1 == null || s1.Length == 0)
                return false;
            if (s2 == null || s2.Length == 0)
                return false;

            // common case
            var need = new Dictionary<char, int>();
            var window = new Dictionary<char, int>();

            foreach (char c in s1)
            {
                if(need.ContainsKey(c))
                    need[c]++;
                else
                    need[c] = 1;
            }

            int left = 0, right = 0;
            int valid = 0;
            while(right < s2.Length)
            {
                var cur = s2[right];
                right++;
                if(window.ContainsKey(cur))
                    window[cur]++;
                else
                    window[cur] = 1;
                if (need.ContainsKey(cur) && need[cur] == window[cur])
                    valid++;
                while(right - left == s1.Length)
                {
                    if (valid == need.Count)
                        return true;
                    var del = s2[left];
                    left++;
                    if (need.ContainsKey(del) && need[del] == window[del])
                        valid--;
                    if(window[del] > 1)
                        window[del]--;
                    else
                        window.Remove(del);
                }
            }
            return false;
        }
    }
}
