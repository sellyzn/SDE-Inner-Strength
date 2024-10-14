using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.TwoPointersPorblems
{
    internal class P392_IsSubsequence
    {
        /*
        双指针
        注意谁是谁的子序列，s是t的子序列：
        两个指针indexS和indexT初始值都为0，分别指向s和t
        同时遍历s和t，判断s[indexS]和t[indexT]是否相等，若相等，则移动indexS和indexT, 若不相等，则只移动indexT
        若最后indexS==s.Length，则说明s是t的子序列.
        时间：O(max(m,n))
        空间：O(1)
        */
        public bool IsSubsequence(string s, string t)
        {
            int left = 0, right = 0;
            while(left < s.Length && right < t.Length)
            {
                if (s[left] == t[right])
                    left++;
                right++;
            }
            return left == s.Length;
        }

        // P792: 匹配子序列的单词数
        // 给定字符串s和字符串数组words,返回words[i]中是s的子序列的单词个数。
        public int NumMatchingSubseq(string s, string[] words)
        {
            var pos = new IList<int>[26];
            for(int i = 0; i < 26; i++)
            {
                pos[i] = new List<int>();
            }
            for(int i = 0; i < s.Length; i++)
            {
                pos[s[i] - 'a'] .Add(i);
            }
            var res = words.Length;
            foreach(var word in words)
            {
                if(word.Length > s.Length)
                {
                    res--;
                    continue;
                }
                var p = -1;
                for(int i = 0; i < word.Length; i++)
                {
                    var ch = word[i];
                    if (pos[ch - 'a'].Count == 0 || pos[ch - 'a'][pos[ch - 'a'].Count - 1] <= p)
                    {
                        res--;
                        break;
                    }
                    p = BinarySearch(pos[ch - 'a'], p);
                }
            }
            return res;
        }
        public int BinarySearch(IList<int> list, int target)
        {
            int left = 0, right = list.Count - 1;
            while(left < right)
            {
                var mid = left + (right - left) / 2;
                if (list[mid] > target)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return list[left];
        }


        // 多指针
        //public int NumMatchingSubSeq(string s, string[] words)
        //{
        //    Queue<int[]>[] q = new Queue<int[]>[26];
        //    for(int i = 0; i < 26; i++)
        //    {
        //        q[i] = new Queue<int[]>();
        //    }
        //    for(int i = 0;i < words.Length;i++)
        //    {
        //        q[words[i][0] - 'a'].Enqueue(new int[] { i, 0 });
        //    }
        //}
    }
}
