using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No46_Permutation
    {
        /// <summary>
        /// 输入一组不重复的数字，返回他们的全排列
        /// Backtracking
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(n * n!), 算法的复杂度首先受backtrack的调用次数制约，backtrack的调用次数是O(n!)的。
        ///     而对于backtrack调用的每个叶结点（共n!个）， 我们需要将当前答案使用O(n)的时间复制到答案数组中，相乘得时间复杂度为O(n*n!)
        /// S: O(n), n为序列的长度。除答案组以外， 递归深度为O(n)
        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            var curList = new List<int>();
            var used = new bool[nums.Length];

            Backtrack(nums, curList, result, used);
            return result;
        }
        public void Backtrack(int[] nums, IList<int> curList, IList<IList<int>> result, bool[] used)
        {
            // base case 到达叶子节点
            if(curList.Count == nums.Length)
            {
                // 收集叶子节点上的值
                result.Add(new List<int>(curList));
                return;
            }

            for(int i = 0; i < nums.Length; i++)
            {
                // 已经存在track中的元素，不能重复选择
                if (used[i])
                    continue;
                // 做选择
                used[i] = true;
                curList.Add(nums[i]);
                // 进入下一层回溯树
                Backtrack(nums, curList, result, used);
                // 撤销选择
                curList.RemoveAt(curList.Count - 1);
                used[i] = false;
            }            
        }
    }
}
