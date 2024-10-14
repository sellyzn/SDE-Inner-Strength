using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.BinaryTreeBFSProblems
{
    internal class P199_BinaryTreeRightSideView
    {
        /*
        BFS
        右视图只能看见每一层最右侧的节点，层序遍历BFS时，遍历到每一层最后一个节点(index == levelLength)时，加入result即可。
        时间：O(N)
        空间：O(N)
        */
        public IList<int> RightSideView(TreeNode root)
        {
            var result = new List<int>();
            if(root == null)
            {
                return result;
            }
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var index = 0;
            while(queue.Count > 0)
            {
                var length = queue.Count;
                for(int  i = 0; i < length; i++)
                {
                    var node = queue.Dequeue();
                    index++;
                    if(node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if(node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                    if(index == length)
                    {
                        result.Add(node.val);
                    }
                }
            }
            return result;
        }
    }
}
