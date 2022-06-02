using FLAMG.Amazon.Easy;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Amazon.Medium
{
    public class DeleteNodeinaBST
    {
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
                return root;
            if(root.val == key)
            {
                if (root.left == null)
                    return root.right;
                if (root.right == null)
                    return root.left;
                //将root的左子树拼接到root.right为根的左子树最下边
                var node = root.right;
                while(node.left != null)
                {
                    node = node.left;
                }
                node.left = root.left;
                root = root.right;

            }else if(root.val < key)
            {
                root.right = DeleteNode(root.right, key);
            }else
            {
                root.left = DeleteNode(root.left, key);
            }
            return root;
        }
        
    }
}
