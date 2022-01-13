using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverIV
{
    public class StackPushPopSequence
    {
        //用栈模拟push，pop过程
        //stack
        public bool IsLegalSeq(int[] push, int[] pop)
        {   
            var stack = new Stack<int>();
            int index = 0;
            foreach (var x in push)
            {
                stack.Push(x);
                while(stack.Count > 0 && index < pop.Length && stack.Peek() == pop[index])
                {
                    stack.Pop();
                    index++;
                }
            }
            return index == pop.Length;            
        }
    }
}
