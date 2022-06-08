using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No49_GroupAnagrams
    {
        /// <summary>
        /// Sort + HashMap
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        /// T: O(nklogk), k是数组strs中字符串的最大长度，排序算法时间复杂度位O(klogk)； n为数组strs的长度， 遍历数组所有元素时间复杂度为O(n)， 因此总的时间复杂度为O(nklogk)
        /// S: O(nk), 需要用哈希表存储全部字符串
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            // Dictionary<string, IList<string>>
            // sort
            var map = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                var strArr = str.ToCharArray();
                Array.Sort(strArr);
                var key = new string(strArr);
                IList<string> list;
                if (map.ContainsKey(key))
                    list = map[key];
                else
                    list = new List<string>();
                list.Add(str);
                map[key] = list;
            }
            return new List<IList<string>>(map.Values);
        }
    }
}
