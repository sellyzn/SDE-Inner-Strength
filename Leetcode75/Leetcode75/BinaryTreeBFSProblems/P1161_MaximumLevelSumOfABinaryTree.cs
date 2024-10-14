using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode75.BinaryTreeBFSProblems
{
    internal class P1161_MaximumLevelSumOfABinaryTree
    {
        /*
        BFS
        
        */
        public int MaxLevelSum(TreeNode root)
        {
            var maxSum = root.val;
            var maxLevel = 1;
            var level = 1;
            var queue = new Queue<TreeNode>();
            while (queue.Count > 0)
            {
                var length = queue.Count;
                var sum = 0;
                for(int i = 0; i < length; i++)
                {
                    var node = queue.Dequeue();
                    sum += node.val;
                    if(node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if(node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                if(sum > maxSum)
                {
                    maxSum = sum;
                    maxLevel = level;
                }
                //maxLevel = maxSum > sum ? maxLevel : level;
                //maxSum = Math.Max(maxSum, sum);
                level++;
            }
            return maxLevel;
        }
    }
}
