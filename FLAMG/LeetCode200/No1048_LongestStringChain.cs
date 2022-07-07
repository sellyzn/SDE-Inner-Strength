using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No1048_LongestStringChain
    {
        /// <summary>
        /// a 是 b 的前身： 在 a 的任何地方添加恰好一个字母，使其编程 b， 那么 a 是 b 的前身（predecessor）。
        /// 例如： a: "abc", b: "abac"  --> true
        ///       a: "cba", b: "bcad"  --> false
        /// 
        /// words按照字符串长度排序
        /// Check函数用于判断字符串b是否是字符串a的前身（前提： b.Length == a.Length - 1）
        /// 状态定义： 以word[i]为结尾的最长子序列长度
        /// 状态转移： 遍历j = 1...i-1之间： dp[i] = max(dp[i], dp[j] + 1)
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int LongestStrChain(string[] words)
        {
            words = words.OrderBy(x => x.Length).ToArray();
            int n = words.Length;
            var dp = new int[n];
            for (int i = 0; i < n; i++)
                dp[i] = 1;
            var res = 1;
            for(int i = 0; i < n; i++)
            {
                for(int j = i - 1; j >= 0; j--)
                {
                    if(words[j].Length == words[i].Length - 1)
                    {
                        if(Check(words[i], words[j]))
                            dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
                res = Math.Max(res, dp[i]);
            }
            return res;
        }
        // check if b is the predsessor of a, b.Length = a.Length - 1
        public bool Check(string a, string b)
        {
            int len = a.Length;
            int i = 0, j = 0;
            while(i < len && j < len - 1)
            {
                if (a[i] == b[j])
                    j++;
                i++;
            }
            return j == len - 1;
        }
    }
}
