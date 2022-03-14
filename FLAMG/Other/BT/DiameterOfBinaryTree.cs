using FLAMG.Amazon.Easy;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.BT
{

    public class DiameterOfBinaryTree
    {
        int res;
        public int DiameterOfBT(TreeNode root)
        {
            if (root == null)
                return 0;
            res = 1;
            Depth(root);
            return res - 1;
        }
        public int Depth(TreeNode root)
        {
            if (root == null)
                return 0;
            int left = Depth(root.left);
            int right = Depth(root.right);
            res = Math.Max(res, left + right + 1);
            return Math.Max(left, right) + 1;
        }
    }
    
}
