using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLAMG.Other.Silver.SilverI
{
    public class BinaryTreeInorderTraversal
    {
        public List<int> InorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;
            while (cur != null || stack.Count != 0)
            {
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                if (stack.Count != 0)
                {
                    cur = stack.Pop();
                    res.Add(cur.val);
                    cur = cur.right;
                }
            }
            return res;
        }
    }
}
