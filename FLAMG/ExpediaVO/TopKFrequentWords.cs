using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    public class NodeEntry
    {
        public string Key { get; set; }
        public int Value { get; set; }
        public NodeEntry(string key, int value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
    internal class TopKFrequentWords
    {
        public IList<string> TopKFrequent(string[] words, int k)
        {
            var result = new List<string>();
            var dict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (dict.ContainsKey(word))
                    dict[word]++;
                else
                    dict.Add(word, 1);
            }
            var list = new List<NodeEntry>();
            foreach (var word in dict)
            {                
                list.Add(new NodeEntry(word.Key, word.Value));
            }
            list.Sort(
                delegate (NodeEntry node1, NodeEntry node2)
                {
                    return node1.Value == node2.Value ? node1.Key.CompareTo(node2.Key) : node2.Value - node1.Value;
                }
                );
            //list = list.OrderByDescending(x => x.Value).ToList();
            var len = list.Count >= k ? k : list.Count;
            for(int i = 0; i < len; i++)
            {
                result.Add(list[i].Key);
            }
            return result;
        }
        public IList<string> TopKFrequent1(string[] words, int k)
        {
            var result = new List<string>();
            var dict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (dict.ContainsKey(word))
                    dict[word]++;
                else
                    dict.Add(word, 1);
            }
            var res = new List<string>();
            foreach (var item in dict)
            {
                res.Add(item.Key);
            }
            res.Sort(
                delegate(string word1, string word2)
                {
                    return dict[word1] == dict[word2] ? word1.CompareTo(word2) : dict[word2] - dict[word1];
                }
                );
            return res.GetRange(0, k);
        }
    }
}
