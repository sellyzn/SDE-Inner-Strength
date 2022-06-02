using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Other.Mock
{
    internal class NumberOfPaths
    {
        public static int NumOfPathsToDest(int n)
        {
            // your code goes here
            if (n == 1)
                return 1;
            //var matrix = new int[n,n];
            var queue = new Queue<int[]>();
            var visited = new int[n, n];
            queue.Enqueue(new int[] { 0, 0 });
            visited[0, 0] = 1;
            var count = 1;
            var directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } };
            while (queue.Count > 0)
            {
                var length = queue.Count;
                for (int i = 0; i < length; i++)
                {
                    var position = queue.Dequeue();
                    var x = position[0];
                    var y = position[1];
                    if (x == n - 1 && y == n - 1)
                        count++;
                    foreach (var dir in directions)
                    {
                        var newX = x + dir[0];
                        var newY = y + dir[1];
                        if (IsValid(newX, newY, n, visited))
                        {
                            queue.Enqueue(new int[] { newX, newY });
                            visited[newX, newY] = 1;
                        }
                    }
                }
            }
            return count;
        }
        public static bool IsValid(int x, int y, int n, int[,] visited)
        {
            if (x >= n || y >= n)
                return false;
            if (x < y)
                return false;
            if (visited[x, y] == 1)
                return false;
            return true;
        }

        static int count = 0;
        static int[][] directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 } };
        public int NumOfPathsToDest_DFS(int n)
        {
            
            var start = new int[] { 0, 0 };
            var dest = new int[] { n - 1, n - 1 };
            if (n == 1)
                return 1;
            FindPath(0, 0, n);
            return count;

        }
        public static void FindPath(int x, int y, int n)
        {
            for(int i = 0; i < directions.Length; i++)
            {
                var newX = x + directions[i][0];
                var newY = y + directions[i][1];
                if (newX == n - 1 && newY == n - 1)
                    count++;
                if(IsValid(newX, newY, n))
                    FindPath(newX, newY, n);
            }

        }
        public static bool IsValid(int x, int y, int n)
        {
            if (x >= n || y >= n)
                return false;
            if (x < y)
                return false;
           
            return true;
        }

        public int NumOfPathsToDest_DPSolution(int n)
        {
            var memo = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    memo[i, j] = -1;
                }
            }
            return NumOfPathsToSqure(n - 1, n - 1, memo);
        }
        public int NumOfPathsToSqure(int i, int j, int[,] memo)
        {
            if (i < 0 || j < 0)
                return 0;
            else if (i < j)
                memo[i, j] = 0;
            else if (memo[i, j] != -1)
                return memo[i, j];
            else if(i == 0 && j == 0)
                memo[i, j] = 1;
            else            
                memo[i, j] = NumOfPathsToSqure(i, j - 1, memo) + NumOfPathsToSqure(i - 1, j, memo);
            return memo[i, j];
        }

    }
}
