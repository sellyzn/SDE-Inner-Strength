using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No1132_RemovePalindromicSubsequence
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public int RemovePalindromeSub(string s)
        {
            if (s == null || s.Length == 0)
                return 0;
            int left = 0, right = s.Length - 1;
            while(left <= right)
            {
                if (s[left] != s[right])
                    return 2;
                left++;
                right--;
            }
            return 1;
        }
    }
}
