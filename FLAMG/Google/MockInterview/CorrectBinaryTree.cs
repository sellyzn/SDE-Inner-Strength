using FLAMG.Google.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.MockInterview
{
    public class CorrectBinaryTree
    {
        // BFS
        // 所有节点的值不相同
        // fromNode != toNode
        // fromNod 和 toNode在相同的depth
        // toNode是fromNode的右孩子
        // invalide node的右孩子right child不正确的指向相同depth的节点，即处在同一层
        public TreeNode CorrectBinaryTree_Mock(TreeNode root)
        {
            if(root == null)
                return null;
            var queue = new Queue<TreeNode>();
            var visited = new HashSet<TreeNode>();
            TreeNode toDelete = null;
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                var curLevel = queue.Count;
                for (int i = 0; i < curLevel; i++)
                {
                    var node = queue.Dequeue();
                    if(node.right != null && visited.Contains(node.right))
                    {
                        toDelete = node;
                        DeleteNode(root, toDelete);
                        return root;
                    }
                    if(node.left != null)
                    {
                        queue.Enqueue(node.left);
                        visited.Add(node.left);
                    }
                    if(node.right != null)
                    {
                        queue.Enqueue(node.right);
                        visited.Add(node.right);
                    }
                }
            }
            return root;
        }
        public TreeNode DeleteNode(TreeNode root, TreeNode toDelete)
        {
            if (root == null)
                return null;
            if (root.val == toDelete.val)
                return null;
            root.left = DeleteNode(root.left, toDelete);
            root.right = DeleteNode(root.right, toDelete);
            return root;
        }
    }
}
