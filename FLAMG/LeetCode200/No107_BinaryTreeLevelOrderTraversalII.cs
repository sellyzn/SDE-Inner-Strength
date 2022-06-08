using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No107_BinaryTreeLevelOrderTraversalII
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null)
                return result;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var length = queue.Count;
                var subList = new List<int>();
                for (int i = 0; i < length; i++)
                {
                    var node = queue.Dequeue();
                    subList.Add(node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                result.Insert(0, subList);
            }
            return result;
        }
    }
}
