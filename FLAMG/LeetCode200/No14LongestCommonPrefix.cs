using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No14LongestCommonPrefix
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        /// T: O(S)， S为所有字符的长度总和。比较两个字符串并返回其prefix长度，时间复杂度是 O(Min(s1, s2)),其中s1, s2分别是两个字符串的长度。找到字符串数组中所有字符串的共同prefix， 因为遍历所有字符串，每次遍历中都要比较找到两个字符串的共同prefix，所以总的时间复杂度为 O(s1 + s2 + ... + sn) = O(S)。
        /// S: O(1)
        /// 
        public string LongestCommonPrefix(string[] strs)
        {
            // strs sorted by length
            //strs = strs.OrderBy(x => x.Length).ToArray();

            // traverse the strs, and compared the shortest str with each strs, to find the longest common prefix. min
            var maxLength = int.MaxValue;

            if(strs.Length == 1)
                return strs[0];

            for(int i = 1; i < strs.Length; i++)
            {
                maxLength = Math.Min(maxLength, CommonPrefixLength(strs[0], strs[i]));
            }
            return strs[0].Substring(0, maxLength);
        }
        public int CommonPrefixLength(string str1, string str2)
        {
            var prefixLength = 0;
            var length = 0;
            if(str1.Length < str2.Length)
                length = str1.Length;
            else
                length = str2.Length;
            for(int i = 0; i < length; i++)
            {
                if (str1[i] == str2[i])
                    prefixLength++;
                else break;
            }
            
            return prefixLength;
        }



    }
}
