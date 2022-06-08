using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No9_PalindromeNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// T: O(N), N is the length of string s, s = x.ToString(), traverse the whole string s
        /// S: O(1), we use a s to store the string transformed by x. 
        public bool IsPalindrome(int x)
        {
            if(x < 0)
                return false;
            var s = x.ToString();
            int left = 0, right = s.Length - 1;
            while(left <= right)
            {
                if (s[left] != s[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }
    }
}
