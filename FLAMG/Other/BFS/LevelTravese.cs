using FLAMG.Amazon.Easy;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.BFS
{
    public class LevelTravese
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null)
                return result;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count > 0)
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
                result.Add(subList);
            }
            return result;
        }
    }
}
