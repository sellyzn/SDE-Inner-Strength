using FLAMG.LeetCode200;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class ClosestLeafInABinaryTree
    {
        /// <summary>
        /// 1. use DFS, find the TreeNode whose value is k, mark as kNode. at the same time, update hashmap with child->parent relationship
        /// 2. Then do BFS from kNode, if any of left child, right child and parent is not null, put it into the queue. The first met leaf node is the nearest leaf node to kNode.
        /// before update node to parent map, we need to check parent != null.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// 

        TreeNode target;
        public int FindClosestLeaf(TreeNode root, int k)
        {
            if(root == null)
                return -1;
            var nodeToParent = new Dictionary<TreeNode, TreeNode>();
            DFS(root, null, nodeToParent, k);
            if (target == null)
                return -1;

            var queue = new Queue<TreeNode>();
            var visited = new HashSet<int>();
            queue.Enqueue(target);
            visited.Add(k);
            while(queue.Count > 0)
            {
                var cur = queue.Dequeue();
                if (cur.left == null && cur.right == null)
                    return cur.val;
                if(cur.left != null && !visited.Contains(cur.left.val))
                {
                    queue.Enqueue(cur.left);
                    visited.Add(cur.left.val);
                }
                if(cur.right != null && !visited.Contains(cur.right.val){
                    queue.Enqueue(cur.right);
                    visited.Add(cur.right.val);
                }
                if(nodeToParent.ContainsKey(cur) && !visited.Contains(nodeToParent[cur].val))
                {
                    queue.Enqueue(nodeToParent[cur]);
                    visited.Add(nodeToParent[cur].val);
                }
            }
            return -1;
        }
        public void DFS(TreeNode node, TreeNode parent, Dictionary<TreeNode, TreeNode> nodeToParent, int k)
        {
            if (node == null)
                return;
            if (parent != null)
                nodeToParent.Add(node, parent);
            if (node.val == k)
                target = node;
            DFS(node.left, node, nodeToParent, k);
            DFS(node.right, node, nodeToParent, k);
        }
    }
}
