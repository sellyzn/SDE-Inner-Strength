using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.InternVO
{
    internal class BTBottomView
    {
        /*
        层序遍历倒向输出
         */
        public IList<IList<TreeNode>> BTBottomView(TreeNode root)
        {
            var result = new List<IList<TreeNode>>();
            if(root == null)
            {
                return result;
            }
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                var levelSize = queue.Count;
                var levelValues = new List<TreeNode>();
                for(int i = 0; i < levelSize; i++)
                {
                    var node = queue.Dequeue();
                    levelValues.Add(node);
                    if(node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }
                    if(node.Right != null)
                    {
                        queue.Enqueue(node.Right); 
                    }
                }
                result.Insert(0, levelValues); // 插到列表开头
            }
        }
    }
}
