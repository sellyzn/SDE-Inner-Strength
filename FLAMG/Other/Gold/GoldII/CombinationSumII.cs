using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldII
{
    public class CombinationSumII
    {
        //leetcode39
        //数组中数字可重复使用，结果中子序列不重复
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            var result = new List<IList<int>>();
            var subset = new List<int>();
            int startIndex = 0;
            if (candidates == null || candidates.Length == 0)
                return result;
            DFS1(candidates, target, startIndex, subset, result);
            return result;
        }
        public void DFS1(int[] candidates, int target, int startIndex, IList<int> subset, IList<IList<int>> result)
        {
            if (target == 0)
            {
                result.Add(new List<int>(subset));
                return;
            }
            if (target < 0)
            {
                return;
            }
            for (int i = startIndex; i < candidates.Length; i++)
            {
                if (candidates[i] > target)
                    return;
                subset.Add(candidates[i]);
                DFS1(candidates, target - candidates[i], i, subset, result);   //数组元素可重复使用，startIndex不变，依然为当前元素位置i
                subset.RemoveAt(subset.Count - 1);
            }
        }


        //leetcode40
        //数组中元素不可以重复使用，结果中子序列不重复
        //回溯
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            var res = new List<IList<int>>();
            var subset = new List<int>();
            int startIndex = 0;
            if (candidates == null || candidates.Length == 0)
                return res;
            DFS2(candidates, target, startIndex, subset, res);
            return res;
        }
        public void DFS2(int[] candidates, int target, int startIndex, IList<int> subset, IList<IList<int>> res)
        {
            if(target == 0)
            {
                res.Add(new List<int>(subset));
                return;
            }

            for(int i = startIndex; i < candidates.Length; i++)
            {
                if (candidates[i] > target)
                    break;
                if (i > startIndex && candidates[i] == candidates[i - 1]) //注意顺序： i > startIndex在前，要先判断。 剪枝
                    continue;
                subset.Add(candidates[i]);
                DFS2(candidates, target - candidates[i], i + 1, subset, res);   //数组元素不可重复使用，startIndex要+1， 即 i + 1
                subset.RemoveAt(subset.Count - 1);
            }
        }

        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            var res = new List<IList<int>>();
            var startNumber = 1;
            var subset = new List<int>();
            DFS3(k, n, startNumber, subset, res);
            return res;
        }
        public void DFS3(int k, int n, int startNumber, IList<int> subset, IList<IList<int>> res)
        {
            if(n == 0 && k == 0)
            {
                res.Add(new List<int>(subset));
                return;
            }
            for(int i = startNumber; i <= 9; i++)
            {
                if (i > n)
                    break;
                subset.Add(i);
                DFS3(k - 1, n - i, i + 1, subset, res);
                subset.RemoveAt(subset.Count - 1);
            }
        }


        //public int CombinationSum4(int[] nums, int target)
        //{
        //    //int res = 0;
        //    var res = new List<IList<int>>();
        //    var subset = new List<int>();
        //    int startIndex = 0;
        //    DFS4(nums, target, 0, subset, res);
        //    return res.Count;

        //}
        //public void DFS4(int[] nums, int target, int startIndex, IList<int> subset, IList<IList<int>> res)
        //{
        //    if(target == 0)
        //    {
        //        res.Add(new List<int>(subset));
        //        return;
        //    }
        //    for(int i = startIndex; i < nums.Length; i++)
        //    {
        //        if (nums[startIndex] > target)
        //            break;
        //        subset.Add(nums[i]);
        //        DFS4(nums, target - nums[i], i, subset, res);
        //        subset.RemoveAt(subset.Count - 1);
        //    }
        //}


    }
}
