using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldI
{
    public class CanReachTheEndpoint
    {
        //BFS模板题
        public bool ReachEndpoint(int[][] map)
        {
            int row = map.Length;
            int colum = map[0].Length;
            if (row == 0 || colum == 0)
            {
                return false;
            }
            Queue<int> q = new Queue<int>();
            bool[,] vis = new bool[row, colum];
            int[] dx = { 0, 1, 0, -1 };
            int[] dy = { 1, 0, -1, 0 };
            q.Enqueue(0);
            vis[0, 0] = true;
            while (q.Count > 0)
            {
                int cur = q.Dequeue();
                int curx = cur / colum;
                int cury = cur % colum;
                for (int i = 0; i < 4; i++)
                {
                    int nx = curx + dx[i];
                    int ny = cury + dy[i];
                    if (nx < 0 || nx >= row || ny < 0 || ny >= colum || vis[nx, ny] || map[nx][ny] == 0)
                    {
                        continue;
                    }
                    if (map[nx][ny] == 9)
                    {
                        return true;
                    }
                    q.Enqueue(nx * colum + ny);
                    vis[nx, ny] = true;
                }
            }
            return false;
        }
    }
}
