using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.HighestFrequency
{
    public class FindLeavesOfBinaryTree
    {
        // Given a binary tree, collect a tree's nodes as if you were doing this: Collect and remove all leaves, repeat until the tree is empty.
        // 思路：计算每个节点的高度height，将相同height的节点放在一个list中。
        public IList<IList<int>> FindLeaves(TreeNode root)
        {
            var result = new List<IList<int>>();
            DFS(root, result);
            return result;

        }
        //返回值是node节点的height
        public int DFS(TreeNode node, IList<IList<int>> result)
        {
            if(node == null)
                return 0;
            var height = Math.Max(DFS(node.left, result), DFS(node.right, result)) + 1;
            var length = result.Count;
            if (height > length)            // result.Count 与 node height之间的关系，关键点
                result.Add(new List<int>());
            result[height - 1].Add(node.val);
            return height;
        }

        public int MinDepth_Recursive(TreeNode root)
        {
            if (root == null)
                return 0;
            var left = MinDepth_Recursive(root.left);
            var right = MinDepth_Recursive(root.right);
            return Math.Min(left, right) + 1;   
        }
        public int MinDepth_BFS(TreeNode root)
        {
            if (root == null)
                return 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var minDepth = 1;
            while(queue.Count > 0)
            {
                var curLength = queue.Count;
                for (int i = 0; i < curLength; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left == null && node.right == null)    // &&: 左右子节点都为空，表示该节点为叶子节点
                        return minDepth;
                    if(node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);    
                }
                minDepth++;
            }
            return minDepth;
        }
        public int MaxDepth_Recursive(TreeNode root)
        {
            if (root == null)
                return 0;
            var left = MaxDepth_Recursive(root.left);
            var right = MaxDepth_Recursive(root.right);
            var maxDepth = Math.Max(left, right) + 1;
            return maxDepth;
        }
        public int MaxDepth_BFS(TreeNode root)
        {
            if (root == null)
                return 0;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var maxDepth = 0;
            while(queue.Count > 0)
            {
                var length = queue.Count;
                for(int i = 0; i < length; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if(node.right != null)
                        queue.Enqueue(node.right);
                }
                maxDepth++;
            }
            return maxDepth;
        }
    }
}
