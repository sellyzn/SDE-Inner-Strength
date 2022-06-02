using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No28ImplementStr
    {
        /// <summary>
        /// Brute force
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        /// T: O(M + N)
        /// S: O(1)
        public int StrStr(string haystack, string needle)
        {
            var len1 = haystack.Length;
            var len2 = needle.Length;
            if (len1 < len2)
                return -1;
            if (needle.Length == 0)
                return 0;
            for(int i = 0; i <= len1 - len2; i++)
            {
                int j = 0;
                while(j < len2)
                {
                    if (haystack[i + j] != needle[j])
                        break;
                    j++;
                }
                if (j == len2)
                    return i;
            }
            return -1;
        }
    }
}
