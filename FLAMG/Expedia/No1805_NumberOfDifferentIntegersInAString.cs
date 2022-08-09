using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No1805_NumberOfDifferentIntegersInAString
    {
        /// <summary>
        /// Two Pointers + HashSet
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public int NumDifferentIntegers(string word)
        {
            if (word == null || word.Length == 0)
                return 0;
            int left = 0, right = 0;
            var set = new HashSet<string>();
            while (right < word.Length)
            {
                while (right < word.Length && !char.IsDigit(word[right]))
                    right++;
                left = right;
                while (right < word.Length && char.IsDigit(word[right]))
                    right++;
                if (left < word.Length)
                {
                    var str = word.Substring(left, right - left);
                    int index = 0;
                    while (index < str.Length)
                    {
                        if (str[index] == '0')
                            index++;
                        else
                            break;
                    }
                    if (index == str.Length)
                        set.Add("0");
                    else
                        set.Add(str.Substring(index));
                }
            }

            return set.Count;
        }
    }
}
