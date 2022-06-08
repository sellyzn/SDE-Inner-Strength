using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No102_BinaryTreeLevelOrderTraversal
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if(root == null)
                return result;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                int length = queue.Count;
                var subList = new List<int>();
                for(int i = 0; i < length; i++)
                {
                    var node = queue.Dequeue();
                    subList.Add(node.val);
                    if(node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                result.Add(subList);
            }
            return result;
        }
    }
}
