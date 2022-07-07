using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No131_PalindromePartitioning
    {
        /// <summary>
        /// DP + Backtrack
        /// Backtrack: 
        ///     Choose: choose the potential candidate.
        ///     Constraint: define a constraint that must be satisfied by the chosen candidate.
        ///     Goal: we must define the goal that determines if have found the required solution and we must backtrack.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// T: O()
        /// S: O()
        IList<IList<string>> result = new List<IList<string>>();
        IList<string> ans = new List<string>();
        bool[,] dp;
        int n;
        public IList<IList<string>> Partition(string s)
        {
            n = s.Length;
            dp = new bool[n, n];
            
            for(int i = n - 1; i >= 0; i--)
            {
                for(int j = i + 1; j < n; j++)
                {
                    dp[i, j] = s[i] == s[j] && dp[i + 1, j - 1];
                }
            }
            Backtrack(s, 0);
            return result;
        }
        public void Backtrack(string s, int i)
        {
            if(i == n)
            {
                result.Add(new List<string>(ans));
                return;
            }
            for(int j = i; j < n; j++)
            {
                if (dp[i, j])
                {
                    ans.Add(s.Substring(i, j + 1 - i));
                    Backtrack(s, j + 1);
                    ans.RemoveAt(ans.Count - 1);
                }
            }
        }

        int[,] f;
        public IList<IList<string>> Partition1(string s)
        {
            n = s.Length;
            f = new int[n, n];

            Backtrack1(s, 0);
            return result;
        }
        public void Backtrack1(string s, int i)
        {
            if(i == n)
            {
                result.Add(new List<string>(ans));
                return;
            }
            for(int j = i; j < n; j++)
            {
                if(IsPalindrome(s, i, j) == 1)
                {
                    ans.Add(s.Substring(i, j + 1 - i));
                    Backtrack1(s, j + 1);
                    ans.RemoveAt(ans.Count - 1);
                }
            }
        }
        public int IsPalindrome(string s, int i, int j)
        {
            if(f[i,j] != 0)
            {
                return f[i, j];
            }
            if(i >= j)
            {
                f[i, j] = 1;
            }else if(s[i] == s[j])
            {
                f[i, j] = IsPalindrome(s, i + 1, j - 1);
            }
            else
            {
                f[i, j] = -1;
            }
            return f[i, j];
        }
    }
}
