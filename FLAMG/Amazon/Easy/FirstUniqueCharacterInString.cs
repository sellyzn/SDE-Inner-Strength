using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Amazon.Easy
{
    public class FirstUniqueCharacterInString
    {
        public int FirstUniqChar(string s)
        {
            // Step1: Traverse the string s, and store the index-count pair into a dictionary.
            // Step2: Traverse the dictionary, find the first index which value is 1

            var dict = new Dictionary<int, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                    dict[s[i]]++;
                else
                    dict.Add(s[i], 1);
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (dict[s[i]] == 1)
                    return i;
            }
            return -1;
        }
    }
}
