using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No145BinaryTreePostorderTraversal
    {
        /// <summary>
        /// Iterate + stack
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// 
        public IList<int> PostorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if(root == null)
                return result;
            var stack = new Stack<TreeNode>();
            var cur = root;
            var lastVisit = root;
            while(cur != null || stack.Count > 0)
            {
                while(cur != null)
                {
                    //result.Insert(0, cur.val);
                    stack.Push(cur);
                    cur = cur.left;
                }
                cur = stack.Pop();
                if(cur.right == null || lastVisit == cur.right)
                {
                    result.Add(cur.val);
                    lastVisit = cur;
                    cur = null;
                }
                else
                {
                    stack.Push(cur);
                    cur = cur.right;
                }
            }
            return result;
        }
    }
}
