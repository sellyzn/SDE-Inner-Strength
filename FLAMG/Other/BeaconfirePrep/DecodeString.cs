using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.BeaconfirePrep
{
    public class DecodeString
    {
        public string ExpressionExpand(string s)
        {
            if (s == null || s.Length == 0)
                return "";
            var repeat = new Stack<int>();
            var tempStr = new Stack<string>();
            string res = "";
            int i = 0;
            while(i < s.Length)
            {
                if (char.IsDigit(s[i]))
                {
                    int count = 0;
                    while (char.IsDigit(s[i]))
                    {
                        count = 10 * count + s[i] - '0';
                        i++;
                    }
                    repeat.Push(count);
                }else if(s[i] == '[')
                {
                    tempStr.Push(res);
                    res = "";
                    i++;
                }else if(s[i] == ']'){
                    var sb = new StringBuilder(tempStr.Pop());
                    int repeatTimes = repeat.Pop();
                    for(int index = 0; index < repeatTimes; i++)
                    {
                        sb.Append(res);
                    }
                    res = sb.ToString();
                    i++;
                }else
                {
                    res += s[i];
                    i++;
                }
            }
            return res;
        }
    }
}
