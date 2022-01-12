using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverI
{
    public class InvertBinaryTree
    {
        public TreeNode InvertBinaryTreeI(TreeNode root)
        {
            if (root == null)
                return null;
            TreeNode temp = root.left;
            root.left = InvertBinaryTreeI(root.right);
            root.right = InvertBinaryTreeI(temp);
            return root;
        }


        public void InvertBinaryTree_Re(TreeNode root)
        {
            if (root == null)
                return;
            TreeNode tmp = root.left;
            TreeNode left = root.right;
            root.right = tmp;
            InvertBinaryTree_Re(root.left);
            InvertBinaryTree_Re(root.right);
        }
        public void InvertBinaryTreeI_NonRe(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();

                TreeNode t = node.left;
                node.left = node.right;
                node.right = t;

                if (node.left != null)
                {
                    stack.Push(node.left);
                }
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
            }
        }

        public void InvertBinaryTree_Inorder(TreeNode root)
        {
            if (root == null)
                return;
            var stack = new Stack<TreeNode>();
            while(root != null | stack.Count > 0)
            {
                while(root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                TreeNode tmp = root.left;
                root.left = root.right;
                root.right = tmp;

                root = root.left;
            }
        }
    }
}
