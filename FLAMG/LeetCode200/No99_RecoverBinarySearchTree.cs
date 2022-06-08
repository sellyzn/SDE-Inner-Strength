using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No99_RecoverBinarySearchTree
    {
        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="root"></param>
        /// T: O(N)
        /// S: O(N)
        public void RecoverTree(TreeNode root)
        {
            // inorder traverse array
            var nums = new List<int>();
            Inorder(root, nums);
            // find the two swapped nums
            var swapped = FindTwoSwapped(nums);
            // recover BST
            Recover(root, 2, swapped[0], swapped[1]);
        }
        public void Inorder(TreeNode root, IList<int> nums)
        {
            if (root == null)
                return;
            Inorder(root.left, nums);
            nums.Add(root.val);
            Inorder(root.right, nums);
        }
        // 如果有两个(交换两个不相邻的数字)，我们记为 i 和 j (i < j 且 a[i] > a[i + 1] && a[j] > a[j + 1])，那么对应被错误交换的节点即为a[i]对应的节点和a[j + 1]对应的节点，分别记为x 和 y。
        // 如果有一个(交换两个相邻的数字)， 我们记为i, 那么对应被错误交换的节点即为a[i]对应的节点和a[i + 1]对应的节点，分别记为x和y。
        public int[] FindTwoSwapped(IList<int> nums)
        {
            int n = nums.Count;
            int index1 = -1, index2 = -1;
            for(int i = 0; i < n - 1; i++)
            {
                if(nums[i + 1] < nums[i])
                {
                    index2 = i + 1;
                    if (index1 == -1)
                        index1 = i;
                    else
                        break;
                }
            }
            int x = nums[index1], y = nums[index2];
            return new int[] { x, y };
        }
        public void Recover(TreeNode root, int count, int x, int y)
        {
            if(root != null)
            {
                if(root.val == x || root.val == y)
                {
                    root.val = root.val == x ? y : x;
                    if (--count == 0)
                        return;
                }
                Recover(root.right, count, x, y);
                Recover(root.left, count, x,y);
            }
        }
    }
}
