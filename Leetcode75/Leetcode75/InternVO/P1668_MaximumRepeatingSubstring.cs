using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.InternVO
{
    internal class P1668_MaximumRepeatingSubstring
    {
        /*
        sequence = "ababc", word = "ab", maxValue = 2
        sequence = "ababc", word = "ba", maxValue = 1
        sequence = "ababc", word = "ac", maxValue = 0
        sequence = "abcab", word = "ab", maxValue = ?


        index1
                |
        a b a b c
        
        index2
            |
        a b

         */
        public int MaxRepeating(string sequence, string word)
        {
            if(sequence == null ||  word == null)
            {
                return 0;
            }
            if(sequence.Length == 0 || word.Length == 0)
            {
                return 0;
            }
            if(sequence.Length > word.Length)
            {
                return 0;
            }
            int index1 = 0;
            int index2 = 0;
            int count = 0;
            while(index1 < sequence.Length)
            {
                while(index1 < sequence.Length && index2 < word.Length)
                {
                    if (sequence[index1] == word[index2])
                    {
                        index1++;
                        index2++;
                    }
                }
                if(index2 == word.Length)
                {
                    count++;                    
                }
                index2 = 0;
            }
            return count;
        }

        /*
                 |-     dp[i - |word|] + 1, valid[i] = 1 ^ i >= |word|
         dp[i] = |      1,                  valid[i] = 1 ^ i < |word|
                 |-     0,                  otherwise
         */
        public int MaxRepeating1(string sequence, string word)
        {
            int n = sequence.Length;
            int m = word.Length;
            if(n < m)
            {
                return 0;
            }
            var dp = new int[n];
            for(int i = m - 1; i < n; i++)
            {
                var valid = true;
                for(int j = 0; j < m; j++)
                {
                    if (sequence[i - m + j + 1] != word[j])
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                {
                    dp[i] = (i == m - 1 ? 0 : dp[i - m]) + 1;
                }
            }
            return dp.Max();
        }
    }
}
