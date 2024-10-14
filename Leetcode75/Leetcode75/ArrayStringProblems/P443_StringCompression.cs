using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.ArrayStringProblems
{
    internal class P443_StringCompression
    {
        public int Compress(char[] chars)
        {
            //
            //var compressedString = new StringBuilder();
            //int left = 0, right = 0;
            //while(right < chars.Length)
            //{
            //    while(right < chars.Length && chars[left] == chars[right])
            //    {
            //        right++;
            //    }
            //    if(right - left == 1)
            //    {
            //        compressedString.Append(chars[left]);
            //    }
            //    else
            //    {
            //        compressedString.Append(chars[left]).Append((right - left).ToString());
            //    }
            //    left = right;
            //}
            //return compressedString.Length;

            //modify the array chars
            int left = 0, right = 0;
            while(right < chars.Length)
            {
                while(right < chars.Length && chars[right] == chars[left])
                {
                    right++;
                }
                if(right - left == 1)
                {
                    left++;
                }
                else
                {
                    int num = right - left;
                    var str = num.ToString();
                    left++;
                    for(int i = 0; i < str.Length; i++)
                    {
                        chars[left++] = str[i];
                    }
                }
            }
            return left;
        }
    }
}
