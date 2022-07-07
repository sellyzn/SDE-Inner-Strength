using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No289_GameOfLife
    {
        /// <summary>
        /// Copy board
        /// </summary>
        /// <param name="board"></param>
        /// T: O(mn)
        /// S: O(mn)
        public void GameOfLife(int[][] board)
        {
            int rows = board.Length;
            if (rows == 0)
                return;
            int cols = board[0].Length;
            if (cols == 0)
                return;
            var copyBoard = new int[rows, cols];
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    copyBoard[i, j] = board[i][j];
                }
            }
            var directions = new int[][] { new int[] { 1, 0 }, new int[] { 1, 1 }, new int[] { 0, 1 }, new int[] { -1, 1 }, new int[] { -1, 0 }, new int[] { -1, -1 }, new int[] { 0, -1 }, new int[] { 1, -1 } };
            for(int row = 0; row < rows; row++)
            {
                for(var col = 0; col < cols; col++)
                {
                    int liveNeighbors = 0;
                    foreach(var dir in directions)
                    {
                        var newx = row + dir[0];
                        var newy = col + dir[1];
                        if(newx >= 0 && newy >= 0 && newx < rows && newy < cols)
                        {
                            if(copyBoard[newx, newy] == 1)
                                liveNeighbors++;
                        }
                    }
                    if (copyBoard[row, col] == 1 && liveNeighbors < 2)
                        board[row][col] = 0;
                    if (copyBoard[row, col] == 1 && liveNeighbors >= 2 && liveNeighbors <= 3)
                        board[row][col] = 1;
                    if (copyBoard[row, col] == 1 && liveNeighbors > 3)
                        board[row][col] = 0;
                    if (copyBoard[row, col] == 0 && liveNeighbors == 3)
                        board[row][col] = 1;
                }
            }
        }
        /// <summary>
        /// 使用额外的状态
        /// </summary>
        /// <param name="board"></param>
        /// T: O(mn)
        /// S: O(1)
        public void GameOfLife_Op(int[][] board)
        {
            int rows = board.Length;
            if (rows == 0)
                return;
            int cols = board[0].Length;
            if (cols == 0)
                return;
           
            var directions = new int[][] { new int[] { 1, 0 }, new int[] { 1, 1 }, new int[] { 0, 1 }, new int[] { -1, 1 }, new int[] { -1, 0 }, new int[] { -1, -1 }, new int[] { 0, -1 }, new int[] { 1, -1 } };
            for (int row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    int liveNeighbors = 0;
                    foreach (var dir in directions)
                    {
                        var newx = row + dir[0];
                        var newy = col + dir[1];
                        if (newx >= 0 && newy >= 0 && newx < rows && newy < cols)
                        {
                            if (board[newx][newy] == -1 || board[newx][newy] == 1)          // 注意此时的判断条件
                                liveNeighbors++;
                        }
                    }
                    if (board[row][col] == 1 && (liveNeighbors < 2 || liveNeighbors > 3))
                        board[row][col] = -1;                   
                    
                    if (board[row][col] == 0 && liveNeighbors == 3)
                        board[row][col] = 2;
                }
            }
            // 遍历，更新
            for(int row = 0; row < rows; row++)
            {
                for(int col = 0; col < cols; col++)
                {
                    if (board[row][col] > 0)
                        board[row][col] = 1;
                    else
                        board[row][col] = 0;
                }
            }
        }

    }
}
