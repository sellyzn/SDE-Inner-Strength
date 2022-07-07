using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No211_DesignAdd_AndSearchWordsDataStructure
    {
    }
    public class WordDictionary
    {
        HashSet<string> set;
        public WordDictionary()
        {
            set = new HashSet<string>();
        }

        public void AddWord(string word)
        {
            set.Add(word);
        }

        public bool Search(string word)
        {
            return set.Contains(word);
        }
    }
}
