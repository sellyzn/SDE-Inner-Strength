using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverI
{
    public class BinaryTreePaths
    {
        public List<string> BinaryTreePathsI(TreeNode root)
        {
            List<string> paths = new List<string>();
            ConstructPaths(root, "", paths);
            return paths;
        }
        public void ConstructPaths(TreeNode root, string path, List<string> paths)
        {
            if(root != null)
            {
                StringBuilder pathSB = new StringBuilder(path);
                pathSB.Append(root.val.ToString());
                if(root.left == null && root.right == null)
                {
                    paths.Add(pathSB.ToString());
                }
                else
                {
                    pathSB.Append("->");
                    ConstructPaths(root.left, pathSB.ToString(), paths);
                    ConstructPaths(root.right, pathSB.ToString(), paths);
                }
            }            
        }
    }
}
