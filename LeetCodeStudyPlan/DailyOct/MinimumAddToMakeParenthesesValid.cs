using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.DailyOct
{
    internal class MinimumAddToMakeParenthesesValid
    {
        public int MinAddToMakeValid(string s)
        {
            if (s == null || s.Length == 0)
                return 0;
            var stack = new Stack<char>();
            foreach (var ch in s)
            {
                if(stack.Count > 0 && stack.Peek() == '(' && ch == ')')
                    stack.Pop();
                else
                    stack.Push(ch);
            }
            return stack.Count;
        }
    }
}
