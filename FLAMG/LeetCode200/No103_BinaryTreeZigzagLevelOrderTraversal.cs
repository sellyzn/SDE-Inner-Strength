using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No103_BinaryTreeZigzagLevelOrderTraversal
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null)
                return result;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var level = 0;
            while (queue.Count > 0)
            {
                level++;
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
                if (level % 2 == 1)
                    result.Add(subList);
                else
                {
                    var left = 0;
                    var right = subList.Count - 1;
                    while (left < right)
                    {
                        var temp = subList[left];
                        subList[left] = subList[right];
                        subList[right] = temp;
                        left++;
                        right--;
                    }
                    result.Add(subList);
                }
            }
            return result;
        }
    }
}
