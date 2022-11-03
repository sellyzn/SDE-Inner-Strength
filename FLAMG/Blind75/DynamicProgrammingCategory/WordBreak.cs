using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.DynamicProgrammingCategory
{
    internal class WordBreak
    {
        // 139. Word Break
        public bool WordBreakI(string s, IList<string> wordDict)
        {
            return DFS(s, 0, new HashSet<string>(wordDict));
        }
        public bool DFS(string s, int startIndex, HashSet<string> wordDict)
        {
            if (startIndex == s.Length)
                return true;
            //foreach (var word in wordDict)
            //{
            //    if(startIndex + word.Length <= s.Length && s.Substring(startIndex, word.Length).Equals(word))
            //    {
            //        return DFS(s, startIndex + word.Length, wordDict);
            //    }
            //}
            for(int end = startIndex + 1; end <= s.Length; end++)
            {
                if (wordDict.Contains(s.Substring(startIndex, end - startIndex)) && DFS(s, end, wordDict))
                    return true;
            }

            return false;
        }
        public bool WordBreak_BFS(string s, IList<string> wordDict)
        {
            var wordDictSet = new HashSet<string>(wordDict);
            var queue = new Queue<int>();
            var visited = new bool[s.Length];
            queue.Enqueue(0);
            while(queue.Count > 0)
            {
                int start = queue.Dequeue();
                if (visited[start])
                    continue;
                for(int end = start; end < s.Length; end++)
                {
                    if(wordDictSet.Contains(s.Substring(start, end - start + 1)))
                    {
                        queue.Enqueue(end + 1);   // end是当前单词结尾的index，而我们需要将新的单词开始的index放入queue
                        if (end == s.Length - 1)
                            return true;
                    }
                }
                visited[start] = true;
            }
            return false;
        }

        // DP
        // dp[i]: 表示字符串s，index从0开始计算，长度为i的子串，能否被分割成句子。
        // dp[0]表示字符串s为空时，能够被wordDict分割成句子。为true。
        // dp[1]表示字符串s.Substring(0,1)，能否被wordDict分割成句子。
        // ...
        // dp[n]表示字符串s能否被wordDict分割成句子。
        public bool WordBreak_DP(string s, IList<string> wordDict)
        {
            var wordDictSet = new HashSet<string>(wordDict);
            var dp = new bool[s.Length + 1];
            dp[0] = true;
            for(int i = 1; i <= s.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if(dp[j] && wordDictSet.Contains(s.Substring(j, i - j + 1)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[s.Length];
        }
    }
}
