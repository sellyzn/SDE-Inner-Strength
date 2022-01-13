using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldII
{
    public class NQueens
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            var result = new List<IList<string>>();
            var board = new string[n, n];
            Backtracking(result, board, n, 0);
            return result;
        }
        public void Backtracking(IList<IList<string>> result, string[,] board, int n, int row)
        {
            if (row == n)
            {
                result.Add(StringArrayToList(board));
                return;
            }
            for (int col = 0; col < n; col++)
            {
                if (!IsValid(board, row, col))
                    continue;
                board[row, col] = "Q";
                Backtracking(result, board, n, row + 1);
                board[row, col] = ".";
            }
        }
        public bool IsValid(string[,] board, int row, int col)
        {
            int n = board.Length;
            //检查列中是否有皇后冲突
            for(int i = 0; i < row; i++)
            {
                if (board[i, col] == "Q")
                    return false;
            }
            //检查右上方是否有皇后冲突
            for (int i = row - 1, j = col + 1; i >= 0 && j >= 0; i--, j++)
            {
                if (board[i, j] == "Q")
                    return false;
            }
            //检查左上方是否有皇后冲突
            for(int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == "Q")
                    return false;
            }
            return true;
        }

        public IList<string> StringArrayToList(string[,] board)
        {
            var res = new List<string>();
            for(int i = 0; i < board.Length; i++)
            {
                var subString = new StringBuilder();
                for(int j = 0; j < board.GetLength(1); j++)
                {
                    subString.Append(board[i,j]);
                }
                res.Add(subString.ToString());
            }
            return res;
        }

    }
}
