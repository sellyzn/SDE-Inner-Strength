using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No17LetterCombinationOfAPhoneNumber
    {
        /// <summary>
        /// Backtracking
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        /// T: O(3^m * 4^n), m是输入中对应3个字符的数字个数，n是输入中对应4个字符的数字个数， m + n 是输入数字的总个数
        /// S: O(m + n), 除了返回值外，空间复杂度主要取决于哈希表及回溯过程中递归调用层数，哈希表的大小与输入无关，可以看成常数，递归调用层数最大为 m + n。
        public IList<string> LetterCombinations(string digits)
        {
            var combinations = new List<string>();
            if (digits == null || digits.Length == 0)
                return combinations;
            var phoneMap = new Dictionary<char, string>() { { '2', "abc"}, { '3', "def"}, { '4', "ghi"}, { '5', "jkl"}, { '6', "mno"}, { '7', "pqrs"}, { '8', "tuv"}, { '9', "wxyz"} };

            Backtrack(combinations, phoneMap, digits, 0, new StringBuilder());
            return combinations;
        }
        public void Backtrack(List<string> combinations, Dictionary<char, string> phoneMap, string digits, int index, StringBuilder combination)
        {
            if(index == digits.Length)
            {
                combinations.Add(combination.ToString());
            }
            else
            {
                char digit = digits[index];
                string letters = phoneMap[digit];
                int lettersCount = letters.Length;
                for(int i = 0; i < lettersCount; i++)
                {
                    combination.Append(letters[i]);
                    Backtrack(combinations, phoneMap, digits, index + 1, combination);
                    combination.Remove(index, 1);
                }
            }
        }
    }
}
