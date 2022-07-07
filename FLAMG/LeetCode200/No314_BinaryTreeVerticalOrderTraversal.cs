using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    public class NodeInfomation
    {
        public TreeNode node;
        public int column;
        public Dictionary<TreeNode, int> nodeInfo;
        public NodeInfomation(TreeNode node, int column)
        {
            nodeInfo = new Dictionary<TreeNode, int>();
            this.node = node;
            this.column = column;
            nodeInfo.Add(node, column);
        }
    }
    internal class No314_BinaryTreeVerticalOrderTraversal
    {
        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null)
                return result;

            var queue = new Queue<Dictionary<TreeNode, int>>();
            var rootInfo = new Dictionary<TreeNode, int>() { { root, 0 } };
            //var queue = new Queue<NodeInfomation>();
            //queue.Enqueue(new NodeInfomation(root, 0));
            while(queue.Count > 0)
            {
                var nodeInfo = queue.Dequeue();
                var node = nodeInfo.node;
                var column = nodeInfo.column;
                
                if(node == null)
                {
                    if(result[column] == null)
                        result[column] = new List<int>();
                    result[column].Add(node.val);
                    queue.Enqueue(new NodeInfomation(node.left, column - 1));
                    queue.Enqueue(new NodeInfomation(node.right, column + 1));
                }
            }
            return result;
        }
    }
}
