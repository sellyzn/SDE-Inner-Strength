using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    /// <summary>
    /// T: O(N)
    /// S: O(N)
    /// </summary>
    internal class No173_BinarySearchTreeIterator
    {
        IList<int> list = new List<int>();
        public No173_BinarySearchTreeIterator(TreeNode root)
        {
            InorderTraversal(root);
        }
        public int Next()
        {
            try
            {
                var item = list[0];
                list.RemoveAt(0);
                return item;                
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException("Next is null", e);
            }
        }

        public bool HasNext()
        {
            if (list.Count > 0)
                return true;
            else
                return false;
        }
        public void InorderTraversal(TreeNode root)
        {
            if (root == null)
                return;
            InorderTraversal(root.left);            
            list.Add(root.val);
            InorderTraversal(root.right);            
        }
    }
}
