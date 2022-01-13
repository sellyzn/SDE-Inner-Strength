using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzeII
{
    public class UniqueCharacters
    {
        public bool IsUnique(string str)
        {
            if (str == null || str.Length == 0)
                return false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str.IndexOf(str[i]) != i)
                    return false;
            }
            return true;
        }

        public char FirstUniqChar(string str)
        {            
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (dict.ContainsKey(str[i]))
                    dict[str[i]]++;
                else
                    dict.Add(str[i], 1);
            }
            char res = str[0];
            foreach (var item in dict.Keys)
            {
                if (dict[item] == 1)
                    res = item;
            }
            return res;
        }
    }
}
