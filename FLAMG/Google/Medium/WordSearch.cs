using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Google.Medium
{
    public class WordSearch
    {
        //public bool Exist(char[][] board, string word)
        //{
        //    var row = board.Length;
        //    var col = board[0].Length;
        //    if (row == 0 || col == 0)
        //        return false;

        //    // Find the locations of word[0] in the board
        //    var starts = new List<int[]>();
        //    var visited = new bool[row,col];
        //    //bool[][] visited = new bool[row][];
        //    //for (int i = 0; i < row; i++)
        //    //{
        //    //    visited[i] = new bool[col];
        //    //}
        //    for (var r = 0; r < row; r++)
        //    {
        //        for (var c = 0; c < col; c++)
        //        {
        //            if (board[r][c] == word[0])
        //                starts.Add(new int[] { r, c });
        //            visited[r, c] = true;
        //        }
        //    }

        //    // Start fro the word[0] locations in the board, DFS
        //    foreach (var location in starts)
        //    {
        //        var result = BackTracking(board, word, location[0], location[1], 1, visited);
        //        if (result == true)
        //            return true;
        //    }
        //    return false;
        //}
        //public bool BackTracking(char[][] board, string word, int x, int y, int length, bool[,] visited)
        //{
        //    if (length == word.Length)
        //        return true;
        //    var row = board.Length;
        //    var col = board[0].Length;

        //    var result = false;
        //    visited[x, y] = true;
        //    var directions = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
        //    foreach (var dir in directions)
        //    {
        //        var new_x = x + dir[0];
        //        var new_y = y + dir[1];
        //        if (new_x >= 0 && new_x < row && new_y >= 0 && new_y < col && visited[new_x, new_y])
        //        {

        //            if (word[length] == board[new_x][new_y])
        //            {
        //                //length++;
        //                //visited[new_x][new_y] == true;
        //                var flag = BackTracking(board, word, new_x, new_y, length + 1, visited);
        //                if (flag)
        //                {
        //                    result = true;
        //                    break;
        //                }
        //            }
        //        }

        //    }
        //    visited[x, y] = false;
        //    length--;
        //    return result;

        //}


        public bool Exist(char[][] board, String word)
        {
            int row = board.Length, col = board[0].Length;
            bool[,] visited = new bool[row,col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    bool flag = Backtracking(board, visited, i, j, word, 0);
                    if (flag)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Backtracking(char[][] board, bool[,] visited, int x, int y, String s, int k)
        {
            if (board[x][y] != s[k])
            {
                return false;
            }
            else if (k == s.Length - 1)
            {
                return true;
            }
            visited[x,y] = true;
            var directions = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
            bool result = false;
            foreach (int[] dir in directions)
            {
                int new_x = x + dir[0], new_y = y + dir[1];
                if (new_x >= 0 && new_x < board.Length && new_y >= 0 && new_y < board[0].Length)
                {
                    if (!visited[new_x,new_y])
                    {
                        bool flag = Backtracking(board, visited, new_x, new_y, s, k + 1);
                        if (flag)
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            visited[x,y] = false;
            return result;
        }       

    }
}
