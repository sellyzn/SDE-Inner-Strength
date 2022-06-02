using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.HighestFrequency
{
    public class StepByStepDirectionsFromBinaryTreeNodeToAnother
    {
        // 1. find the LCA of startValue and destValue
        // 2. Generate the step by step direction from the LCA to startValue(Left) and LCA to destValue(Right). the direction from Left to LCA will only consist of 'U's as per the output format.
        // 3. combine both the directions(Left + Right)
        public string GetDirections(TreeNode root, int startValue, int destValue)
        {
            if (root == null)
                return "";
            var direction = new StringBuilder();
            var ancestor = LCA(root, startValue, destValue);    //find common parent for both nodes

            //we will have two paths
            //root-> start node
            //root-> end node
            var paths = new List<string>();

            //find both paths individually
            BacktrackingGetDirection(ancestor, startValue, new StringBuilder(), paths);
            BacktrackingGetDirection(ancestor, destValue, new StringBuilder(), paths);

            //now lets create directions, the 1st path was root->start node, so all direction from 
            //start to root will be Up, lets add it to directions
            for (int i = 0; i < paths[0].Length; i++)
                direction.Append("U");

            //this one will remain the same bcz after reaching start -> root, we will go
            //root -> dest node, so those directions will be the same
            direction.Append(paths[1]);
            
            return direction.ToString(); 
        }
        public TreeNode LCA(TreeNode root, int p, int q)
        {
            //if (root == null || root.val == p || root.val == q)
            //    return root;
            if (root == null)
                return null;
            if (root.val == p || root.val == q)
                return root;
            var left = LCA(root.left, p, q);
            var right = LCA(root.right, p, q);
            if (left != null && right != null)
                return null;
            if (left != null && right != null)
                return root;
            return left != null ? left : right;
        }

        public void BacktrackingGetDirection(TreeNode node, int dest, StringBuilder path, List<string> paths)
        {
            //if we found, lets add it to paths and return
            if (node.val == dest)
            {
                paths.Add(new string(path.ToString()));
                return;
            }
                
            if(node.left != null)
                BacktrackingGetDirection(node.left, dest, path.Append("L"), paths);
            if(node.right != null)
                BacktrackingGetDirection(node.right, dest, path.Append("R"), paths);

            //if we reach here that means we didn't find the path yet, lets remove the last direction added
            path.Remove(path.Length - 1, 1);
            
            return;
        }
        
    }
}
