using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.BinaryTreeDFSProblems
{
    internal class P236_LowestCommonAncestorOfABinaryTree
    {
        /*
        DFS
        时间：O(N)
        空间：O(N)
        */
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if(root == null || root == p || root == q)
            {
                return root;
            }
            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);
            if(left != null && right != null)
            {
                return root;
            }else if(left == null && right == null)
            {
                return null;
            }
            else
            {
                return left == null ? right : left;
            }
        }
    }
}
