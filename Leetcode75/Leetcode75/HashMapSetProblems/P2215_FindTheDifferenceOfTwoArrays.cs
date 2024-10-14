using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.HashMapSetProblems
{
    internal class P2215_FindTheDifferenceOfTwoArrays
    {
        /*
        注意answer的类型
        answer = new IList<int>[2];
        answer[0] = new List<int>();
        answer[1] = new List<int>();
        set1: 存储nums1中的元素
        set2: 存储nums2中的元素
        遍历一遍nums2，将set1中包含nums2的元素移除
        遍历一遍nums1,将set2中包含nums1的元素移除
        返回answer
        时间：O(n + m)
        空间：O(n + m)
        */
        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            var answer = new IList<int>[2];
            
            var set1 = new HashSet<int>();
            var set2 = new HashSet<int>();
            foreach(var num in nums1)
            {
                set1.Add(num);
            }
            foreach(var num in nums2)
            {
                set2.Add(num);
            }
            foreach(var num in nums1)
            {
                set2.Remove(num);
            }
            foreach (var num in nums2)
            {
                set1.Remove(num);
            }
            answer[0] = new List<int>(set1);
            answer[1] = new List<int>(set2);
            return answer;
        }
    }
}
