using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Blind75.MatrixCategory
{
    internal class WordSearch
    {
        // 79. Word Search
        /*
        m * n board, string word, search if exist or not
        
        Backtrack

         */
        public bool Exist(char[][] board, string word)
        {
            int rows = board.Length;
            if (rows == 0)
                return false;
            int cols = board[0].Length;
            if (cols == 0)
                return false;

            var visited = new bool[rows, cols];
            for(int r = 0; r < rows; r++)
            {
                for(int c = 0; c < cols; c++)
                {
                    if (Backtrack(board, word, 0, r, c, visited))
                        return true;
                }
            }
            return false;
        }
        public bool Backtrack(char[][] board, string word, int index, int row, int col, bool[,] visited)
        {
            if (board[row][col] != word[index])
                return false;
            if (index == word.Length - 1)
                return true;

            visited[row, col] = true;
            var result = false;
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

        // 212. Word Search II
        /*
        input: m*n board, string[] words
        output: all words on the board

        1. check if a word is exist on the board
        2. traverse all words
        (Time limit exceeded)

        solution 2:

         */
        public IList<string> FindWords(char[][] board, string[] words)
        {
            var result = new List<string>();            

            for(int i = 0; i < words.Length; i++)
            {
                if(Exist(board, words[i]))
                    result.Add(words[i]);
            }
            return result;
        }

    }
}
