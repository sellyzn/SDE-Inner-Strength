using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverI
{
    public class MaxDepthOfBinaryTree
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1; 
        }
    }
}
