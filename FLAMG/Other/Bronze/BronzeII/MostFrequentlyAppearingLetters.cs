using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzeII
{
    public class MostFrequentlyAppearingLetters
    {
        public int MostFrequentlyAppearingLetters1(string str)
        {
            var dict = new Dictionary<char, int>();
            foreach (var c in str)
            {
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                    dict.Add(c, 1);
            }
            int max = 0;
            foreach (var pair in dict)
            {
                max = Math.Max(max, pair.Value);
            }
            return max;
        }
    }
}
