using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No78_Subsets
    {
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> track = new List<int>();
        public IList<IList<int>> Subsets(int[] nums)
        {           
            Backtrack(nums, 0);
            return result;
        }
        public void Backtrack(int[] nums, int start)
        {
            //前序位置，每个节点的值都是一个子集
            result.Add(new List<int>(track));
            for (int i = start; i < nums.Length; i++)
            { 
                // 做选择
                track.Add(nums[i]);
                // 通过start参数控制树枝的遍历，避免产生重复的子集
                Backtrack(nums, i + 1);
                // 撤销选择
                track.RemoveAt(track.Count - 1);
            }
        }
    }
}
