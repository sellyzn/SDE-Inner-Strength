using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No113_PathSumII
    {
        /// <summary>
        /// DFS, Backtrack
        /// T: O(N^2)，最坏情况为完全二叉树，叶子节点个数为N/2个， 对于根节点到每一个叶子节点的路径都符合题目要求，此时路径数目为O(N/2)， 
        /// S: O(N), N是树的节点数。空间复杂度主要取决于栈空间的开销，栈中的元素个数不会超过树的节点数。
        /// </summary>
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> path = new List<int>();
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            if(root == null)
                return result;
            Backtrack(root, targetSum, 0);
            return result;
        }
        public void Backtrack(TreeNode root, int targetSum, int sum)
        {
            if (root == null)
                return;
            path.Add(root.val);
            sum += root.val;
            if(sum == targetSum && root.left == null && root.right == null)
            {
                result.Add(new List<int>(path));
                //return;
            }
            Backtrack(root.left, targetSum, sum);
            Backtrack(root.right, targetSum, sum);
            path.RemoveAt(path.Count - 1);
            sum -= root.val;
        }
    }
}
