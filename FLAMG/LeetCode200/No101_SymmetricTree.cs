using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No101_SymmetricTree
    {
        /// <summary>
        /// Recursive
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;
            
            return IsSymmetricTwo(root.left, root.right);
        }
        public bool IsSymmetricTwo(TreeNode node1, TreeNode node2)
        {
            if(node1 == null && node2 == null)
                return true;
            if (node1 == null || node2 == null)
                return false;
            
            if (node1.val != node2.val)
                return false;
            return IsSymmetricTwo(node1.left, node2.right) && IsSymmetricTwo(node1.right, node2.left);
        }
    }
}
