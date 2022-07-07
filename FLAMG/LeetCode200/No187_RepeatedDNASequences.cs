using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No187_RepeatedDNASequences
    {
        /// <summary>
        /// HashMap
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public IList<string> FindRepeatedDnaSequence(string s)
        {
            // Dictionary<string, int> to store the substring and numbers
            // traverse the string s
            // traverse the Dictionary, find the keys which value numbers > 1
            var result = new List<string>();
            if(s == null || s.Length <= 10)
                return result;
            var dict = new Dictionary<string, int>();
            int index = 0;
            while(index <= s.Length - 10)
            {
                var subStr = s.Substring(index, 10);
                if(dict.ContainsKey(subStr))
                    dict[subStr]++;
                else
                    dict.Add(subStr, 1);
                if(dict[subStr] > 1)
                    result.Add(subStr);
                index++;
            }
            
            return result;
        }
    }
}
