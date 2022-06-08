using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No98_ValidateBinarySearchTree
    {
        public bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, null, null);

        }
        public bool IsValidBST(TreeNode root, TreeNode min, TreeNode max)
        {
            if (root == null)
                return true;
            if (min != null && root.val <= min.val)
                return false;
            if (max != null && root.val >= max.val)
                return false;
            return IsValidBST(root.left, min, root) && IsValidBST(root.right, root, max);
        }


        //以下方法错误， 例如： [5,4,6,null,null,3,7] 应该返回结果false，如下方法返回的结果是true。
        public bool IsValidBST_1(TreeNode root)
        {
            if (root == null)
                return true;
            if(root.left != null && root.right != null)
            {
                return root.val > root.left.val && root.val < root.right.val && IsValidBST(root.left) && IsValidBST(root.right);
            }else if(root.left != null)
            {
                return root.left.val < root.val && IsValidBST(root.left);
            }else if(root.right != null)
            {
                return root.right.val > root.val && IsValidBST(root.right);
            }
            else
            {
                return true;
            }
        }
    }
}
