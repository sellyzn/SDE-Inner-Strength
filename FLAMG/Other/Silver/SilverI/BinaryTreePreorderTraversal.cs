using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverI
{
    public class BinaryTreePreorderTraversal
    {
        public List<int> PreorderTravesal(TreeNode root)
        {
            List<int> res = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;
            while (cur != null || stack.Count != 0)
            {
                while (cur != null)
                {
                    res.Add(cur.val);
                    stack.Push(cur);
                    cur = cur.left;
                }
                if (stack.Count != 0)
                {
                    cur = stack.Pop();
                    cur = cur.right;
                }
            }
            return res;
        }
    }
}
