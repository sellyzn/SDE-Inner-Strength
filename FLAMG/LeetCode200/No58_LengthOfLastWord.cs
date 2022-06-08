using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No58_LengthOfLastWord
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public int LengthOfLastWord(string s)
        {
            int right = s.Length - 1;
            int length = 0;
            while(right >= 0)
            {
                while (right >= 0 && s[right] == ' ')
                    right--;
                while(right >= 0 && s[right] != ' ')
                {
                    length++;
                    right--;
                }                    
                return length;
            }
            return length;
        }
    }
}
