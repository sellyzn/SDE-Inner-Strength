using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.StringCategory
{
    internal class ValidAnagram
    {
        // 242. Valid Anagram
        public bool IsAnagram(string s, string t)
        {
            if(s.Length != t.Length)
                return false;
            var dict = new Dictionary<char, int>();
            foreach (var ch in s)
            {
                if (dict.ContainsKey(ch))
                    dict[ch]++;
                else
                    dict[ch] = 1;
            }
            foreach(var ch in t)
            {
                if (dict.ContainsKey(ch))
                {
                    if(dict[ch] > 1)
                        dict[ch]--;
                    else
                        dict.Remove(ch);
                }
                else
                {
                    return false;
                }
            }
            return dict.Count == 0;
        }

        // 49. Group Anagrams
        // HashMap + Categorize by Sorted String
        public IList<IList<string>> GroupAnagrams1(string[] strs)
        {
            var map = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                var strArr = str.ToCharArray();
                Array.Sort(strArr);
                var key = new string(strArr);
                IList<string> list;
                if (map.ContainsKey(key))
                    list = map[key];
                else
                    list = new List<string>();
                list.Add(str);
                map[key] = list;
            }
            return new List<IList<string>>(map.Values);
        }


        // 266. Palindrome Permutation
        // HashMap
        public bool CanPermutePalindrome(string s)
        {
            var map = new Dictionary<char, int>();
            var flag = false;
            foreach (var ch in s)
            {
                if (map.ContainsKey(ch))
                    map[ch]++;
                else
                    map[ch] = 1;
            }
            foreach (var item in map)
            {
                if (item.Value % 2 == 0)
                    continue;
                else
                {
                    if (flag == false)
                    {
                        flag = true;
                    }
                    else
                        return false;
                }
            }
            return true;
        }


        // 438. Find All Anagrams in a String

        public IList<int> FindAnagrams(string s, string p)
        {
            var need = new Dictionary<char, int>();
            var window = new Dictionary<char, int>();
            var res = new List<int>();
            foreach (var ch in p)
            {
                if(need.ContainsKey(ch))
                    need[ch]++;
                else
                    need[ch] = 1;
            }
            int left = 0, right = 0;
            int valid = 0;
            while(right < s.Length)
            {
                var ch = s[right];
                right++;
                if(window.ContainsKey(ch))
                    window[ch]++;
                else
                    window[ch] = 1;
                if (need.ContainsKey(ch) && need[ch] == window[ch])
                    valid++;
                while(right - left >= p.Length)
                {
                    if (valid == need.Count)
                        res.Add(left);
                    var del = s[left];
                    left++;
                    if (need.ContainsKey(del) && window[del] == need[del])
                        valid--;
                    if(window[del] > 1)
                        window[del]--;
                    else
                        window.Remove(del);
                }
            }
            return res;
        }


        // 2273. Find Resultant Array After Removing Anagrams
        // sorting
        public IList<string> RemoveAnagrams(string[] words)
        {
            var result = new List<string>();
            if(words == null || words.Length == 0)
                return result;
            if(words.Length == 1)
            {
                result.Add(words[0]);
                return result;
            }
            var pre = "";
            for(int i = 0; i < words.Length; i++)
            {
                var wordArr = words[i].ToCharArray();
                Array.Sort(wordArr);
                var newStr = new string(wordArr);
                if (newStr.Equals(pre))
                {
                    continue;
                }
                else
                {
                    result.Add(words[i]);
                    pre = newStr;
                }
            }      
            return result;
        }
}
