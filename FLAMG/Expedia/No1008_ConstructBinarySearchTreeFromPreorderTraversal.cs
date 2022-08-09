using FLAMG.LeetCode200;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No1008_ConstructBinarySearchTreeFromPreorderTraversal
    {
        public TreeNode BstFromPreorder(int[] preorder)
        {
            return Build(preorder, 0, preorder.Length - 1);            
        }
        public TreeNode Build(int[] preorder, int start, int end)
        {
            if(start > end)
                return null;             
            var root = new TreeNode(preorder[start]);
            if (start == end)
                return root;
            // int rightStart = start;
            //for (int i = start; i < preorder.Length; i++)
            //{
            //    if (preorder[i] > root.val)
            //    {
            //        rightStart = i;
            //        break;
            //    }
            //}
            int l = start + 1, r = end;
            // 在[l, r]范围内，找出第一个大于root的值的索引
            while(l < r)
            {
                int mid = l + (r - l) / 2;
                if (preorder[mid] > root.val)
                    r = mid;
                else
                    l = mid + 1;
            }
            
            root.left = Build(preorder, start + 1, r - 1);
            root.right = Build(preorder, r, end);
            return root;
        }

        public int FindTheFirstIndex(int[] nums, int target)
        {
            // nums = [2,1,3,5,7,9], target = 4
            int left = 0, right = nums.Length - 1;
            while(left < right)
            {
                int mid = left + (right - left) / 2;
                if (mid > target)
                    right = mid;
                else
                    left = mid + 1;
            }
            return right;
        }
    }
}
