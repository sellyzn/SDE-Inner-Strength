using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.HashMapSetProblems
{
    internal class P1207_UniqueNumberOfOccurences
    {
        /*
        HashSet + HashMap
        遍历arr, 统计各个元素及其对应的个数 --> HashMap, key：元素，value:元素个数
        另一个变量arrSet --> HashSet类型存储arr各元素的数目
        遍历HashMap中的item，若arrSet中包含item.Value的值，返回false
        最终遍历完，返回true
        时间：O(n)
        空间：O(n)
        */
        public bool UniqueOccurrences(int[] arr)
        {
            var occMap = new Dictionary<int, int>();
            foreach(var num in arr)
            {
                if (occMap.ContainsKey(num))
                {
                    occMap[num]++;
                }
                else
                {
                    occMap[num] = 1;
                }
            }
            var occSet = new HashSet<int>();
            foreach(var item in occMap)
            {
                if (occSet.Contains(item.Value))
                {
                    return false;
                }
                occSet.Add(item.Value);
            }
            return true;
        }
    }
}
