using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No49_GroupAnagrams
    {
        /// <summary>
        /// sorted string + Dictionary<string, IList<string>>
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        /// T: O(NKlogK),循环遍历为O(N)，在循环里面，对每一个字符串排序，O(KlogK), 所以总的时间复杂度为O(NKlogK)  
        /// S: O(NK), 需要用哈希表存储全部字符串
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var result = new List<IList<string>>();
            if (strs == null || strs.Length == 0)
                return result;
            var map = new Dictionary<string, IList<string>>();
            foreach(var str in strs)
            {
                var strArr = str.ToCharArray();
                Array.Sort(strArr);
                var key = new string(strArr);
                IList<string> list;
                if (!map.ContainsKey(key))
                {
                    list = new List<string>();
                    list.Add(str);
                    map.Add(key, list);
                }
                else
                {
                    list = map[key];
                    list.Add(str);
                    map[key] = list;
                }                
            }
            return new List<IList<string>>(map.Values);
        }
    }
}
