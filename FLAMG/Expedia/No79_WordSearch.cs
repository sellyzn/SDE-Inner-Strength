using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No79_WordSearch
    {
        /// <summary>
        /// Backtrack
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist(char[][] board, string word)
        {
            int rows = board.Length;
            if(rows == 0)
                return false;
            int cols = board[0].Length;
            if (cols == 0)
                return false;
            var visited = new bool[rows, cols];
            for(int row = 0; row < rows; row++)
            {
                for(int col = 0; col < cols; col++)
                {
                    if (Backtrack(board, word, 0, row, col, visited))
                        return true;
                }
            }
            return false;
        }
        public bool Backtrack(char[][] board, string word, int index, int row, int col, bool[,] visited)
        {
            if (board[row][col] != word[index])
                return false;
            else if (index == word.Length - 1)
                return true;
            visited[row, col] = true;
            bool result = false;
            var directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            foreach (var dir in directions)
            {
                var newRow = row + dir[0];
                var newCol = col + dir[1];
                if(newRow >= 0 && newCol >= 0 && newRow < board.Length && newCol < board[0].Length)
                {
                    if(!visited[newRow, newCol])
                    {
                        if(Backtrack(board, word, index + 1, newRow, newCol, visited))
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            visited[row, col] = false;
            return result;
        }
    }
}
