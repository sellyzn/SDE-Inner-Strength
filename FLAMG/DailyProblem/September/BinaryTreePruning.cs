using FLAMG.Amazon.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.DailyProblem.September
{
    internal class BinaryTreePruning
    {
        //
        // 递归： 如果 root == null, 返回Null,
        // root.left, root.right递归
        // 如果root.left为空，root.right为空，当前节点的值为0， 同时满足时，表示当前节点为根的原二叉树的所有节点都为0，需要将这棵子树移除，返回空。
        // 后序遍历
        public TreeNode PruneTree(TreeNode root)
        {
            if (root == null)
                return null;
            root.left = PruneTree(root.left);
            root.right = PruneTree(root.right);
            if (root.val == 0 && root.left == null && root.right == null)
                return null;
            return root;
        }
    }
}
