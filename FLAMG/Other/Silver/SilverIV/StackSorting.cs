using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverIV
{
    public class StackSorting
    {
        //从原来栈不断pop数字；
        //从一个新栈记录pop出的数字， 新栈:大的数在栈底，小的在栈顶；
        //如果pop出来的数字比新栈的栈顶大，为了使之沉底，把新栈所有比它小的都pop出来扔回原栈。然后该数入新栈。
        //循环，将新栈中的元素pop出来放入原栈。
        //有点像冒泡排序。
        public void StackSortingI(Stack<int> stk)
        {            
            Stack<int> tempStack = new Stack<int>();
            //原栈的元素排序（降序）放入新栈
            while(stk.Count > 0)
            {
                int temp = stk.Pop();
                while(tempStack.Count > 0 && temp > tempStack.Peek())
                {
                    stk.Push(tempStack.Pop());
                }
                tempStack.Push(temp);
            }
            //新栈元素放回到原栈中
            while(tempStack.Count > 0)
            {
                stk.Push(tempStack.Pop());
            }
        }
    }
}
