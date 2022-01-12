using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Facebook.Easy
{
    public class ValidParentheses
    {
        ///////////////////////
        // Valid Parentheses //
        ///////////////////////
        
        //Stack + Dictionary
        public bool IsValid(string s)
        {
            var dict = new Dictionary<char, char>();
            dict.Add('(', ')');
            dict.Add('{', '}');
            dict.Add('[', ']');
            var st = new Stack<char>();
            foreach (var item in s)
            {
                if (dict.ContainsKey(item))
                    st.Push(item);
                else if (st.Count > 0 && dict[st.Peek()] == item)
                    st.Pop();
                else
                    return false;
            }
            return st.Count == 0;
        }

        //////////////////////////
        // Generate Parentheses //
        //////////////////////////
        
        //Backtracking (DFS)
        //when to add '(' or ')': use the numbers of '(' and ')' to control the validation of the string. open-->'(', close-->')'.
        //      when open < n, add '('
        //      when close < open, add ')'
        public IList<string> GenerateParentheses(int n)
        {
            var res = new List<string>();
            Backtrack(res, new StringBuilder(), 0, 0, n);
            return res;
        }
        public void Backtrack(List<string> res, StringBuilder cur, int open, int close, int max)
        {
            if(cur.Length == max * 2)
            {
                res.Add(cur.ToString());
                return;
            }
            if(open < max)
            {
                cur.Append('(');
                Backtrack(res, cur, open + 1, close, max);
                cur.Remove(cur.Length - 1, 1);
            }
            if(close < open)
            {
                cur.Append(')');
                Backtrack(res, cur, open, close + 1, max);
                cur.Remove(cur.Length - 1, 1);
            }
        }


        ///////////////////////////////
        // Longest Valid Parentheses //
        ///////////////////////////////

        //1.Dynamic Programming
        //2.Stack

        public int LongestValidParentheses_DP(string s)
        {
            var maxLen = 0;
            var dp = new int[s.Length];
            for(var i = 1; i < s.Length; i++)
            {
                if(s[i] == ')')
                {
                    //if(s[i - 1] == '(')
                    //{
                    //    dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2;
                    //}else if ()
                    //{

                    //}
                    maxLen = Math.Max(maxLen, dp[i]);
                }
            }
            return maxLen;
        }

        //Always keep the bottom element of the stack as the "index of the last unmached right parenthesis"
        // among the elements that have been traversed currently.

        //for each traversed '(', push its index into stack.
        //for each traversed ')', firstly popped the top element of the stack, means that the current closing parenthesis ')' is matched.
        // if the stack is empty, means that 
        public int LongestValidParentheses_Stack(string s)
        {
            var maxLen = 0;
            var st = new Stack<int>();
            st.Push(-1);
            for(var i = 0; i < s.Length; i++)
            {
                if(s[i] == '(')
                {
                    st.Push(i);
                }
                else
                {
                    st.Pop();
                    if(st.Count == 0)
                    {
                        st.Push(i);
                    }
                    else
                    {
                        maxLen = Math.Max(maxLen, i - st.Peek());
                    }
                }
            }
            return maxLen;
        }

    }
}
