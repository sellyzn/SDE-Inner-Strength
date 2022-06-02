using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.HighestFrequency
{
    public class FindDuplicateSubtrees
    {
        //public IList<TreeNode> FindDuplicateSubtrees_DFS(TreeNode root)
        //{

        //}
        //public bool IsSameTree(TreeNode root1, TreeNode root2)
        //{
        //    if (root1 == null && root2 == null)
        //        return true;
        //    if (root1 == null)
        //        return false;
        //    if (root2 == null)
        //        return false;
        //    if(root1.val == root2.val)
        //    {
        //        if(IsSameTree(root1.left, root2.left) && IsSameTree(root1.right, root2.right))
        //            return true;
        //        if (IsSameTree(root1.left, root2.right) && IsSameTree(root1.right, root2.left))
        //            return true;
        //    }
        //    return false;
        //}
        public IList<TreeNode> FindDuplicateSubtrees_DFS_Serialize(TreeNode root)
        {
            var dict = new Dictionary<string, int>();
            var res = new List<TreeNode>();
            DFS_Serialize(root, dict, res);
            return res;
        }
        public string DFS_Serialize(TreeNode node, Dictionary<string, int> dict, List<TreeNode> res)
        {
            if (node == null)
                return "#";
            var serial = node.val + "," + DFS_Serialize(node.left, dict, res) + "," + DFS_Serialize(node.right, dict, res);
            if(dict.ContainsKey(serial))
                dict[serial]++;
            else
                dict.Add(serial, 1);
            if(dict[serial] == 2)
                res.Add(node);
            return serial;
        }

        // 449. Serialize and Deserialize BST

        public string SearializeBST(TreeNode root)
        {
            // preorder
            
            if (root == null)
                return "#";
            var data = root.val + "," + SearializeBST(root.left) + "," + SearializeBST(root.right);
            return data;
        }
        public TreeNode DeserializeBST(string data)
        {
            if(data == null || data == "#")
                return null;
            var root = new TreeNode(data[0]);
            //find the right subtree begaining index
            
            var rightIndex = 0;
            for(int i = 1; i < data.Length; i++)
            {
                if(data[i] > data[0])
                {                    
                    break;
                }                    
            }
            if(rightIndex == 0)
            {
                root.left = null;
                root.right = null;
            }
                
            if(rightIndex == data.Length)
            {
                root.left = DeserializeBST(data.Substring(1));
                root.right = null;
            }
            return root;
        }

        // 297. Serialize and Deserizlize BT

        //public string SearializeBT(TreeNode root)
        //{

        //}
        //public TreeNode DeserializeBT(string data)
        //{

        //}
    }
}
