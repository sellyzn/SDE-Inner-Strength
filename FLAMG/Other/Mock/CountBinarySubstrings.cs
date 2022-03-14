using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Mock
{
    public class CountBinarySubstrings
    {
        public int CountBinarySubstringsSolution(string s)
        {
            List<int> counts = new List<int>();
            //int i = 1;
            //int count = 1;
            //计算相邻相同的字符的个数
            //while(i < s.Length)
            //{
            //    if(s[i] != s[i - 1])
            //    {
            //        counts.Add(count);
            //        count = 1;
            //    }
            //    else
            //    {
            //        count++;
            //    }
            //}
            //counts.Add(count);

            //统计相邻相同字符的个数
            int i = 0;
            while(i < s.Length)
            {
                char c = s[i];
                int count = 0;
                while(i < s.Length && s[i] == c)
                {
                    count++;
                    i++;
                }
                counts.Add(count);
            }
            //相邻数对取较小值，遍历求和
            int res = 0;
            for(int j = 0; j < counts.Count - 1; j++)
            {
                res += Math.Min(counts[j], counts[j + 1]);
            }
            return res;
        }
    }
}
