using FLAMG.Google.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.DynamicProgramming
{
    public class HourseRobber
    {
        private int[] memo;
        public int Rob(int[] nums)
        {
            // rob[nums[2...]) = Max(rob(nums[3...]), nums[i] + rob(nums[4...]))
            // nums: 1, 2, 3, 1
            // rob[start...]: rob start house

            memo = new int[nums.Length];
            Array.Fill(memo, -1);

            return DP(nums, 0);
        }
        public int DP(int[] nums, int start)
        {
            if (start >= nums.Length)
                return 0;
            if(start == nums.Length + 1)
                return nums[nums.Length - 1];
            int res = Math.Max(DP(nums, start + 1), DP(nums, start + 2) + nums[start]);
            return res;
        }

        public int Rob_DownToUp(int[] nums)
        {
            int n = nums.Length;
            int[] dp = new int[n + 2];
            for(int i = n - 1; i >= 0; i--)
            {
                dp[i] = Math.Max(dp[i + 1], nums[i] + dp[i + 2]);
            }
            return dp[0];
        }

        // 213. 
        public int Rob_II(int[] nums)
        {
            int n = nums.Length;
            if (n == 1)
                return nums[0];
            return Math.Max(RobRange(nums, 1, n - 2), Math.Max(RobRange(nums, 0, n - 2), RobRange(nums, 1, n - 1)));
        }
        public int RobRange(int[] nums, int start, int end)
        {
            int n = nums.Length;
            var length = end - start + 1;
            
            int dp_i_1 = 0;
            int dp_i_2 = 0;
            int dp_i = 0;
            for(int i = end; i >= start; i--)
            {
                dp_i = Math.Max(dp_i_1, nums[i] + dp_i_2);
                dp_i_2 = dp_i_1;
                dp_i_1 = dp_i;
            }
            return dp_i;
        }

        Dictionary<TreeNode, int> memo1 = new Dictionary<TreeNode, int>();
        public int Rob_III(TreeNode root)
        {
            if (root == null)
                return 0;
            if (memo1.ContainsKey(root))
                return memo1[root];
            int do_it = root.val + (root.left == null ? 0 : Rob_III(root.left.left) + Rob_III(root.left.right))
                        +(root.right == null ? 0 : Rob_III(root.right.left) + Rob_III(root.right.right));
            int not_do = Rob_III(root.left) + Rob_III(root.right);
            int res = Math.Max(do_it, not_do);
            memo1.Add(root, res);
            return res;
        }




    }
}
