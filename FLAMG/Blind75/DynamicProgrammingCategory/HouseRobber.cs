using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.DynamicProgrammingCategory
{
    internal class HouseRobber
    {
        // 198. House Robber
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            if(nums.Length == 1)
                return nums[0];
            if(nums.Length == 2)
                return Math.Max(nums[0], nums[1]);
            var dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for(int i = 2; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
            }
            return dp[nums.Length - 1];
        }
        public int Rob_Op(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return nums[0];
            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);
            var maxMount = 0;
            var prev1 = nums[0];
            var prev2 = Math.Max(nums[0], nums[1]);
            for(int i = 2; i < nums.Length; i++)
            {
                maxMount = Math.Max(prev1 + nums[i], prev2);
                prev1 = prev2;
                prev2 = maxMount;
            }
            return maxMount;
        }

        // 213. House Robber II
        /* Circle
        nums: [1,2,3,1]

         */
        public int RobII(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return nums[0];
            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);
            return Math.Max(RobRange(nums, 0, nums.Length - 2), RobRange(nums, 1, nums.Length - 1));
        }
        public int RobRange(int[] nums, int start, int end)
        {
            var length = end - start + 1;
            if (length == 1)
                return nums[start];
            if(length == 2)            
                return Math.Max(nums[start], nums[end]);
            var maxAmount = 0;
            var prev1 = nums[start];
            var prev2 = Math.Max(nums[start], nums[start + 1]);
            for(int i = start + 2; i <= end; i++)
            {
                maxAmount = Math.Max(prev1 + nums[i], prev2);
                prev1 = prev2;
                prev2 = maxAmount;
            }
            return maxAmount;
        }

        // 337. House Robber III
        Dictionary<TreeNode, int> memo = new Dictionary<TreeNode, int>();
        public int RobIII(TreeNode root)
        {
            if (root == null)
                return 0;
            if(memo.ContainsKey(root))
                return memo[root];
            int do_it = root.val + (root.left == null ? 0 : RobIII(root.left.left) + RobIII(root.left.right)) + (root.right == null ? 0 : RobIII(root.right.left) + RobIII(root.right.right));
            int not_do = RobIII(root.left) + RobIII(root.right);
            int res = Math.Max(do_it, not_do);
            memo.Add(root, res);
            return res;
        }
    }
}
