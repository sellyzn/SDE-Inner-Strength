using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Mock
{
    public class ReorganizeString
    {
        //Given a string s, rearrange the characters of s so that any two adjacent characters are not the same.
        //Return any possible rearrangement of s or return "" if not possible.


        //public string ReorganizeStringSolution(string s)
        //{
        //    if (s.Length < 2)
        //        return s;
        //    int[] counts = new int[26];
        //    int maxCount = 0;
        //    int length = s.Length;
        //    for(int i = 0; i < s.Length; i++)
        //    {
        //        char c = s[i];
        //        counts[c - 'a']++;
        //        maxCount = Math.Max(maxCount, counts[c - 'a']);
        //    }

        //    if (maxCount > (length + 1) / 2)
        //        return "";

        //    PriorityQueue<char> queue = new PriorityQueue<char>();

        //    for(char c = 'a'; c <= 'z'; c++)
        //    {
        //        if (counts[c - 'a'] > 0)
        //            queue.Add(c);
        //    }

        //    StringBuilder sb = new StringBuilder();
        //    while(queue.Size() > 1)
        //    {
        //        char letter1 = queue.PopFirst();
        //        char letter2 = queue.PopFirst();
        //        sb.Append(letter1);
        //        sb.Append(letter2);
        //        int index1 = letter1 - 'a', index2 = letter2 - 'a';
        //        counts[index1]--;
        //        counts[letter2]--;
        //        if (counts[index1] > 0)
        //            queue.Add(letter1);
        //        if (counts[letter2] > 0)
        //            queue.Add(letter2);
        //    }
        //    if (queue.Size() > 0)
        //        sb.Append(queue.PopFirst());
        //    return sb.ToString();
        //}

        public string ReorganizeStringSolutionII(string s)
        {
            ////把字符串S转化为字符数组
            //char[] alphabetArr = s.ToCharArray();
            //记录每个字符出现的次数
            int[] counts = new int[26];
            //字符串的长度
            //int length = s.Length;
            //统计每个字符出现的次数
            for (int i = 0; i < s.Length; i++)
            {
                counts[s[i] - 'a']++;
            }
            int maxCount = 0, alphabet = 0;
            //找出出现次数最多的那个字符
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > maxCount)
                {
                    maxCount = counts[i];
                    alphabet = i;
                    //如果出现次数最多的那个字符的数量大于阈值，说明他不能使得
                    // 两相邻的字符不同，直接返回空字符串即可
                    if (maxCount > (s.Length + 1) / 2)
                        return "";
                }
            }
            //到这一步说明他可以使得两相邻的字符不同，我们随便返回一个结果，res就是返回
            //结果的数组形式，最后会再转化为字符串的
            char[] res = new char[s.Length];
            int index = 0;
            //先把出现次数最多的字符存储在数组下标为偶数的位置上
            while (counts[alphabet]-- > 0)
            {
                res[index] = (char)(alphabet + 'a');
                index += 2;
            }
            //然后再把剩下的字符存储在其他位置上
            for (int i = 0; i < counts.Length; i++)
            {
                while (counts[i]-- > 0)
                {
                    if (index >= res.Length)
                    {
                        index = 1;
                    }
                    res[index] = (char)(i + 'a');
                    index += 2;
                }
            }
            return new String(res);            
        }


        public string ReorgnizeString(string s)
        {
            //1.统计字符串中每个字符的次数， 并找出出现次数最多的那个字符
            var counts = new int[26];
            int maxChar = 0, maxCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                counts[s[i] - 'a']++;
                if(counts[s[i] - 'a'] > maxCount)
                {
                    maxCount = counts[s[i] - 'a'];
                    maxChar = i;

                    if (maxCount > (s.Length + 1) / 2)
                        return "";
                }
            }
            //2. 出现次数最多的字符存储在数组下标为偶数的位置上
            int index = 0;
            char[] res = new char[s.Length];
            while(counts[maxChar] > 0)
            {
                res[index] = (char)(maxChar + 'a');
                index += 2;
            }
            //3. 遍历counts，剩下的字符存储在其他位置上（index += 2存储）
            for (int i = 0; i < s.Length; i++)
            {
                while(counts[i] > 0)
                {
                    //如果index超出s的长度，则从1开始.
                    //先把数组下标为偶数的位置填满，再填奇数位置。
                    if (index >= s.Length)
                        index = 1;
                    res[index] = (char)(i + 'a');
                    index += 2;
                }
            }
            return res.ToString();
        }

    }
}
