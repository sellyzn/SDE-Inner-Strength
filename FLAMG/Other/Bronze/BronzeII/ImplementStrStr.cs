using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzeII
{
    public class ImplementStrStr
    {
        public int strStr(string source, string target)
        {
            //if ((source == null && target != null) || (source.Length < target.Length))
            //    return -1;
            //if (source.Length == target.Length)
            //    return source == target ? 0 : -1;

            //for(int i = 0; i < source.Length; i++)
            //{
            //    int end = i;
            //    for(int j = 0; j < target.Length; j++)
            //    {
            //        if (source[i] == target[j])
            //            end++;
            //    }
            //    if (end - i == target.Length)
            //        return i;
            //}
            //return -1;

            int n = source.Length, m = target.Length;
            for (int i = 0; i + m <= n; i++)
            {
                bool flag = true;
                for (int j = 0; j < m; j++)
                {
                    if (source[i + j] != target[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    return i;
            }
            return -1;
        }
    }
}
