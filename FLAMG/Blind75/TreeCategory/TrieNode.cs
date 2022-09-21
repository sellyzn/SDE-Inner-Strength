using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.TreeCategory
{
    internal class TrieNode
    {
        private TrieNode[] links; // next, children
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
}
