using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No96_UniqueBinarySearchTrees
    {
        /// <summary>
        /// 给定一个有序序列1...n， 为了构建除一个二叉搜索树，可以遍历每个数字i，将该数字作为根节点，将1...(i - 1)序列作为左子树，将(i + 1)...n 序列作为右子树。按照同样的方式构建左子树和右子树。
        /// 
        /// G(n): The number of unique BST for a sequence of length n
        /// F(i, n): the number of unique BST, where the number i is served as the root of BST(1 <= i <= n).
        /// G(n) = Sum[F(i, n)], (1 <= i <= n)
        /// F(i, n) = G(i - 1) * G(n - i)
        /// 由上述两式得出： G(n) = Sum[G(i - 1) * G(n - i)], (1 <= i <= n)
        /// G(0) = 1, G(1) = 1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// T: O(N^2)
        /// S: O(N)
        public int NumTrees_DP(int n)
        {
            var G = new int[n + 1];
            G[0] = 1;
            G[1] = 1;
            for(int i = 2; i <= n; i++)
            {
                for(int j = 1; j <= i; j++)
                {
                    G[i] += G[j - 1] * G[i - j];
                }
            }
            return G[n];
        }
        
        
        
        // DFS
        public int NumTrees(int n)
        {
            if (n == 0)
                return 0;
            return GenerateTrees(1, n).Count;
        }
        public IList<TreeNode> GenerateTrees(int start, int end)
        {
            var allTrees = new List<TreeNode>();
            if(start > end)
            {
                allTrees.Add(null);
                return allTrees;
            }
            for(int i = start; i <= end; i++)
            {
                var leftTrees = GenerateTrees(start, i - 1);
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
