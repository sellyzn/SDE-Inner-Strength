using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No968_BinaryTreeCameras
    {
        int res = 0;
        public int MinCameraCover(TreeNode root)
        {
            return DFS(root) == 0 ? res + 1 : res;    //如果父节点是无覆盖状态，那么需要在父节点添加一台摄像机
        }
        public int DFS(TreeNode root)
        {
            if (root == null)
                return 2;   //节点有覆盖
            int left = DFS(root.left);
            int right = DFS(root.right);
            // 0表示无覆盖，1表示有相机， 2 表示有覆盖，左右节点可以组成9种状态
            // （00， 01，02， 10， 11， 12， 20， 21， 22）

            // 只要有一个无覆盖，父节点就要相机来覆盖这个子节点 00， 01， 10， 20， 02
            if(left == 0 || right == 0)
            {
                res++;
                return 1;
            }

            // 子节点其中只要有一个相机，那么父节点就水水有fu
            if (left == 1 || right == 1)
                return 2;
            return 0;
        }
    }
}
