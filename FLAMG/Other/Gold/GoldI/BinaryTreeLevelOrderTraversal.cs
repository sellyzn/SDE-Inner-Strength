using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldI
{
    public class BinaryTreeLevelOrderTraversal
    {
        //Queue --> Level order traversal
        //BFS
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var res = new List<IList<int>>();
            if (root == null)
                return res;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                int length = queue.Count;
                var subList = new List<int>();
                while(length > 0)
                {
                    var node = queue.Dequeue();
                    subList.Add(node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                    length--;
                }
                res.Add(subList);
            }
            return res;
        }

    }
}
