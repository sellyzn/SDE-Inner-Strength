using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No90_SubsetsII
    {
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> track = new List<int>();
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);   //有可重复元素，就先排序，让相同的元素靠在一起
            Backtrack(nums, 0);
            return result;
        }
        public void Backtrack(int[] nums, int start)
        {
            //前序位置，每个节点的值都是一个子集
            result.Add(new List<int>(track));
            for (int i = start; i < nums.Length; i++)
            {
                // 剪枝逻辑，值相同的相邻树枝，只遍历第一条
                if (i > start && nums[i] == nums[i - 1])
                    continue;
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
