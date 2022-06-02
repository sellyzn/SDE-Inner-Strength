using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No112PathSum
    {
        /// <summary>
        /// DFS Backtracking
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null)
                return false;
            targetSum -= root.val;
            if(root.left == null && root.right == null)
                return targetSum == 0;
            return HasPathSum(root.left, targetSum) || HasPathSum(root.right, targetSum);            
        }
    }
}
