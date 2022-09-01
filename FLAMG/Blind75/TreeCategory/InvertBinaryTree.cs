using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.TreeCategory
{
    internal class InvertBinaryTree
    {
        //
        // DFS
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;
            var temp = root.left;
            root.left = InvertTree(root.right);
            root.right = InvertTree(temp);
            return root;
        }

        // BFS

    }
}
