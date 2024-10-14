using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.HashMapSetProblems
{
    internal class P1657_DetermineIfTwoStringsAreClose
    {
        /*
        Dictionary<char, int>  -> key:字符 value:字符个数
        按升序排序
        判断是否一致
        时间：O(nlogn + n)
        空间：O(n)

        */
        public bool CloseStrings(string word1, string word2)
        {
            if(word1.Length != word2.Length)
            {
                return false;
            }
            var dict1 = new Dictionary<char, int>();
            var dict2 = new Dictionary<char, int>();
            foreach(char c in word1)
            {
                if(dict1.ContainsKey(c))
                {
                    dict1[c]++;
                }
                else
                {
                    dict1[c] = 1;
                }
            }
            foreach(char c in word2)
            {
                if (dict2.ContainsKey(c))
                {
                    dict2[c]++;
                }
                else
                {
                    dict2[c] = 1;
                }
                if(!dict1.ContainsKey(c))
                {
                    return false;
                }
            }
            var sortedList1 = dict1.OrderBy(x => x.Value).ToList();
            var sortedList2 = dict2.OrderBy(x => x.Value).ToList(); 
            if(sortedList1.Count != sortedList2.Count)
            {
                return false;
            }
            for(int i = 0; i < sortedList1.Count; i++)
            {
                if (sortedList1[i].Value != sortedList2[i].Value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
