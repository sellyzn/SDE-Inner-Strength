using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.DailyOct
{
    internal class AddOneRowToTree
    {
        public TreeNode AddOneRow(TreeNode root, int val, int depth)
        {
            if (depth == 1)
            {
                var node = new TreeNode(val);
                node.left = root;
                return node;
            }
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (depth > 2)
            {
                var len = queue.Count;
                for (int i = 0; i < len; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                depth--;
            }
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                var temp = node.left;
                node.left = new TreeNode(val);
                node.left.left = temp;
                temp = node.right;
                node.right = new TreeNode(val);
                node.right.right = temp;
            }
            return root;
        }
    }
}
