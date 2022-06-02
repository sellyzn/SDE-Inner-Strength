using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.HighestFrequency
{
    internal class EvaluateReversePolishNotation
    {
        // 150. 
        public int EvalRPN(string[] tokens)
        {
            var stack = new Stack<int>();

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "+" || tokens[i] == "-" || tokens[i] == "*" || tokens[i] == "/")
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
                    Console.WriteLine(stack.Peek());
                }
            }
            return stack.Pop();
        }

        // 224. Basic Calculator
        //public int Calculate(string s)
        //{

        //}

    }
}
