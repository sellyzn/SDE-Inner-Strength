using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class NumberOfDifferentIntegersInAString
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O()
        public int NumDifferentIntegers(string word)
        {
            //         l
            // word: "a123bc34d8ef34"
            //            r
            // word: "a1b01c001"  => 1
            // word: "abc"
            // different: HashSet
            // without leading zeros: ignore the leading zeros
            // Two pointers to find each nums
            if (word == null || word.Length == 0)
                return 0;
            var set = new HashSet<string>();
            int left = 0, right = 0;
            while(right < word.Length)
            {
                while(right < word.Length && !char.IsDigit(word[right]))
                    right++;
                left = right;
                while (right < word.Length && char.IsDigit(word[right]))
                    right++;
                // word.Substring(left, right - left);
                if(left < word.Length)
                {
                    var str = word.Substring(left, right - left);
                    var index = 0;
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
