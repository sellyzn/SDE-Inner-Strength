using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.BacktrackingProblems
{
    /*
    Backtracking
    时间：O(3^m * 4^n)， 其中m是输入中对应3个字母的数字个数(2、3、4、5、6、8)，n是输入中对应4个字母的数字个数(7、9)。
    空间：O(m + n)
    */
    internal class P17_LetterCombinationsOfAPhoneNumber
    {
        public IList<string> LetterCombinations(string digits)
        {
            var combinations = new List<string>();
            if(digits == null || digits.Length == 0)
            {
                return combinations;
            }
            var phoneMap = new Dictionary<char, string>() { { '2', "abc" }, { '3', "def" }, { '4', "ghi" }, { '5', "jkl" }, { '6', "mno" }, { '7', "pqrs" }, { '8', "tuv" }, { '9', "wxyz" } };
            Backtrack(combinations, phoneMap, digits, 0, new StringBuilder());
            return combinations;
        }
        public void Backtrack(IList<string> combinations, Dictionary<char, string> phoneMap, string digits, int index, StringBuilder combination)
        {
            if(index == digits.Length)
            {
                combinations.Add(combination.ToString());
                return;
            }
            char digit = digits[index];
            string letters = phoneMap[digit];
            for(int i = 0; i < letters.Length; i++)
            {
                combination.Append(letters[i]);
                Backtrack(combinations, phoneMap, digits, index + 1, combination);
                combination.Remove(index, 1);
            }
        }
        
    }
}
