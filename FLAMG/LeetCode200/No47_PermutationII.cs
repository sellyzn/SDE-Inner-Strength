using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No47_PermutationII
    {
        /// <summary>
        /// Backtracking
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(n * n!), 算法的复杂度首先受backtrack的调用次数制约，backtrack的调用次数是O(n!)的。
        ///     而对于backtrack调用的每个叶结点（共n!个）， 我们需要将当前答案使用O(n)的时间复制到答案数组中，相乘得时间复杂度为O(n*n!)
        /// S: O(n), n为序列的长度。我们需要O(n)的标记数组，同时在递归的时候栈深度会达到O(n)， 因此总空间复杂度为O(n + n) = O(2n) = O(n)
        /// 
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> track = new List<int>();
        bool[] used;
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            Array.Sort(nums);
            used = new bool[nums.Length];
            Backtrack(nums);
            return result;
        }
        public void Backtrack(int[] nums)
        {
            if(track.Count  == nums.Length)
            {
                result.Add(new List<int>(track));
                return;
            }
            for(int i = 0; i < nums.Length; i++)
            {
                if (used[i])
                    continue;
                if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])
                    continue;
                track.Add(nums[i]);
                used[i] = true;
                Backtrack(nums);
                track.RemoveAt(track.Count - 1);
                used[i] = false;
            }
        }
    }
}
