using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No95_UniqueBinarySearchTreeII
    {
        /// <summary>
        /// Recursion
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// T: O(n * Gn), 生成一个二叉搜索树需要O(n)的时间复杂度，一共有Gn棵二叉搜索树，也就是O(n * Gn)。
        /// S: O(n * Gn), n个点生成的二叉搜索树右Gn棵，每个树有n个节点，因此存储的空间需要O(n * Gn)。递归函数需要O(n)的栈空间。因此总的复杂度为： O(n * Gn)。
        public IList<TreeNode> GenerateTrees(int n)
        {
            if(n == 0)
                return new List<TreeNode>();

            return GenerateTrees(1, n);
        }
        public IList<TreeNode> GenerateTrees(int start, int end)
        {
            var allTrees = new List<TreeNode>();
            if(start > end)
            {
                allTrees.Add(null);     // 这一行非常重要！！！ 叶子节点
                return allTrees;
            }
            // pick up a root
            for(int i = start; i <= end; i++)
            {
                // all possible left subtrees if i is choosen to be a root
                var leftTrees = GenerateTrees(start, i - 1);
                // all possible right subtrees if i is choosen to be a root
                var rightTrees = GenerateTrees(i + 1, end);
                foreach (var left in leftTrees)
                {
                    foreach (var right in rightTrees)
                    {
                        var curTree = new TreeNode(i);
                        curTree.left = left;
                        curTree.right = right;
                        allTrees.Add(curTree);
                    }
                }
            }
            return allTrees;
        }
    }
}
