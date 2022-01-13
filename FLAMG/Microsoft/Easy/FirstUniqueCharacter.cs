using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FLAMG.Microsoft.Easy
{
    public class FirstUniqueCharacter
    {
        ////////////////////////////////////////
        // First Unique Character in a String //
        ////////////////////////////////////////
        ///
        //Dictionary + traverse
        public int FirstUniqChar(string s)
        {
            var dict = new Dictionary<char, int>();
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

        //////////////////////////////////
        // Sort Characters By Frequency //
        //////////////////////////////////
        ///
        //Dictionary -> Frequency Counting  + Sort
        public string FrequencySort(string s)
        {
            //record each character's numbers and store pairs
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                    dict[s[i]]++;
                else
                    dict.Add(s[i], 1);
            }
            dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            //dict.OrderBy((x)=>x.Value);
            var sb = new StringBuilder();
            foreach (var item in dict)
            {
                int count = item.Value;
                while(count > 0)
                {
                    sb.Append(item.Key);
                    count--;
                }
            }
            return sb.ToString();
        }

        //Dictonary -> Frequency Counting  + Bucket Sort
        public string FrequencySort_BucketSort(string s)
        {
            //Frequency Record
            var dict = new Dictionary<char, int>();
            int maxFreq = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                    dict[s[i]]++;
                else
                    dict.Add(s[i], 1);
                maxFreq = Math.Max(maxFreq, dict[s[i]]);
            }

            //Bucket Sorting

            //creat buckets array, to store every character with frequency from 1 to maxFreq 
            var buckets = new StringBuilder[maxFreq + 1];
            for (int i = 0; i < maxFreq; i++)
            {
                buckets[i] = new StringBuilder();
            }
            //store 
            foreach (var pair in dict)
            {
                char c = pair.Key;
                int frequency = pair.Value;
                buckets[frequency].Append(c);
            }
            var sb = new StringBuilder();
            for (int i = maxFreq; i > 0; i--)
            {
                var bucket = buckets[i];
                for (int j = 0; j < bucket.Length; j++)
                {
                    for (int k = 0; k < i; k++)  //
                    {
                        sb.Append(bucket[j]);
                    }
                }
            }
            return sb.ToString();
        }
    }
}
