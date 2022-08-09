using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class FindResultantArrayAfterRemovingAnagrams
    {
        // 题目要求的是words[i-1] 与words[i]为anagram，并不是找出所有的anagram去重
        public IList<string> RemoveAnagrams(string[] words)
        {
            var res = new List<string>();
            //var set = new HashSet<string>();
            var pre = "";
            for(int i = 0; i < words.Length; i++)
            {
                var wordArray = words[i].ToCharArray();
                Array.Sort(wordArray);
                var newStr = new string(wordArray);
                if (newStr.Equals(pre))
                    continue;
                else
                {
                    res.Add(words[i]);
                    pre = newStr;
                }
            }
            return res;
        }

        //以下方法针对该示例会报错
        // Input:["a","b","a"]
        // Output:["a","b"]
        // Expected:["a","b","a"]
        public IList<string> RemoveAnagramsError(string[] words)
        {
            var res = new List<string>();
            var set = new HashSet<string>();
            foreach (var word in words)
            {
                var wordArray = word.ToCharArray();
                Array.Sort(wordArray);
                var newStr = new string(wordArray);
                if (!set.Contains(newStr))
                {
                    res.Add(word);
                    set.Add(newStr);
                }
                else
                {
                    continue;
                }
            }
            return res;
        }
    }
}
