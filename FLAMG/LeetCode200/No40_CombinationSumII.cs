using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No40_CombinationSumII
    {
        /// <summary>
        /// DFS Backtracking
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        /// T: O(S), S为所有可行解的长度之和。
        /// S: O(target), 除答案数组外，空间复杂度取决于递归的栈深度，最差情况需要递归O(target)层
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            var result = new List<IList<int>>();
            var sublist = new List<int>();
            int startIndex = 0;
            if (candidates == null || candidates.Length == 0)
                return result;
            DFS(candidates, target, startIndex, sublist, result);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <param name="startIndex"></param> 搜索起点
        /// <param name="sublist"></param>每减去一个元素，目标值变小
        /// <param name="result"></param>
        public void DFS(int[] candidates, int target, int startIndex, IList<int> sublist, IList<IList<int>> result)
        {
            if (target == 0)
            {
                result.Add(new List<int>(sublist));
                return;
            }
            if (target < 0)
                return;
            // 从startIndex开始搜索
            for (int i = startIndex; i < candidates.Length; i++)
            {
                if (candidates[i] > target)
                    return;
                if (i > startIndex && candidates[i] == candidates[i - 1])
                    continue;
                sublist.Add(candidates[i]);
                DFS(candidates, target - candidates[i], i + 1, sublist, result); //注意： 由于每一个元素不可以重复使用，下一轮搜索的起点为 i + 1， 这里非常容易弄错
                sublist.RemoveAt(sublist.Count - 1);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> track = new List<int>();
        int trackSum = 0;
        public IList<IList<int>> CombinationSumII(int[] candidates, int target)
        {
            if (candidates == null || candidates.Length == 0)
                return result;
            Array.Sort(candidates);
            Backtrack1(candidates, 0, target);
            return result;
        }
        public void Backtrack1(int[] candidates, int start, int target)
        {
            if(trackSum == target)
            {
                result.Add(new List<int>(track));
                return;
            }
            if(trackSum > target)
            {
                return;
            }
            for(int i = start; i < candidates.Length; i++)
            {
                if (i > start && candidates[i] == candidates[i - 1])
                    continue;
                track.Add(candidates[i]);
                trackSum += candidates[i];
                Backtrack1(candidates, i + 1, target);
                track.RemoveAt(track.Count - 1);
                trackSum -= candidates[i];
            }
        }

    }
}
