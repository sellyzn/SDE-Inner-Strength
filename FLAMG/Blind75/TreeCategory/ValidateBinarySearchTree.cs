using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.TreeCategory
{
    internal class ValidateBinarySearchTree
    {
        // 98. Validate Binary Search Tree
        // DFS Range
        // Time complexity : O(N) since we visit each node exactly once.
        // Space complexity : O(N) since we keep up to the entire tree.
        public bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, null, null);
        }
        public bool IsValidBST(TreeNode root, TreeNode min, TreeNode max)
        {
            if (root == null)
                return true;
            if (min != null && root.val < min.val)
                return false;
            if (max != null && root.val > max.val)
                return false;
            return IsValidBST(root.left, min, root) && IsValidBST(root.right, root, max);
        }
    }
}
