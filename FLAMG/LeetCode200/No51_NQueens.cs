using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No51_NQueens
    {
        //public IList<IList<String>> SolveNQueens(int n)
        //{
        //    var solutions = new List<IList<String>>();
        //    int[] queens = new int[n];
        //    Array.Fill(queens, -1);
        //    var columns = new HashSet<int>();
        //    var diagonals1 = new HashSet<int>();
        //    var diagonals2 = new HashSet<int>();
        //    Backtrack(solutions, queens, n, 0, columns, diagonals1, diagonals2);
        //    return solutions;
        //}
        //public void Backtrack(IList<IList<String>> solutions, int[] queens, int n, int row, HashSet<int> columns, HashSet<int> diagonals1, HashSet<int> diagonals2)
        //{
        //    if (row == n)
        //    {
        //        var board = GenerateBoard(queens, n);
        //        solutions.Add(board);
        //    }
        //    else
        //    {
        //        for (int i = 0; i < n; i++)
        //        {
        //            if (columns.Contains(i))
        //            {
        //                continue;
        //            }
        //            int diagonal1 = row - i;
        //            if (diagonals1.Contains(diagonal1))
        //            {
        //                continue;
        //            }
        //            int diagonal2 = row + i;
        //            if (diagonals2.Contains(diagonal2))
        //            {
        //                continue;
        //            }
        //            queens[row] = i;
        //            columns.Add(i);
        //            diagonals1.Add(diagonal1);
        //            diagonals2.Add(diagonal2);
        //            Backtrack(solutions, queens, n, row + 1, columns, diagonals1, diagonals2);
        //            queens[row] = -1;
        //            columns.Remove(i);
        //            diagonals1.Remove(diagonal1);
        //            diagonals2.Remove(diagonal2);
        //        }
        //    }
        //}

        public IList<String> GenerateBoard(int[] queens, int n)
        {
            var board = new List<String>();
            for (int i = 0; i < n; i++)
            {
                char[] row = new char[n];
                Array.Fill(row, '.');
                row[queens[i]] = 'Q';
                board.Add(new String(row));
            }
            return board;
        }
        IList<IList<string>> res;
        public IList<IList<string>> SolveNQueens(int n)
        {
            var queens = new int[n];
            var board = GenerateBoard(queens, n);
            Backtrack(board, 0);
            return res;
        }
        public void Backtrack(IList<string> board, int row)
        {
            if(row == board.Count)
            {
                res.Add(board);
                return;
            }
            int n = board[row].Length;
            for(int col = 0; col < n; col++)
            {
                if (!IsValid(board, row, col))
                    continue;
                board[row][col] = 'Q';
                Backtrack(board, row + 1);
                board[row][col] = '.';
            }
        }
        public bool IsValid(IList<string> board, int row, int col)
        {
            int n = board.Count;
            for(int i = 0; i < n; i++)
            {
                if (board[i][col] == 'Q')
                    return false; 
            }
            for(int i = row -1, j = col + 1; i >= 0 && j < n; i--, j++)
            {
                if (board[i][j] == 'Q')
                    return false;
            }
            for(int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i][j] == 'Q')
                    return false;
            }
            return true;
        }

    }
}
