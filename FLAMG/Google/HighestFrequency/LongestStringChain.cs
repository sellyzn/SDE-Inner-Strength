using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.HighestFrequency
{
    internal class LongestStringChain
    {
        // step1: words按元素字符串长度递增排列
        // step2：IsSubSequence判断是否子序列, 判断a是否是b的前身(predecessor）
        // 状态定义：以word[i]为结尾的最长子序列长度
        // 状态转移： 遍历 j = 1...i-1之间： dp[i] = Max(dp[i], dp[j] + 1)
        public int LongestStrChain(string[] words)
        {
            words = words.OrderBy(x => x.Length).ToArray();
            int n = words.Length;
            var dp = new int[n];
            dp[0] = 1;
            var res = 1;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if (IsSubSequence(words[j], words[i]))
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
                res = Math.Max(res, dp[i]);
            }
            return res;
        }
        public bool IsSubSequence(string a, string b)
        {
            if (a.Length != b.Length - 1)
                return false;
            int index = 0;
            for(int i = 0; i < b.Length && index < a.Length; i++)
            {
                if(a[i] == b[i])
                    index++;
            }
            return index == a.Length;
        }
    }
}
