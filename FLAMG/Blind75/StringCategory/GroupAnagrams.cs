using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.StringCategory
{
    internal class GroupAnagrams
    {
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

        // 242. Valid Anagram
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            var dict = new Dictionary<char, int>();
            foreach (var ch in s)
            {
                if (dict.ContainsKey(ch))
                    dict[ch]++;
                else
                    dict[ch] = 1;
            }
            foreach (var ch in t)
            {
                if (dict.ContainsKey(ch))
                {
                    if (dict[ch] > 1)
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

        // 2273. Find Resultant Array After Removing Anagrams
        // sorting
        public IList<string> RemoveAnagrams(string[] words)
        {
            var result = new List<string>();
            if (words == null || words.Length == 0)
                return result;
            if (words.Length == 1)
            {
                result.Add(words[0]);
                return result;
            }
            var pre = "";
            for (int i = 0; i < words.Length; i++)
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
}
