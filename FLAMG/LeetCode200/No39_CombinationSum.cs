using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No39_CombinationSum
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
            if(target == 0)
            {
                result.Add(new List<int>(sublist));
                return;
            }
            if (target < 0)
                return;
            // 从startIndex开始搜索
            for(int i = startIndex; i < candidates.Length; i++)
            {
                if (candidates[i] > target)
                    return;
                sublist.Add(candidates[i]);
                DFS(candidates, target - candidates[i], i, sublist,result); //注意： 由于每一个元素可以重复使用，下一轮搜索的起点依然是i， 这里非常容易弄错
                sublist.RemoveAt(sublist.Count - 1);
            }                
        }


        /*
        什么时候使用 used 数组，什么时候使用 begin 变量
        有些朋友可能会疑惑什么时候使用 used 数组，什么时候使用 begin 变量。这里为大家简单总结一下：

        排列问题，讲究顺序（即[2, 2, 3] 与[2, 3, 2] 视为不同列表时），需要记录哪些数字已经使用过，此时用 used 数组；
        组合问题，不讲究顺序（即[2, 2, 3] 与[2, 3, 2] 视为相同列表时），需要按照某种顺序搜索，此时使用 begin 变量。
        */


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> track = new List<int>();
        int trackSum = 0;
        public IList<IList<int>> CombinationSumI(int[] candidates, int target)
        {
            if (candidates == null || candidates.Length == 0)
                return result;
            Array.Sort(candidates);
            Backtrack1(candidates, 0, target);
            return result;
        }
        public void Backtrack1(int[] candidates, int start, int target)
        {
            if (trackSum == target)
            {
                result.Add(new List<int>(track));
                return;
            }
            if (trackSum > target)
            {
                return;
            }
            for (int i = start; i < candidates.Length; i++)
            {                
                track.Add(candidates[i]);
                trackSum += candidates[i];
                Backtrack1(candidates, i, target);
                track.RemoveAt(track.Count - 1);
                trackSum -= candidates[i];
            }
        }
    }
}
