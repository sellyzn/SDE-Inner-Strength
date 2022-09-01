using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.StringCategory
{
    internal class VlidParentheses
    {
        // 20. Valid Parentheses
        // Stack
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                    stack.Push(s[i]);
                else
                {
                    if (stack.Count != 0 && ((s[i] == ')' && stack.Peek() == '(') || (s[i] == ']' && stack.Peek() == '[') || (s[i] == '}' && stack.Peek() == '{')))
                        stack.Pop();
                    else
                        return false;
                }
            }
            return stack.Count == 0;
        }


        // 22. Generate Parentheses
        // BackTrack
        // cur.Length == 2 * n --> add to list
        // open < n --> cur.Append('(')
        // close < open --> cur.Apend(')')

        // T: O()
        // S: O(n)
        public IList<string> GenerateParenthesis(int n)
        {
            var ans = new List<string>();
            BackTrack(ans, new StringBuilder(), 0, 0, n);
            return ans;
        }
        public void BackTrack(IList<string> ans, StringBuilder cur, int open, int close, int max)
        {
            if(cur.Length == 2 * max)
            {
                ans.Add(cur.ToString());
                return;
            }
            if(open < max)
            {
                cur.Append('(');
                BackTrack(ans, cur, open + 1, close, max);
                cur.Remove(cur.Length - 1, 1);
            }
            if(close < open)
            {
                cur.Append(')');
                BackTrack(ans, cur, open, close + 1, max);
                cur.Remove(cur.Length - 1, 1);
            }
        }


        // 32. Longest Valid Parentheses
        // DP
        // 注意index范围不要超出有效范围
        public int LongestValidParentheses(string s)
        {
            if (s == null || s.Length == 0)
                return 0;
            var dp = new int[s.Length];
            var maxLength = 0;
            dp[0] = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == ')')
                {
                    if (s[i - 1] == '(')
                        dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2;
                    else if (i - dp[i - 1] - 1 >= 0 && s[i - dp[i - 1] - 1] == '(')
                        dp[i] = dp[i - 1] + (i - dp[i - 1] - 2 >= 0 ? dp[i - dp[i - 1] - 2] : 0) + 2;
                    maxLength = Math.Max(maxLength, dp[i]);
                }
            }
            return maxLength; 
        }


        // 301. Remove Invalid Parentheses (hard)
        /*
         T: O(n * 2^n)， n为字符串的长度，一个字符串最多可能有2^n个子序列，每个子序列可能需要进行一次合法性检测，因此时间复杂度为
         S: O(n^2)， 递归栈的深度，美的递归调用时需要复制字符串一次，因此空间复杂度为O(N^2)
         */
        public IList<string> RemoveInvalidParentheses(string s)
        {
            var res = new List<string>();
            int lremove = 0, rremove = 0;
            foreach (var ch in s)
            {
                if(ch == '(')
                {
                    lremove++;
                }else if(ch == ')')
                {
                    if(lremove == 0)
                        rremove++;
                    else
                        lremove--;
                }
            }
            DFS(s, res, 0, lremove, rremove);
            return res;
        }
        public void DFS(string str, IList<string> res, int start, int lremove, int rremove)
        {
            if(lremove == 0 && rremove == 0)
            {
                if(IsValidStr(str))
                    res.Add(str);
                return;
            }
            for(int i = start; i < str.Length; i++)
            {
                if (i != start && str[i] == str[i - 1])
                    continue;
                // 如果剩余的字符无法满足去掉的数量要求，直接返回
                if (lremove + rremove > str.Length - i)
                    return;
                // 尝试去掉一个左括号
                if (lremove > 0 && str[i] == '(')
                    DFS(str.Substring(0, i) + str.Substring(i + 1), res, i, lremove - 1, rremove);
                // 尝试去掉一个右括号
                if (rremove > 0 && str[i] == ')')
                    DFS(str.Substring(0, i) + str.Substring(i + 1), res, i, lremove, rremove - 1);
            }
        }
        public bool IsValidStr(string s)
        {
            int count = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] == '(')
                {
                    count++;
                }else if(s[i] == ')')
                {
                    count--;
                    if (count < 0)
                        return false;
                }
            }
            return count == 0;
        }


        // 1003. Check If Word Is Valid After Substitutions
        // similar like stack
        // List
        public bool IsValidAfterSubstitutions(string s)
        {
            var list = new List<char>();
            if (s == null || s.Length == 0)
                return true;
            if (s.Length == 1 || s.Length == 2)
                return false;
            list.Add(s[0]);
            list.Add(s[1]);
            for(int i = 2; i < s.Length; i++)
            {
                if(s[i] == 'c')
                {
                    if(list.Count >= 2 && list.Last() == 'b' && list[list.Count - 2] == 'a')
                    {
                        list.RemoveRange(list.Count - 2, 2);
                        continue;
                    }
                    else
                    {
                        list.Add(s[i]);
                    }

                }
                else
                {
                    list.Add(s[i]);
                }
            }
            return list.Count == 0;
        }

    }
}
