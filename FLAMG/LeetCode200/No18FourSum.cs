using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No18FourSum
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            return NSumTarget(nums, 4, 0, target);
        }
        public IList<IList<int>> NSumTarget(int[] nums, int n, int start, int target)
        {
            int len = nums.Length;
            var res = new List<IList<int>>();
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
                        res.Add(new List<int> { left, right });
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
                    var sub = NSumTarget(nums, n - 1, i + 1, target - nums[i]);
                    foreach (var item in sub)
                    {
                        item.Add(nums[i]);
                        res.Add(item);
                    }
                    while (i < len - 1 && nums[i] == nums[i + 1])
                        i++;
                }
            }
            return res;
        }
    }
}
