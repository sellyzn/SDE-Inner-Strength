using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Amazon.Easy
{
    public class SortCharactersByFrequency
    {
        public string FrequencySort(string s)
        {
            // Use a dictionary to store the char and its frequency
            // at the same time, find the maxFrequncy
            // bucket sort, new array, which size is maxFreq + 1
            // traverse dict, and add char to its frequency bucket
            // traverse bucket array in frequency disacceding order, and get the string
            // T: O(N); S: O(N)

            var dict = new Dictionary<char, int>();
            var maxFreq = 0;
            foreach (var ch in s)
            {
                if (dict.ContainsKey(ch))
                    dict[ch]++;
                else
                    dict.Add(ch, 1);
                maxFreq = Math.Max(maxFreq, dict[ch]);
            }

            var bucket = new string[maxFreq + 1];
            foreach (var item in dict)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    bucket[item.Value] += item.Key;
                }
            }

            var result = "";
            for (int i = maxFreq; i >= 0; i--)
            {
                result += bucket[i];
            }
            return result;
        }
    }
}
