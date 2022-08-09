using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No46_Permutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            var curList = new List<int>();
            var used = new bool[nums.Length];
            BackTrack(nums, curList, result, used);
            return result;
        }
        public void BackTrack(int[] nums, IList<int> curList, IList<IList<int>> result, bool[] used)
        {
            if(curList.Count == nums.Length)
            {
                result.Add(new List<int>(curList));
                return;
            }
            for(int i = 0; i < nums.Length; i++)
            {
                if (used[i])
                    continue;
                used[i] = true;
                curList.Add(nums[i]);
                BackTrack(nums,curList,result,used);
                curList.RemoveAt(curList.Count - 1);
                used[i] = false;
            }
        }
    }
}
