using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No199_BinaryTreeRightSideView
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public IList<int> RightSideView(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
                return result;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var length = queue.Count;
                var index = 0;
                for (int i = 0; i < length; i++)
                {
                    var node = queue.Dequeue();
                    index++;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                    if (index == length)
                        result.Add(node.val);
                }
            }
            return result;
        }
    }
}
