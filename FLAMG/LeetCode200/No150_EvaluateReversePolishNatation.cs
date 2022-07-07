using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No150_EvaluateReversePolishNatation
    {
        /// <summary>
        /// Stack
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public int EvalRPN(string[] tokens)
        {
            var stack = new Stack<int>();
            for(int i = 0; i < tokens.Length; i++)
            {
                if(tokens[i] == "+" || tokens[i] == "-" || tokens[i] == "*" || tokens[i] == "/")
                {
                    var second = stack.Pop();
                    var first = stack.Pop();
                    if (tokens[i] == "+")
                        stack.Push(first + second);
                    if (tokens[i] == "-")
                        stack.Push(first - second);
                    if (tokens[i] == "*")
                        stack.Push(first * second);
                    if (tokens[i] == "/")
                        stack.Push(first / second);
                }
                else
                {
                    stack.Push(int.Parse(tokens[i]));
                }
            }
            return stack.Pop();
        }
    }
}
