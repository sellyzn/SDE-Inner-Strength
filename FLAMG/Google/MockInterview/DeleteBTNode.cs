using FLAMG.Google.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.MockInterview
{
    internal class DeleteBTNode
    {
        // 1110
        // 
        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            var result = new List<TreeNode>();
            var set = new HashSet<int>();
            if (root == null)
                return result;
            //将delete转换为set方便进行判断
            foreach (var num in to_delete)
            {
                set.Add(num);
            }
            //如果什么都不需要删掉，那么结果集中应该包含本棵树
            result.Add(root);
            Delete(root, set, result);
            return result;
        }
        // 删除以node为根的树中，节点值出现在delete中的节点，更新结果集result，并返回删除后新的根节点
        public TreeNode Delete(TreeNode node, HashSet<int> delete, List<TreeNode> result)
        {
            // base case
            if (node == null)
                return null;
            // 先递归左右子树
            node.left = Delete(node.left, delete, result);
            node.right = Delete(node.right, delete, result);
            if (delete.Contains(node.val))      //当node节点需要被删掉时，更新结果集
            {
                if(node.left != null)
                    result.Add(node.left);
                if(node.right != null)
                    result.Add(node.right);
                // 如果结果集里已经包含node为根的树，就把结果集里的node删掉
                if(result.Contains(node))
                    result.Remove(node);
                // 将node置为空，等于删掉了
                return null;
            }
            return node;
        }
        
    }
}
