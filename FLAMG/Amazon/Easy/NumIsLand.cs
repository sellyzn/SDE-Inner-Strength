using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Amazon.Easy
{
    class NumIsLand
    {
        //DFS
        public int NumIsLands_DFS(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;
            int nr = grid.Length;
            int nc = grid[0].Length;
            int num_islands = 0;
            for(int r = 0; r < nr; r++)
            {
                for(int c = 0; c < nc; c++)
                {
                    if (grid[r][c] == '1')
                        num_islands++;
                    DFS(grid, r, c);
                }
            }
            return num_islands;
        }
        public void DFS(char[][] grid, int r, int c)
        {
            int nr = grid.Length;
            int nc = grid[0].Length;

            if (r < 0 || c < 0 || r >= nr || c >= nc || grid[r][c] == '0')
                return;
            grid[r][c] = '0';
            DFS(grid, r - 1, c);
            DFS(grid, r + 1, c);
            DFS(grid, r, c - 1);
            DFS(grid, r, c + 1);
        }


















        //695. Max Area of Island
        //int num;
        public int MaxAreaOfIsland(int[][] grid)
        {
            //num = 1;
            int res = 0;
            if (grid == null || grid.Length == 0)
                return res;
            int nr = grid.Length;
            int nc = grid[0].Length;
            for(int r = 0; r < nr; r++)
            {
                for(int c = 0; c < nc; c++)
                {
                    if (grid[r][c] == 1)
                        res = Math.Max(res, DFS_MaxArea(grid, r, c));
                }
            }
            return res;
        }
        public int DFS_MaxArea(int[][] grid, int r, int c)
        {
            int nr = grid.Length;
            int nc = grid[0].Length;
            if (r < 0 || c < 0 || r >= nr || c >= nc || grid[r][c] == 0)
                return 0;

            grid[r][c] = 0;
            int num = 1;
            num += DFS_MaxArea(grid, r - 1, c);
            num += DFS_MaxArea(grid, r + 1, c);
            num += DFS_MaxArea(grid, r, c - 1);
            num += DFS_MaxArea(grid, r, c + 1);
            return num;
        }




        // Island Perimeter
        //转化为求陆地方格和非陆地方格相邻边的数量
        //每当在DFS遍历中，从一个岛屿方格走向一个非岛屿方格时，就将周长加1
        public int IslandPerimeter(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        // 题目限制只有一个岛屿，计算一个即可
                        return IslandPerimeter_DFS(grid, r, c);
                    }
                }
            }
            return 0;            
        }
        public int IslandPerimeter_DFS(int[][] grid, int r, int c)
        {
            if (!(0 <= r && r < grid.Length && 0 <= c && c < grid[r].Length))
            {
                return 1;
            }
            if (grid[r][c] == 0)
            {
                return 1;
            }
            if (grid[r][c] != 1)
            {
                return 0;
            }
            grid[r][c] = 2;
            return IslandPerimeter_DFS(grid, r - 1, c)
                + IslandPerimeter_DFS(grid, r + 1, c)
                + IslandPerimeter_DFS(grid, r, c - 1)
                + IslandPerimeter_DFS(grid, r, c + 1);
        }

       


        //Surrounded Regions
        public void Solve(char[][] board)
        {
            if (board == null || board.Length == 0)
                return;
            for(int i = 0; i < board.Length; i++)
            {
                Solve_DFS(board, i, 0);
                Solve_DFS(board, i, board[i].Length - 1);   
            }
            for(int j = 0; j < board[0].Length; j++)
            {
                Solve_DFS(board, 0, j);
                Solve_DFS(board, board.Length - 1, j);
            }
            for(int i = 0; i < board.Length; i++)
            {
                for(int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == 'O')
                        board[i][j] = 'X';
                    if (board[i][j] == 'A')
                        board[i][j] = 'O';
                }
            }
        }
        public void Solve_DFS(char[][]board, int i, int j)
        {
            if (i < 0 || j < 0 || i >= board.Length || j >= board[i].Length)
                return;
            if (board[i][j] != 'O')
                return;
            board[i][j] = 'A';
            Solve_DFS(board, i + 1, j);
            Solve_DFS(board, i - 1, j);
            Solve_DFS(board, i, j + 1);
            Solve_DFS(board, i, j - 1);
        }




        //Number of Closed Islands
        public int ClosedIsland(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;
            for (int i = 0; i < grid.Length; i++)
            {
                //ClosedIsland_DFS(grid, i, 0);
                //ClosedIsland_DFS(grid, i, grid[i].Length - 1);
                ClosedIsland_BFS(grid, i, 0);
                ClosedIsland_BFS(grid, i, grid[i].Length - 1);
            }
            for (int j = 0; j < grid[0].Length; j++)
            {
                //ClosedIsland_DFS(grid, 0, j);
                //ClosedIsland_DFS(grid, grid.Length - 1, j);
                ClosedIsland_BFS(grid, 0, j);
                ClosedIsland_BFS(grid, grid.Length - 1, j);
            }
            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if(grid[i][j] == 0)
                    {
                        count++;
                        //ClosedIsland_DFS(grid, i, j);
                        ClosedIsland_BFS(grid, i, j);
                    }
                }
            }
            return count;
        }
        public void ClosedIsland_DFS(int[][] grid, int r, int c)
        {
            int nr = grid.Length;
            int nc = grid[0].Length;

            if (r < 0 || c < 0 || r >= nr || c >= nc || grid[r][c] == 1)
                return;
            grid[r][c] = 0;
            ClosedIsland_DFS(grid, r - 1, c);
            ClosedIsland_DFS(grid, r + 1, c);
            ClosedIsland_DFS(grid, r, c - 1);
            ClosedIsland_DFS(grid, r, c + 1);
        }
        public void ClosedIsland_BFS(int[][] grid, int i, int j)
        {
            var queue = new Queue<int[]>();
            queue.Enqueue(new int[] { i, j });
            while(queue.Count > 0)
            {
                var cur = queue.Dequeue();
                i = cur[0];
                j = cur[1];
                if(0 <= i && i < grid.Length && 0 <= j && j < grid[i].Length && grid[i][j] == 0)
                {
                    grid[i][j] = 1;
                    queue.Enqueue(new int[] { i + 1, j });
                    queue.Enqueue(new int[] { i - 1, j });
                    queue.Enqueue(new int[] { i, j + 1 });
                    queue.Enqueue(new int[] { i, j - 1 });
                }               
            }
        }

        //Number of Enclaves
        public int NumEnclaves(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;
            for (int i = 0; i < grid.Length; i++)
            {
                NumEnclaves_DFS(grid, i, 0);
                NumEnclaves_DFS(grid, i, grid[i].Length - 1);
            }
            for (int j = 0; j < grid[0].Length; j++)
            {
                NumEnclaves_DFS(grid, 0, j);
                NumEnclaves_DFS(grid, grid.Length - 1, j);
            }
            int res = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        res++;
                    }
                }
            }
            return res;
        }
        public int NumEnclaves_DFS(int[][] grid, int r, int c)
        {
            int nr = grid.Length;
            int nc = grid[0].Length;
            if (r < 0 || c < 0 || r >= nr || c >= nc || grid[r][c] == 0)
                return 0;

            grid[r][c] = 0;
            return 1 + NumEnclaves_DFS(grid, r - 1, c) + NumEnclaves_DFS(grid, r + 1, c) + NumEnclaves_DFS(grid, r, c - 1) + NumEnclaves_DFS(grid, r, c + 1);
        }

    }
}
