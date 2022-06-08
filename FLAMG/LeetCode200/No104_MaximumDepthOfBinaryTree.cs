using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No104_MaximumDepthOfBinaryTree
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var depth = 0;
            while (queue.Count > 0)
            {
                var length = queue.Count;
                for(var i = 0; i < length; i++)
                {
                    var node = queue.Dequeue();
                    if(node.left != null)
                        queue.Enqueue(node.left);
                    if(node.right != null)
                        queue.Enqueue(node.right);
                }
                depth++;
            }
            return depth;
        }
    }
}
