using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    public class CustomizedComparer : IComparer<int[]>
    {
        public int Compare(int[] o1, int[] o2)
        {
            return o1[0] == o2[0] ? o1[1] - o2[1] : o2[0] - o1[0];
        }
    }
    
    internal class No406_QueueReconstructionByHeight
    {
        /// <summary>
        /// 数对排序： 元素1降序排序，元素2升序排序
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        /// T: O(N^2), O(NlogN)的时间进行排序，随后需要O(N^2)的时间遍历每一个人并将他们放入队列中。
        /// S: O(logN)，排序需要使用的栈空间
        public int[][] ReconstructionQueue(int[][] people)
        {
            Array.Sort(people, new CustomizedComparer());
            //people = people.OrderByDescending(x => x[0]).ToArray();
            //people = people.OrderBy(x => x,new CustomizedComparer()).ToArray();

            var list = new List<int[]>();
            for(int i = 0; i < people.Length; i++)
            {
                if(list.Count > people[i][1])
                {
                    //结果集中元素个数大于第i个人前面应有的人数时，将第i个人插入到结果集的 people[i][1]位置
                    list.Insert(people[i][1], people[i]);
                }
                else
                {
                    //结果集中元素个数小于等于第i个人前面应有的人数时，将第i个人追加到结果集的后面
                    list.Add(people[i]);
                }
            }
            return list.ToArray();
        }
    }
}
