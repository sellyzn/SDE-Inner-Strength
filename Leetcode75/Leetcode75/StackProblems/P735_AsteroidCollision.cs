using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.StackProblems
{
    internal class P735_AsteroidCollision
    {
        /*
        栈模拟：
        时间：O(n)
        空间：O(n)
        */
        public int[] AsteroidCollision(int[] asteroids)
        {
            var stack = new Stack<int>();
            foreach (var aster in asteroids)
            {
                bool alive = true;
                while(alive && aster < 0 && stack.Count > 0 && stack.Peek() > 0)
                {
                    alive = stack.Peek() < -aster;
                    if(stack.Peek() <= -aster)
                    {
                        stack.Pop();
                    }          
                }
                if(alive)
                {
                    stack.Push(aster);
                }
            }
            int count = stack.Count;
            var ans = new int[count];
            for(int i = count - 1; i >= 0; i--)
            {
                ans[i] = stack.Pop();
            }
            return ans;
        }
    }
}
