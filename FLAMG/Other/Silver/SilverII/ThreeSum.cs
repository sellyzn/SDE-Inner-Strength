using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverII
{
    public class ThreeSum
    {
        public IList<IList<int>> ThreeSumSolution(int[] nums)
        {
            Array.Sort(nums);
            return nSumTarget(nums, 3, 0, 0);
        }
        public IList<IList<int>> nSumTarget(int[] nums, int n, int start, int target)
        {
            int len = nums.Length;
            List<IList<int>> res = new List<IList<int>>();

            if (n < 2 || len < n)
                return res;
            if (n == 2)
            {
                int lo = start, hi = len - 1;
                while (lo < hi)
                {
                    int sum = nums[lo] + nums[hi];
                    int left = nums[lo], right = nums[hi];
                    if (sum < target)
                    {
                        while (lo < hi && nums[lo] == left)
                            lo++;
                    }
                    else if (sum > target)
                    {
                        while (lo < hi && nums[hi] == right)
                            hi--;
                    }
                    else
                    {
                        List<int> sub = new List<int> { left, right };
                        res.Add(sub);
                        while (lo < hi && nums[lo] == left)
                            lo++;
                        while (lo < hi && nums[hi] == right)
                            hi--;
                    }
                }
            }
            else
            {
                for (int i = start; i < len; i++)
                {
                    IList<IList<int>> sub = nSumTarget(nums, n - 1, i + 1, target - nums[i]);
                    foreach (var arr in sub)
                    {
                        arr.Add(nums[i]);
                        res.Add(arr);
                    }
                    while (i < len - 1 && nums[i] == nums[i + 1])
                        i++;
                }
            }

            return res;
        }
    }
}
