using FLAMG.Amazon.Easy;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.BT
{
    public class BinaryTreeMaxPathSum
    {
        int maxSum = int.MinValue;
        public int MaxPathSum(TreeNode root)
        {
            MaxGain(root);
            return maxSum;
        }
        public int MaxGain(TreeNode node)
        {
            if (node == null)
                return 0;

            //递归计算左右子节点的最大贡献值
            //只有在最大贡献值大于0时，才会选取对应子节点
            int leftGain = Math.Max(MaxGain(node.left), 0);
            int rightGain = Math.Max(MaxGain(node.right), 0);

            //节点的最大路径和取决于该节点的值于该节点的左右子节点的最大贡献值
            int newPathValue = node.val + leftGain + rightGain;

            //更新答案
            maxSum = Math.Max(maxSum, newPathValue);

            //返回节点的最大贡献值
            return node.val + Math.Max(leftGain, rightGain);
        }




        //Path Sum I
        //给定二叉树根节点和目标和整数targetSum，判断该树中是否存在根节点到叶子节点的路径，这条路径上所有节点值相加等于目标值targetSum
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null)
                return false;
            if (root.left == null && root.right == null)
                return root.val == targetSum;
            return HasPathSum(root.left, targetSum - root.val) || HasPathSum(root.right, targetSum - root.val);
        }

        //Path Sum II
        //给定二叉树根节点和目标和整数targetSum，找出所有从根节点到叶子节点路径综合等于目标值targetSum的路径
        List<IList<int>> res = new List<IList<int>>();
        List<int> path = new List<int>();
        public IList<IList<int>> PathSumII(TreeNode root, int targetSum)
        {
            BackTrack(root, targetSum);
            return res;
        }
        public void BackTrack(TreeNode root, int targetSum)
        {
            if (root == null)
                return;
            path.Add(root.val);
            targetSum -= root.val;
            if (targetSum == 0 && root.left == null && root.right == null)
                res.Add(path);
            BackTrack(root.left, targetSum - root.val);
            BackTrack(root.right, targetSum - root.val);
            path.RemoveAt(path.Count - 1);
        }

        //Path Sum III
        //给定一个二叉树的根节点 root ，和一个整数 targetSum ，求该二叉树里节点值之和等于 targetSum 的 路径 的数目.
        //路径 不需要从根节点开始，也不需要在叶子节点结束，但是路径方向必须是向下的（只能从父节点到子节点）.
        int res3;
        public int PathSumIII(TreeNode root, int targetSum)
        {
            if (root == null)
                return 0;
            res3 = RootSum(root, targetSum);
            res3 += PathSumIII(root.left, targetSum - root.val);
            res3 += PathSumIII(root.right, targetSum - root.val);
            return res3;
        }
        /// <summary>
        /// 以节点root为起点向下且满足路径和为targetSum的路径数目
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public int RootSum(TreeNode root, int targetSum)
        {
            int res3 = 0;
            if (root == null)
                return 0;
            if (root.val == targetSum)
                res3++;
            res3 += RootSum(root.left, targetSum - root.val);
            res3 += RootSum(root.right, targetSum - root.val);
            return res3;
        }

        public int PathSumIII_Prefix(TreeNode root, int targetSum)
        {

        }
        public int DFS(TreeNode root, Dictionary<long, int> prefix, long curr, int targetSum)
        {

        }

    }
}
