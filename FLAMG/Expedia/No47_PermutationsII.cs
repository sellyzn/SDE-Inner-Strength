using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No47_PermutationsII
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            IList<int> track = new List<int>();
            bool[] used = new bool[nums.Length];
            Backtrack(nums, track, result, used);
            return result;
        }
        public void Backtrack(int[] nums, IList<int> track, IList<IList<int>> result, bool[] used)
        {
            if(track.Count == nums.Length)
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
                used[i] = true;
                track.Add(nums[i]);
                Backtrack(nums, track, result, used);
                track.RemoveAt(track.Count - 1);
                used[i] = false;
            }
        }
    }
}
