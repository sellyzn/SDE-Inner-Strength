using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    /// <summary>
    /// T: O(1), all operations is O(1)
    /// s: o(n)
    /// </summary>
    internal class No155_MinStack
    {
        Stack<int> stack1;
        Stack<int> minStack;
        public No155_MinStack()
        {
            stack1 = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int val)
        {
            stack1.Push(val);
            if(minStack.Count == 0 || val <= minStack.Peek())
                minStack.Push(val);
        }

        public void Pop()
        {
            if(stack1.Peek() == minStack.Peek())                     
                minStack.Pop();            
            stack1.Pop();    
        }

        public int Top()
        {
            return stack1.Peek();
        }
        
        public int GetMin()
        {
            return minStack.Peek();
        }
    }
}
