using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.SlidingWindowProblems
{
    internal class P1456_MaximumNumberOfVowelsInASubstringOfGivenLength
    {
        /*
        滑动窗口
        时间：O(n)
        空间：O(1)
        */
        public int MaxVowels(string s, int k)
        {
            var vowelSet = new HashSet<char>();
            vowelSet.Add('a');
            vowelSet.Add('e');
            vowelSet.Add('i');
            vowelSet.Add('o');
            vowelSet.Add('u');
            if (s == null || s.Length == 0)
                return 0;
            var num = 0;
            var maxNum = 0;
            for(var i = 0; i < s.Length; i++)
            {
                if(i < k)
                {
                    if (vowelSet.Contains(s[i]))
                    {
                        num++;
                        maxNum = num;
                    }
                }
                else
                {
                    if (vowelSet.Contains(s[i]))
                    {
                        num++;
                    }
                    if (vowelSet.Contains(s[i - k]))
                    {
                        num--;
                    }
                    maxNum = Math.Max(maxNum, num);
                }
            }
            return maxNum;
        }
    }
}
