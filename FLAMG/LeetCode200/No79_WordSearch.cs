using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No79_WordSearch
    {
        /// <summary>
        /// Backtrack
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        /// T: O(M * N * 3^L), M,N为网格的长度与宽度， L为字符串的长度。每次调用backtrack函数时，除了第一次可以进入4个分支以外，其余时间我们最多会进入3个分支（因为每个位置只能使用一次，不能往回走）。
        /// S: O(M*N)
        public bool Exist(char[][] board, string word)
        {
            int rows = board.Length;
            int cols = board[0].Length;
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
                if(newRow >= 0 && newRow < board.Length && newCol >= 0 && newCol < board[0].Length)
                {
                    if(!visited[newRow, newCol])
                    {
                        var flag = Backtrack(board, word, index + 1, newRow, newCol, visited);
                        if (flag)
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
        //public bool Exist(char[][] board, string word)
        //{
        //    var sb = new StringBuilder();
        //    return DFS(board, word, sb, 0, 0);
        //}
        //public bool DFS(char[][] board, string word, StringBuilder sb, int startX, int startY)
        //{
        //    if (sb.Length == word.Length)
        //        return true;
        //    if(startX + 1 < board.Length && board[startX + 1][startY] == word[sb.Length])
        //    {
        //        sb.Append(word[sb.Length]);
        //        DFS(board, word, sb, startX + 1, startY);
        //    }
        //    if (startX - 1 >= 0 && board[startX - 1][startY] == word[sb.Length])
        //    {
        //        sb.Append(word[sb.Length]);
        //        DFS(board, word, sb, startX - 1, startY);
        //    }
        //    if(startY + 1 < board[0].Length && board[startX][startY + 1] == word[sb.Length])
        //    {
        //        sb.Append(word[sb.Length]);
        //        DFS(board, word, sb, startX, startY + 1);
        //    }
        //    if (startY - 1 >= 0 && board[startX][startY - 1] == word[sb.Length])
        //    {
        //        sb.Append(word[sb.Length]);
        //        DFS(board, word, sb, startX, startY - 1);
        //    }
        //    return false;
        //}
    }
}
