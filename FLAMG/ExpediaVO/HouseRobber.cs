using FLAMG.LeetCode200;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class HouseRobber
    {
        public int Rob(int[] nums)
        {
            // dp[i]: 前i个房子在满足条件下能偷到的最高金额
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
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);                
            }

            return dp[nums.Length - 1];
        }
        public int RobII(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int n = nums.Length;
            if (n == 1)
                return nums[0];
            if (n == 2)
                return Math.Max(nums[0], nums[1]);
            return Math.Max(RobRange(nums, 0, n - 2), RobRange(nums, 1, n - 1));
            //return Math.Max(RobRange(nums, 1, n - 2), Math.Max(RobRange(nums, 0, n - 2), RobRange(nums, 1, n - 1)));
        }
        public int RobRange(int[] nums, int start, int end)
        {
            int length = end - start + 1;         
            
            if (length == 1)
                return nums[start];
            if(length == 2)
                return Math.Max(nums[start], nums[end]);
            var dp = new int[length];
            dp[0] = nums[start];
            dp[1] = Math.Max(nums[start], nums[start + 1]);
            for (int i = 2; i < length; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[start + i]);
            }
            return dp[length - 1];
        }

        // Binary Tree
        Dictionary<TreeNode, int> memo = new Dictionary<TreeNode, int>();
        public int Rob(TreeNode root)
        {
            if (root == null)
                return 0;
            if (memo.ContainsKey(root))
                return memo[root];
            int doit = root.val + (root.left == null ? 0 : Rob(root.left.left) + Rob(root.left.right)) + (root.right == null ? 0 : Rob(root.right.left) + Rob(root.right.left));
            int notdo = Rob(root.left) + Rob(root.right);
            int res = Math.Max(doit, notdo);
            memo.Add(root, res);
            return res;
        }
    }
}
