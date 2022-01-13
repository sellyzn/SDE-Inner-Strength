using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverI
{
    public class BinaryTreePathSum
    {
        List<IList<int>> res = new List<IList<int>>();
        List<int> path = new List<int>();
        public List<IList<int>> BinaryTreePathSumII(TreeNode root, int target)
        {
            Recursive(root, target);
            return res;
        }
        public void Recursive(TreeNode root, int target)
        {
            if (root == null)
                return;
            path.Add(root.val);
            target -= root.val;
            if (target == 0 && root.left == null && root.right == null)
            {
                res.Add(new List<int>(path));
            }
            Recursive(root.left, target);
            Recursive(root.right, target);
            path.RemoveAt(path.Count - 1);
        }



        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null)
            {
                return false;
            }
            if (root.left == null && root.right == null)
            {
                return targetSum == root.val;
            }
            return HasPathSum(root.left, targetSum - root.val) || HasPathSum(root.right, targetSum - root.val);           
        }
    }
}
