using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No20_ValidParenthese
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// T: O(N), use a for loop to traverse s
        /// S: O(N), use a stack to store s
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] == '(' || s[i] == '[' || s[i] == '{')
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
    }
}
