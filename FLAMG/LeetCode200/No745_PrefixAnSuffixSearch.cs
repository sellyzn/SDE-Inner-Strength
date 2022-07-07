using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    //internal class No745_PrefixAnSuffixSearch
    //{

    //}
    public class WordFilter
    {
        private Dictionary<string, Dictionary<string, int>> map = new Dictionary<string, Dictionary<string, int>>();
        public WordFilter(string[] words)
        {
            for(int i = 0; i < words.Length; i++)
            {
                for(int j = 1; j <= words[i].Length; j++)
                {
                    var prefix = words[i].Substring(0,j);
                    for(int k = 0; k < words[i].Length; k++)
                    {
                        var suffix = words[i].Substring(k);
                        //var suffixMap = map[prefix];
                        //if (suffixMap == null)
                        //{
                        //    suffixMap = new Dictionary<string, int>();
                        //    suffixMap.Add(suffix, i);
                        //    map.Add(prefix, suffixMap);
                        //}
                        //else
                        //{
                        //    suffixMap.Add(suffix, i);
                        //}
                        var suffixMap = new Dictionary<string, int>();
                        if (map.ContainsKey(prefix))
                        {
                            suffixMap[prefix] = i;
                        }
                        else
                        {
                            suffixMap.Add(suffix, i);
                            map.Add(prefix, suffixMap);
                        }
                    }
                }
            }
        }

        public int F(string prefix, string suffix)
        {
            var suffixMap = map[prefix];
            if(suffixMap == null)
            {
                return -1;
            }
            var index = suffixMap[suffix];
            return index == null ? -1 : index;
        }
    }
}
