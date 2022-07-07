using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class TrieNode
    {
        // R links to node children
        private TrieNode[] links;
        private const int R = 26;
        private bool isEnd;
        public TrieNode()
        {
            links = new TrieNode[R];
        }

        public bool ContainsKey(char ch)
        {
            return links[ch - 'a'] != null;
        }

        public TrieNode Get(char ch)
        {
            return links[ch - 'a'];
        }

        public void Add(char ch, TrieNode node)
        {
            links[ch - 'a'] = node;
        }

        public void SetEnd()
        {
            isEnd = true;
        }

        public bool IsEnd()
        {
            return isEnd;
        }
        
    }

    internal class Trie
    {
        private TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }
        // Insert a word into the trie
        public void Insert(String word)
        {
            TrieNode node = root;
            for(int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];
                if (!node.ContainsKey(currentChar))
                {
                    node.Add(currentChar, new TrieNode());
                }
                node = node.Get(currentChar);
            }
            node.SetEnd();
        }

        // search a prefix or whole key in trie and returns the node where search ends
        public TrieNode SearchPrefix(String word)
        {
            TrieNode node = root;
            for(int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];
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
        // Returns if the word is in the trie
        public bool Search(string word)
        {
            TrieNode node = SearchPrefix(word);
            return node != null && node.IsEnd();
        }
        // Returns if there is any word in the trie that starts with the given prefix
        public bool StartsWith(String prefix)
        {
            TrieNode node = SearchPrefix(prefix);
            return node != null;
        }
    }
}
