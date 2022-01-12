using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldII
{
    public class HouseRober
    {
        //打家劫舍系列问题
        public int HouseRobber1(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int n = nums.Length;
            int[] dp = new int[n + 2];
            dp[n + 1] = 0;
            dp[n] = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                dp[i] = Math.Max(dp[i + 1], nums[i] + dp[i + 2]);
            }
            return dp[0];
        }

        public int HouseRobber2(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int n = nums.Length;
            if (n == 1)
                return nums[0];
            return Math.Max(RobRange(nums, 0, n - 2), RobRange(nums, 1, n - 1));
        }
        public int RobRange(int[] nums, int start, int end)
        {
            int dp_i_1 = 0, dp_i_2 = 0;
            int dp_i = 0;
            for (int i = end; i >= start; i--)
            {
                dp_i = Math.Max(dp_i_1, nums[i] + dp_i_2);
                dp_i_2 = dp_i_1;
                dp_i_1 = dp_i;
            }
            return dp_i;
        }

        Dictionary<TreeNode, int> memo = new Dictionary<TreeNode, int>();
        public int HouseRobber3(TreeNode root)
        {
            if (root == null)
                return 0;
            if (memo.ContainsKey(root))
                return memo[root];
            int do_it = root.val
                        + (root.left == null ? 0 : HouseRobber3(root.left.left) + HouseRobber3(root.left.right))
                        + (root.right == null ? 0 : HouseRobber3(root.right.left) + HouseRobber3(root.right.right));
            int not_do = HouseRobber3(root.left) + HouseRobber3(root.right);
            int res = Math.Max(do_it, not_do);
            memo.Add(root, res);
            return res;
        }
    }
}
