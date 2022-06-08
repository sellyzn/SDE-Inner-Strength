using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No94_BinaryTreeInorderTraversal
    {
        /// <summary>
        /// Recursive Aprroach/ Iterating method using stack
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// 
        /// Recursive approach
        /// T: O(N), the recursive function is T(n) = 2 * T(n / 2) + 1
        /// S: O(N), the worset case space required is O(N), and in the average case is's O(logN) where N is number of nodes.
        /// 
        /// Iterating method using stack:
        /// T: O(N)
        /// S: O(N)
        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if(root == null)
                return result;
            var stack = new Stack<TreeNode>();
            var cur = root;
            while(cur != null || stack.Count > 0)
            {
                while(cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop();
                result.Add(cur.val);
                cur = cur.right;
            }
            return result;
        }
    }
}
