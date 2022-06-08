using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No13_RomanToInteger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// T: O(N)，N为字符串 S 的长度，因为用一个for循环对字符串S进行了遍历，所以时间复杂度为O(N)
        /// S: O(1), 只用dictionary存储了 7 个键值对，所以空间复杂度为O(1)
        public int RomanToInt(string s)
        {
            var dict = new Dictionary<char, int>();
            dict.Add('I', 1);
            dict.Add('V', 5);
            dict.Add('X', 10);
            dict.Add('L', 50);
            dict.Add('C', 100);
            dict.Add('D', 500);
            dict.Add('M', 1000);

            var result = dict[s[0]];

            for (int i = 1; i < s.Length; i++)
            {
                if(s[i - 1] == 'I' && (s[i] == 'V' || s[i] == 'X'))
                {
                    result += dict[s[i]] - 2 * dict[s[i - 1]];
                }else if(s[i - 1] == 'X' && (s[i] == 'L' || s[i] == 'C'))
                {
                    result += dict[s[i]] - 2 * dict[s[i - 1]];
                }else if(s[i - 1] == 'C' && (s[i] == 'D' || s[i] == 'M'))
                {
                    result += dict[s[i]] - 2 * dict[s[i - 1]];
                }
                else
                {
                    result += dict[s[i]];
                }
            }
            return result;
        }
        // 优化： 如果对应的数值 s[i] <= s[i - 1]， 则 直接加上s[i]对应的数值，否则，在加上s[i]对应的值后，要再减去 2 * s[i - 1] 对应的值
        public int RomanToInt_Optimize(string s)
        {
            var dict = new Dictionary<char, int>() { {'I', 1}, {'V', 5 }, {'X', 10 }, {'L', 50 }, {'C', 100 }, {'D', 500 }, {'M', 1000 } };
            var result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0 || dict[s[i]] <= dict[s[i - 1]])
                    result += dict[s[i]];
                else
                    result += dict[s[i]] - 2 * dict[s[i - 1]];
            }
            return result;
        }


    }
}
