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
                        queue.Enqueue(end + 1);   // 新的单词开始的地方
                        if (end == s.Length - 1)
                            return true;
                    }
                }
                visited[start] = true;
            }
            return false;
        }

        // DP

    }
}
