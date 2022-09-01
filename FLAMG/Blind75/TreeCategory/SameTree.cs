using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.TreeCategory
{
    internal class SameTree
    {
        // 100. Same Tree
        // DFS
        // T: O(min(m,n))
        // S: O(min(m,n))
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p == null)
                return false;
            if (q == null)
                return false;
            return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        //BFS
        // T: O(min(m,n))
        // S: O(min(m,n))
        public bool IsSameTree_BFS(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p == null || q == null)
                return false;
            var queueP = new Queue<TreeNode>();
            var queueQ = new Queue<TreeNode>();
            queueP.Enqueue(p);
            queueQ.Enqueue(q);
            while(queueP.Count > 0 && queueQ.Count > 0)
            {
                var nodeP = queueP.Dequeue();
                var nodeQ = queueQ.Dequeue();
                if (nodeP.val != nodeQ.val)
                    return false;
                TreeNode leftP = nodeP.left, rightP = nodeP.right;
                TreeNode leftQ = nodeQ.left, rightQ = nodeQ.right;
                if (leftP == null ^ leftQ == null)
                    return false;
                if (rightP == null ^ rightQ == null)
                    return false;
                if(leftP != null)
                    queueP.Enqueue(leftP);
                if(rightP != null)
                    queueP.Enqueue(rightP);
                if(leftQ != null)
                    queueQ.Enqueue(leftQ);
                if (rightQ != null)
                    queueQ.Enqueue(rightQ);
            }
            return queueP.Count == 0 && queueQ.Count == 0;
        }

    }
}
