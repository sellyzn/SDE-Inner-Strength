using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.Bronze.II
{
    public class ReverseWordsInString
    {
        public string ReverseWords(string s)
        {
            s.Trim();
            int length = s.Length;
            if (s == null || s.Length == 0)
                return s;
            StringBuilder sb = new StringBuilder();
            int start = s.Length - 1, end = s.Length - 1;
            while(start >= 0)
            {
                while(start >= 0 && s[start] != ' ')
                    start--;
                sb.Append(s.Substring(start + 1, end - start) + " ");
                while (start >= 0 && s[start] == ' ')
                    start--;
                end = start;
            }
            return sb.ToString().Trim();
        }
    }
}
