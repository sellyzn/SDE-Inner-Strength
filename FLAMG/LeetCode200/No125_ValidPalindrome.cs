using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No125_ValidPalindrome
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public bool IsPalindrome(string s)
        {
            string str = s.ToLower().Trim();
            if (str == null || str.Length == 0)
                return true;
            int left = 0, right = str.Length - 1;
            while(left <= right)
            {
                while(left <= right && !IsAlphaNum(str[left]))
                    left++;
                while (left <= right && !IsAlphaNum(str[right]))
                    right--;
                if(left <= right && str[left] != str[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }
        public bool IsAlphaNum(char ch)
        {
            if (ch >= 'A' && ch <= 'Z')
                return true;
            if (ch >= 'a' && ch <= 'z')
                return true;
            if (ch >= '0' && ch <= '9')
                return true;
            return false;
        }
    }
}
