using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No144_BinaryTreePreorderTraversal
    {
        /// <summary>
        /// Iteration + Stack
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public IList<int> PreorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
                return result;
            var cur = root;
            var stack = new Stack<TreeNode>();
            while(cur != null || stack.Count > 0)
            {
                while(cur != null)
                {
                    result.Add(cur.val);
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop();
                cur = cur.right;
            }
            return result;
        }
    }
}
