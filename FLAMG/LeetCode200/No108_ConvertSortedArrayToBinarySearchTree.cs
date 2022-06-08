using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No108_ConvertSortedArrayToBinarySearchTree
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O(N), we visited each node exactly once.
        /// S: O(logN), the recursion stack requires O(logN) space because the tree is height-balanced.
        public TreeNode SortedArrayToBST(int[] nums)
        {
            int n = nums.Length;
            if(n == 0)
                return null;
            return BuildBST(nums, 0, n - 1);
        }
        public TreeNode BuildBST(int[] nums, int left, int right)
        {
            if (left > right)
                return null;

            int mid = left + (right - left) / 2;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = BuildBST(nums, left, mid - 1);
            root.right = BuildBST(nums, mid + 1, right);
            return root;
        }
    }
}
