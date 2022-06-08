using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No130_SurroundedRegions
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="board"></param>
        /// T: O(M*N), M is the row, N is the columns, M*N is the number of the board cells
        /// S: O(M*N)
        public void Solve(char[][] board)
        {
            // find the 'O's in the 4 edges, add them to queue, and mark them
            // BFS find all 'O's that adjacent by the 4 edges' 'O's, mark them
            // traverse array board, flipping all marked 'O's into 'X'.

            var queue = new Queue<int[]>();
            int rows = board.Length;
            if (rows == 0)
                return;
            int cols = board[0].Length;
            if (cols == 0)
                return;
            var mark = new int[rows, cols];
            var visited = new bool[rows, cols];
            for(int i = 0; i < rows; i++)
            {
                if(board[i][0] == 'O')
                {
                    queue.Enqueue(new int[] { i, 0 });
                    mark[i, 0] = 1;
                    visited[i,0] = true;
                }
                if (board[i][cols - 1] == 'O')
                {
                    queue.Enqueue(new int[] { i, cols - 1 });
                    mark[i, cols - 1] = 1;
                    visited[i, cols - 1] = true;
                }
            }
            for (int j = 0; j < cols; j++)
            {
                if (board[0][j] == 'O')
                {
                    queue.Enqueue(new int[] { 0, j });
                    mark[0, j] = 1;
                    visited[0, j] = true;
                }
                if (board[rows - 1][j] == 'O')
                {
                    queue.Enqueue(new int[] { rows - 1, j });
                    mark[rows - 1, j] = 1;
                    visited[rows - 1, j] = true;
                }
            }
            var directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            while(queue.Count > 0)
            {
                var curr = queue.Dequeue();
                foreach (var dir in directions)
                {
                    var newx = curr[0] + dir[0];
                    var newy = curr[1] + dir[1];
                    if(newx >= 0 && newx < rows && newy >= 0 && newy < cols && !visited[newx, newy])
                    {
                        if(board[newx][newy] == 'O')
                        {
                            queue.Enqueue(new int[] { newx, newy });
                            mark[newx, newy] = 1;
                            visited[newx, newy] = true;
                        }
                    }
                }
            }

            for(int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i][j] == 'O' && mark[i, j] == 0)
                        board[i][j] = 'X';
                }
            }
        }
    }
}
