using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.BinaryTreeDFSProblems
{
    internal class P104_MaximumDepthOfBinaryTree
    {
        /*
        DFS:
        时间：O(n),n为二叉树节点的个数
        空间：O(height)
        */
        public int MaxDepth(TreeNode root)
        {
            if(root == null) 
                return 0;
            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }
        /*
        BFS：
        时间：O(n)
        空间：
        */
        public int MaxDepth_BFS(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var ans = 0;
            while (queue.Count > 0)
            {
                var size = queue.Count;
                for(int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    if(node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if(node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                ans++;
            }
            return ans;
        }
    }
}
