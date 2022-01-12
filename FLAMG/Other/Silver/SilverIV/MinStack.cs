using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverIV
{
    public class MinStack
    {
        public Stack<int> stack1, minStack;
        public MinStack()
        {
            stack1 = new Stack<int>();
            minStack = new Stack<int>();
        }
        public void Push(int number)
        {
            stack1.Push(number);
            if (minStack.Count == 0 || number <= minStack.Peek())
                minStack.Push(number);
        }
        public int Pop()
        {
            if(minStack.Peek().Equals(stack1.Peek()))   //for java: instead .Equals() method of " == " will report error
            {
                minStack.Pop();
            }
            return stack1.Pop();
        }
        public int Min()
        {
            return minStack.Peek();
        }
    }
}
