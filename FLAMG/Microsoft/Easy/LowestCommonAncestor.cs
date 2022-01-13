using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Microsoft.Easy
{
    public class LowestCommonAncestor
    {
        ////////////////////////////////////////////////////
        // Lowest Commin Ancestor of a Binary Search Tree //
        ////////////////////////////////////////////////////
        //
        //BST characteristic + Recursion
        public TreeNode LowestCommonAncestor_BST(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root.val < p.val && root.val > q.val)
                return LowestCommonAncestor_BST(root.right, p, q);
            if (root.val > p.val && root.val > q.val)
                return LowestCommonAncestor_BST(root.left, p, q);
            return root;
        }

        ////////////////////////////////////////////////////
        // Lowest Commin Ancestor of a Binary Tree //
        ////////////////////////////////////////////////////
        ///
        // Recursion + BST
        public TreeNode LowestCommonAncestor_BT(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
                return root;
            TreeNode left = LowestCommonAncestor_BT(root.left, p, q);
            TreeNode right = LowestCommonAncestor_BT(root.right, p, q);
            if (left == null && right == null)
                return null;
            if (left != null && right != null)
                return root;
            return left != null ? left : right;
        }


    }
}
