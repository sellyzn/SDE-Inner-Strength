using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Amazon.Easy
{
    public class FindSubtree
    {
        //定义数据返回类型，包括子树的所有节点权值之和&子树节点数目
        public class Result
        {
            //sum:  根节点root以及所有子孙节点作为子树的权值sum
            //num:  根节点root以及所有子孙节点作为子树的节点数目num
            public int sum, num;
            public Result(int sum, int num)
            {
                this.sum = sum;
                this.num = num;
            }
        }


        //maxAverage表示最大平均值子树的根节点
        public TreeNode maxAverage = null;
        //maxAverageData记录最大平均值子树的所有权值之和&子树节点数目
        public Result maxAverageData = null;
        public TreeNode FindSubtree2(TreeNode root)
        {
            DFS(root);
            return maxAverage;
        }
        public Result DFS(TreeNode root)
        {
            if (root == null)
                return new Result(0, 0);

            //递归求解左右子树的所有权值之和&子树节点数目
            Result left = DFS(root.left);
            Result right = DFS(root.right);

            //
            Result rootResult = new Result(left.sum + right.sum + root.val, left.num + right.num + 1);

            //如果最大平均值子树为空，或者当前子树平均值大于原maxAverage， 更新maxAverage
            //
            //root.sum / root.num > ans.sum / ans.num => root.sum * ams.num > ans.sum * root.num
            //            
            if(maxAverage == null || maxAverageData.num * rootResult.sum > maxAverageData.sum * rootResult.num)
            {
                maxAverage = root;
                maxAverageData = rootResult;
            }
            return rootResult;
        }
    }
}
