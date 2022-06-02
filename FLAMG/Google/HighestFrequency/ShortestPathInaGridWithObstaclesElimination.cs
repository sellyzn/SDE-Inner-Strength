using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.HighestFrequency
{
    public class StepState : IComparable
    {
        public int row;
        public int col;
        public int k;
        public int steps;
        public int[] target;
        public int estimation;

        public StepState(int row, int col, int k, int[] target)
        {
            this.row = row;
            this.col = col;
            this.k = k;
            this.target = target;
            int manhattanDistance = target[0] - row + target[1] - col;
            this.estimation = estimation + this.steps;
        }

        public int CompareTo(object obj)
        {
            StepState other = (StepState)obj;
            return this.estimation - other.estimation;
        }
        public override bool Equals(object obj)
        {
            StepState newState = (StepState)obj;
            return (this.row == newState.row) && (this.col == newState.col) && (this.k == newState.k);
        }

        public override int GetHashCode()
        {
            return this.row.GetHashCode() * this.col.GetHashCode() * this.k.GetHashCode();
        }
    }

    public class ShortestPathInaGridWithObstaclesElimination
    {
        //public int ShortestPath(int[][] grid, int k)
        //{
        //    int row = grid.Length;
        //    if(row <= 0)
        //        return 0;
        //    int col = grid[0].Length;
        //    if (col <= 0)
        //        return 0;

        //    if(row == 1 && col == 1)
        //        return 0;

        //    // BFS
        //    var queue = new Queue<int[]>();
        //    var visited = new HashSet<int[]>();
        //    var x = new int[] { 0, 0, k };
        //    x.GetHashCode();
        //    queue.Enqueue(new int[] { 0, 0, k });
        //    visited.Add(new int[] {0, 0, k});
        //    var step = 0;
        //    var directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
        //    while(queue.Count > 0)
        //    {
        //        step++;
        //        var length = queue.Count;
        //        for (int i = 0; i < length; i++)
        //        {
        //            var location = queue.Dequeue();
        //            foreach (var dir in directions)
        //            {
        //                var new_x = location[0] + dir[0];
        //                var new_y = location[1] + dir[1];
        //                var restObstacles = location[2];
        //                if(new_x >= 0 && new_x < row && new_y >= 0 && new_y < col)
        //                {
        //                    if (grid[new_x][new_y] == 0 && !visited.Contains(new int[] {new_x, new_y, restObstacles}))
        //                    {
        //                        if (new_x == row - 1 && new_y == col - 1)
        //                            return step;
        //                        queue.Enqueue(new int[] { new_x, new_y, restObstacles });
        //                        visited.Add(new int[] { new_x, new_y, restObstacles });
        //                    }else if(grid[new_x][new_y] == 1 && restObstacles > 0 && !visited.Contains(new int[] {new_x, new_y, restObstacles - 1}))
        //                    {
        //                        queue.Enqueue(new int[] {new_x, new_y, restObstacles - 1});
        //                        visited.Add(new int[] { new_x, new_y, restObstacles - 1 });
        //                    }
        //                }                        
        //            }
        //        }
        //    }
        //    return -1;
        //}

        //public int ShortestPath(int[][] grid, int k)
        //{
        //    int row = grid.Length;
        //    if (row <= 0)
        //        return 0;
        //    int col = grid[0].Length;
        //    if (col <= 0)
        //        return 0;

        //    if (row == 1 && col == 1)
        //        return 0;

        //    if (k >= row + col - 2)
        //    {
        //        return row + col - 2;
        //    }

        //    // BFS
        //    var queue = new Queue<int[]>();
        //    var visited = new HashSet<int[]>();
        //    var startStatus = new int[] { 0, 0, k };
        //    queue.Enqueue(startStatus);
        //    visited.Add(startStatus);
        //    var step = 0;
        //    var directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
        //    while (queue.Count > 0)
        //    {
        //        var length = queue.Count;
        //        Console.WriteLine($"step:{step};length:{length};visited:{visited.Count}");
        //        for (int i = 0; i < length; i++)
        //        {
        //            var location = queue.Dequeue();
        //            if (location[0] == row - 1 && location[1] == col - 1)
        //                return step;
        //            foreach (var dir in directions)
        //            {
        //                var new_x = location[0] + dir[0];
        //                var new_y = location[1] + dir[1];
        //                var restObstacles = location[2];
        //                if (new_x >= 0 && new_x < row && new_y >= 0 && new_y < col)
        //                {
        //                    var newStatus = new int[] { new_x, new_y, restObstacles - grid[new_x][new_y] };

        //                    if (newStatus[2] >= 0)
        //                    {
        //                        queue.Enqueue(newStatus);
        //                        visited.Add(newStatus);
        //                    }
        //                }
        //            }
        //        }
        //        step++;
        //    }
        //    return -1;
        //}


        //public int ShortestPath(int[][] grid, int k)
        //{
        //    int row = grid.Length;
        //    if (row <= 0)
        //        return 0;
        //    int col = grid[0].Length;
        //    if (col <= 0)
        //        return 0;

        //    if (row == 1 && col == 1)
        //        return 0;

        //    if (k >= row + col - 2)
        //    {
        //        return row + col - 2;
        //    }

        //    // BFS
        //    var queue = new Queue<int[]>();
        //    var visited = new bool[row, col, k + 1];
        //    var startStatus = new int[] { 0, 0, k };
        //    queue.Enqueue(startStatus);
        //    visited[0, 0, k] = true;
        //    var step = 0;
        //    var directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
        //    while (queue.Count > 0)
        //    {
        //        var length = queue.Count;
        //        Console.WriteLine($"step:{step};length:{length};visited:{visited.Length}");
        //        for (int i = 0; i < length; i++)
        //        {
        //            var location = queue.Dequeue();
        //            if (location[0] == row - 1 && location[1] == col - 1)
        //                return step;
        //            foreach (var dir in directions)
        //            {
        //                var new_x = location[0] + dir[0];
        //                var new_y = location[1] + dir[1];
        //                var restObstacles = location[2];
        //                if (new_x >= 0 && new_x < row && new_y >= 0 && new_y < col)
        //                {
        //                    var newStatus = new int[] { new_x, new_y, restObstacles - grid[new_x][new_y] };

        //                    if (newStatus[2] >= 0)
        //                    {
        //                        queue.Enqueue(newStatus);
        //                        visited[new_x, new_y, restObstacles - grid[new_x][new_y]] = true;
        //                    }
        //                }
        //            }
        //        }
        //        step++;
        //    }
        //    return -1;
        //}

        public int ShortestPath(int[][] grid, int k)
        {
            int row = grid.Length;
            if (row <= 0)
                return 0;
            int col = grid[0].Length;
            if (col <= 0)
                return 0;

            if (row == 1 && col == 1)
                return 0;

            if (k >= row + col - 2)
            {
                return row + col - 2;
            }

            // BFS
            int[] target = new int[] {row - 1, col - 1};
            var queue = new Queue<StepState>();
            var visited = new HashSet<StepState>();
            var startState = new StepState(0, 0, k, target);
            queue.Enqueue(startState);
            visited.Add(startState);
            var step = 0;
            var directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
            while (queue.Count > 0)
            {
                var length = queue.Count;
                Console.WriteLine($"step:{step};length:{length};visited:{visited.Count}");

                for (int i = 0; i < length; i++)
                {
                    var location = queue.Dequeue();
                    int remainMinDistance = location.estimation - location.steps;
                    if (remainMinDistance <= location.k)
                    {
                        return location.estimation;
                    }
                    if (location.row == row - 1 && location.col == col - 1)
                        return step;
                    foreach (var dir in directions)
                    {
                        var new_x = location.row + dir[0];
                        var new_y = location.col + dir[1];
                        var restObstacles = location.k;
                        if (new_x >= 0 && new_x < row && new_y >= 0 && new_y < col)
                        {
                            var newState = new StepState ( new_x, new_y, restObstacles - grid[new_x][new_y], target );

                            if (newState.k >= 0)
                            {
                                queue.Enqueue(newState);
                                visited.Add(newState);
                            }
                        }
                    }
                }
                step++;
            }
            return -1;
        }

    }
}
