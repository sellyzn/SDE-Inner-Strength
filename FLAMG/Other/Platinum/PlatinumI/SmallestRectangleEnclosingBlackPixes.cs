using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Platinum.PlatinumI
{
    public class Pair
    {
        public int x;
        public int y;

        public Pair(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class SmallestRectangleEnclosingBlackPixes
    {
        private int[][] MOVES = new int[][]{ new int[]{ 0, -1 }, new int[]{ -1, 0 }, new int[]{ 0, 1 }, new int[]{ 1, 0 } };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="x"></param> black pixels location (x, y)
        /// <param name="y"></param> black pixels location (x, y)
        /// <returns></returns> the area of the smallest (axis-aligned) rectangle that encloses all black pixels
        public int MinArea(char[][] image, int x, int y)
        {
            // BFS -> Time: O(S), S == Area of black pixels region; Space: O(S)
            int n = (image == null) ? 0 : image.Length;
            int m = (n == 0) ? 0 : image[0].Length;
            if (n == 0 || m == 0)
            {
                return 0;
            }

            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int maxX = int.MinValue;
            int maxY = int.MinValue;

            Queue<Pair> queue = new Queue<Pair>();

            queue.Enqueue(new Pair(x, y));
            image[x][y] = '0';

            while (queue.Count > 0)
            {
                Pair curr = queue.Dequeue();

                minX = Math.Min(minX, curr.x);
                minY = Math.Min(minY, curr.y);
                maxX = Math.Min(maxX, curr.x);
                maxY = Math.Min(maxY, curr.y);

                foreach (int[] move in MOVES)
                {
                    int nx = curr.x + move[0];
                    int ny = curr.y + move[1];

                    if (nx >= 0 && nx < n && ny >= 0 && ny < m && image[nx][ny] == '1')
                    {
                        queue.Enqueue(new Pair(nx, ny));
                        image[nx][ny] = '0';
                    }
                }
            }

            int width = maxY - minY + 1;
            int height = maxX - minX + 1;

            return width * height;
        }
    }
}
