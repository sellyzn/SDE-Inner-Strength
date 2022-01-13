using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldII
{
    public class UniqueBinarySearchTreeII
    {
        //95. Unique Binary Search Trees II
        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0)
                return new List<TreeNode>();
            return GenerateTrees(1, n);
        }
        public List<TreeNode> GenerateTrees(int start, int end)
        {
            List<TreeNode> allTrees = new List<TreeNode>();
            if (start > end)
            {
                allTrees.Add(null);
                return allTrees;
            }

            //枚举可行根节点
            for (int i = start; i <= end; i++)
            {
                //获得所有可行的左子树集合
                List<TreeNode> leftTrees = GenerateTrees(start, i - 1);
                //获得所有可行的右子树集合
                List<TreeNode> rightTrees = GenerateTrees(i + 1, end);
                //从左子树集合中选出一棵左子树，从右子树集合中选出一棵右子树，拼接到根节点上
                foreach (TreeNode left in leftTrees)
                {
                    foreach (TreeNode right in rightTrees)
                    {
                        TreeNode curTree = new TreeNode(i);
                        curTree.left = left;
                        curTree.right = right;
                        allTrees.Add(curTree);
                    }
                }
            }
            return allTrees;
        }


        //96. Unique Binary Search Trees
        public int NumTrees(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    dp[i] += dp[j - 1] * dp[i - j];
                }
            }
            return dp[n];
        }



    }
}
