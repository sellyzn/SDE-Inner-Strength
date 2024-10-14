using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.StackProblems
{
    internal class P2390_RemovingStarsFromAString
    {
        /*
        栈 
        */
        public string RemoveStars(string s)
        {
            var result = new StringBuilder();
            var stackStr = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != '*')
                {
                    stackStr.Push(s[i]);
                }
                else if (s[i] == '*')
                {
                    if(stackStr.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        stackStr.Pop();
                    }
                }               
            }
            while(stackStr.Count > 0)
            {
                result.Insert(0, stackStr.Pop());
            }
            return result.ToString();
        }
    }
}
