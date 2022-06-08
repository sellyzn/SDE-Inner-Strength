using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No116_PopulatingNextRightPointersInEachNode
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public Node Connect(Node root)
        {
            if (root == null)
                return root;
            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                var length = queue.Count;
                for(int i = 0; i < length; i++)
                {
                    var node = queue.Dequeue();
                    if (i == length - 1)
                        node.next = null;
                    else
                        node.next = queue.Peek();
                    if(node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
            }
            return root;
        }
    }
}
