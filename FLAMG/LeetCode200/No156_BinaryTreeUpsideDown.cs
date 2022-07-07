using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No156_BinaryTreeUpsideDown
    {
        
        public TreeNode UpsideDownBinaryTree(TreeNode root)
        {
            if (root == null || root.left == null && root.right == null)
                return root;
            // find new root
            var newRoot = root;
            while(newRoot != null && newRoot.left != null)
                newRoot = newRoot.left;

            // upside-down all nodes from the top (root)
            UpsideDown(root);

            return newRoot;
        }
        public TreeNode UpsideDown(TreeNode node)
        {
            if (node == null || node.left == null && node.right == null)
                return node;
            var root = UpsideDown(node.left);
            root.right = node;
            root.left = node.right;
            node.left = null;
            node.right = null;
            return node;
        }
    }
}
