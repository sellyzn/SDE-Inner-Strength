using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.BFS
{
    public class ShortestDistance
    {
        // 01 Matrix
        public int[][] UpdateMatrix(int[][] matrix)
        {
            int row = matrix.Length;
            int col = matrix[0].Length;
            if (row == 0 || col == 0)
                return matrix;
            //enqueue all 0 to the queue
            var queue = new Queue<int[]>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i][j] == 0)
                        queue.Enqueue(new int[] { i, j });
                    else
                        ;
                }
            }

            //BFS
            var DIRECTIONS = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            var visited = new HashSet<int[]>();
            while(queue.Count > 0)
            {
                var location = queue.Dequeue();
                int x = location[0], y = location[1];
                foreach (var dir in DIRECTIONS)
                {
                    int new_x = x + dir[0];
                    int new_y = y + dir[1];

                    if (matrix[new_x][new_y] == 1 && IsValid(matrix, new_x, new_y, visited))
                    {
                        matrix[new_x][new_y] = matrix[x][y] + 1;
                        queue.Enqueue(new int[] { new_x, new_y });
                    }
                }
            }
        }
        public bool IsValid(int[][] matrix, int x, int y, HashSet<int[]> visited)
        {
            if (x < 0 || y < 0 || x >= matrix.Length || y >= matrix[0].Length)
                return false;
            if (matrix[x][y] == 0)
                return false;
            if (visited.Contains(new int[] { x, y }))
                return false;
            return true;
        }


        // Post Office

        //枚举所有空地来建立邮局 O(N^2)
        //分层BFS找所有可达的房子的最短距离 O(N^2)
        //将所有房子的距离相加后打擂台
        //O（空地 * n^2）

        //follow up: 房子数量较少，空地数量较多 （房子数量 <= n, n*n的矩阵，n <= 10^3）
        //O（房子 * n^2）






    }
}
