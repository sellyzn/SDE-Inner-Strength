using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.InternVO
{
    internal class P242_ValidAnagram
    {
        /*
        查看s中的字符及其个数与t中的字符及其个数是否一样。
        Dictionary<char, int>来帮助统计。
        一次遍历统计s中字符的个数，一次遍历t来消除dict中字符的个数。
        若s和t是anagram，则最终dict中元素全部消除，即Count为0.
        时间：O(n)
        空间：O(1),如果只有小i写字母，即只有26个字母，为常数空间.
         */
        public bool IsAnagram(string s, string t)
        {
            var dict = new Dictionary<char, int>();
            for(int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]]++;
                }
                else
                {
                    dict[s[i]] = 1;
                }
            }
            for(int i = 0;i < t.Length;i++)
            {
                if (dict.ContainsKey(t[i]))
                {
                    dict[t[i]]--;
                    if (dict[t[i]] == 0)
                    {
                        dict.Remove(t[i]);
                    }
                }
                else
                {
                    return false;
                }
            }
            if(dict.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Leetcode 49： Group Anagrams
        /*
        数据结构：Dictionary<string,IList<string>>
        遍历一遍strs：
            对每个str进行排序：string转化成array->array, ToCharArray() --> 排序，Array.Sort(strArr) --> array转换成string， new string(strArr)
            添加str到对应的list中： 1，如果map中包含str对应的key，则获取对应的list，即map[key],如果不包含，则新建一个list， new List<string>(). 2. 将key添加到list。3.更新map[key] = list。
            return: new List<IList<string>>(map.Values)
        时间：(n)
        空间：O(n)
         */
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            //var result = new List<IList<string>>();
            //if(strs.Length == 0)
            //{
            //    result.Add(new List<string>());
            //    return result;
            //}
            //if(strs.Length == 1)
            //{                
            //    result[0].Add(strs[0]);
            //    return result;
            //}
            //var index = 0;
            //var flag = new bool[strs.Length];
            //for(int i = 0; i < flag.Length; i++)
            //{
            //    flag[i] = false;
            //}

            //for(int i = 0; i < strs.Length;i++)
            //{
            //    if (!flag[i])
            //    {
            //        result[index].Add(strs[i]);
            //        flag[i] = true;
            //        for(int j = i + 1; j < strs.Length; j++)
            //        {
            //            if (IsAnagram(strs[i], strs[j]))
            //            {
            //                result[index].Add(strs[j]);
            //                flag[j] = true;
            //            }
            //        }
            //        index++;
            //    }                
            //}
            //return result;
            //

            var map = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                var strArr = str.ToCharArray();
                Array.Sort(strArr);
                var key = new string(strArr);
                IList<string> list;
                if(map.ContainsKey(key))
                    list = map[key];
                else
                    list = new List<string>();
                list.Add(str);
                map[key] = list;
            }
            return new List<IList<string>>(map.Values);
        }


        // Amazon VO:
        // 给一个word list：[I, love, phone], 问能不能组成一个字符串，不能重复用word.
        // Ilovephone->True; iloveiphone->False. (类似leetcode 139： Word Break)
        public bool CanConstruct(IList<string> words, string s)
        {
            var visited = new bool[words.Count];
            for(int i = 0; i < words.Count; i++)
            {
                visited[i] = false;
            }
            var map = new Dictionary<string, int>();
            for (int i = 0; i < words.Count; i++) 
            {
                map.Add(words[i], i);
            }
            int left = 0, right = 0;
            while(right < s.Length)
            {
                var str = s.Substring(left, right - left + 1);
                if (map.ContainsKey(str))
                {
                    if (visited[map[str]])
                        return false;
                    else
                        visited[map[str]] = true;
                    right++;
                    left = right;
                }
                else
                {
                    right++;
                }
            }
            return left == s.Length;
        }

    }
}
