using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.StackProblems
{
    internal class P394_DecodeString
    {
        public string DecodeString(string s)
        {
            var stack = new Stack<string>();
            int index = 0;
            while (index < s.Length)
            {
                var num = new StringBuilder();
                while(index < s.Length && char.IsDigit(s[index]))
                {
                    num.Append(s[index]);
                }
                if(num.Length > 0)
                {
                    stack.Push(num.ToString());
                }
                var str = new StringBuilder();
                while(index < s.Length && char.IsLetter(s[index]))
                {
                    str.Append(s[index]);
                }
                if(str.Length > 0)
                {
                    stack.Push(str.ToString());
                }
                if (s[index] == '[')
                {
                    stack.Push("[");
                }
                if (s[index] == ']' && stack.Count >= 2)
                {
                    var finalStr = new StringBuilder();
                    var copyString = stack.Pop();
                    var copyNum = stack.Pop();
                    for(int i = 0; i < Int32.Parse(copyNum); i++)
                    {
                        finalStr.Append(copyString);
                    }
                    stack.Push(finalStr.ToString());
                }
            }
            var ans = new StringBuilder();
            while(stack.Count > 0)
            {
                ans.Insert(0, stack.Pop());
            }
            return ans.ToString();
            //for(int i = 0; i < s.Length; i++)
            //{
            //    if (s[i] == ']')
            //    {
            //        var str = new StringBuilder();
            //        while(stack.Peek() != '[')
            //        {
            //            str.Insert(0, stack.Pop());
            //        }
            //        var multiNum = new StringBuilder();
            //        while(char.IsDigit(stack.Peek()))
            //        {
            //            multiNum.Insert(0, stack.Pop());
            //        }
            //        var finalStr = new StringBuilder();
            //        for(var j = 0; j < Int32.Parse(multiNum.ToString()); j++)
            //        {
            //            finalStr.Append(multiNum);
            //        }
            //        stack.Push(finalStr);
            //    }
            //    else
            //    {
            //        stack.Push(s[i]);
            //    }
            //}

            //return ans.ToString();
        }
        
    }
}
