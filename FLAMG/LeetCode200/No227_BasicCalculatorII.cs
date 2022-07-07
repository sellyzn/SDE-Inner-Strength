using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No227_BasicCalculatorII
    {
        //T: O(N)
        //S: O(N)

        // 使用map维护一个运算符优先级
        // 这里的优先级划分按照「数学」进行划分即可
        Dictionary<char, int> map = new Dictionary<char, int> { { '+', 1 }, { '-', 1 }, { '*', 2 }, { '/', 2 }, { '%', 2 }, { '^', 3 } };
        public int Calculate(string s)
        {
            // 将所有的空格去掉
            s = s.Replace(" ", "");
            var strArr = s.ToCharArray();
            int n = s.Length;

            //存放所有的数字
            var nums = new Stack<int>();
            // 为了防止第一个数为负数，现网nums加个0
            nums.Push(0);
            // 存放所有「非数字以外」的操作
            var ops = new Stack<char>();

            for(int i = 0; i < n; i++)
            {
                var ch = strArr[i];
                if(ch == '(')
                {
                    ops.Push(ch);
                }else if(ch == ')')
                {
                    // 计算到最近一个左括号为止
                    while(ops.Count > 0)
                    {
                        if(ops.Peek() != '(')
                        {
                            Calculate(nums, ops);
                        }
                        else
                        {
                            ops.Pop();
                            break;
                        }
                    }
                }
                else
                {
                    if (char.IsDigit(ch))
                    {
                        int u = 0;
                        int j = i;
                        // 将从 i 位置开始后面的连续数字整体取出，加入 nums
                        while (j < n && char.IsDigit(strArr[j])){
                            u = u * 10 + (strArr[j] - '0');
                            j++;
                        }
                        nums.Push(u);
                        i = j - 1;
                    }
                    else
                    {
                        if(i > 0 && (strArr[i - 1] == '(' || strArr[i - 1] == '+' || strArr[i - 1] == '-'))
                        {
                            nums.Push(0);
                        }
                        // 有一个新操作入栈时，先把栈内可以算的都算了
                        // 只有满足「栈内运算符」比「当前运算符」优先级高/同等， 才进行运算
                        while (ops.Count > 0 && ops.Peek() != '(')
                        {
                            char prev = ops.Peek();
                            if(map[prev] >= map[ch])
                            {
                                Calculate(nums, ops);
                            }
                            else
                            {
                                break;
                            }
                        }
                        ops.Push(ch);
                    }
                }

            }
            // 将剩余的计算完
            while(ops.Count > 0)
            {
                Calculate(nums, ops);
            }
            return nums.Peek();
        }
        public void Calculate(Stack<int> nums, Stack<char> ops)
        {
            if (nums.Count == 0 || nums.Count < 2)
                return;
            if (ops.Count == 0)
                return;
            int b = nums.Pop();
            int a = nums.Pop();
            char op = ops.Pop();
            int ans = 0;
            if (op == '+')
                ans = a + b;
            else if (op == '-')
                ans = a - b;
            else if (op == '*')
                ans = a * b;
            else if (op == '/')
                ans = a / b;
            else if (op == '^')
                ans = (int)Math.Pow(a, b);
            else if (op == '%')
                ans = a % b;
            nums.Push(ans);
        }
    }
}
