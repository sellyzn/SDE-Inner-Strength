using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No110_BalancedBinaryTree
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// T: O(NlogN), 
        /// S: O(N), the recursion stack may contain all nodes if the tree is skewed.
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;
            return Math.Abs(GetHeight(root.left) - GetHeight(root.right)) <= 1 && IsBalanced(root.left) && IsBalanced(root.right) ? true : false;
        }
        public int GetHeight(TreeNode root)
        {
            if(root == null)
                return 0;
            return 1 + Math.Max(GetHeight(root.left), GetHeight(root.right));
        }
    }
}
