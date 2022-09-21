using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.TreeCategory
{
    internal class Trie
    {
        private TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }
        public void Insert(string word)
        {
            var node = root;
            for(int i = 0; i < word.Length; i++)
            {
                var currentChar = word[i];
                if (!node.ContainsKey(currentChar))
                {
                    node.Add(currentChar, new TrieNode());
                }
                node = node.Get(currentChar);
            }
            node.SetEnd();
        }

        public TrieNode SearchPrefix(string word)
        {
            var node = root;
            for(int i = 0; i < word.Length; i++)
            {
                var currentChar = word[i];
                if (node.ContainsKey(currentChar))
                {
                    node = node.Get(currentChar);
                }
                else
                {
                    return null;
                }
            }
            return node;
        }

        public bool Search(string word)
        {
            var node = SearchPrefix(word);
            return node != null && node.IsEnd();
        }

        public bool StartWith(string prefix)
        {
            var node = SearchPrefix(prefix);
            return node != null;
        }
        
    }
}
