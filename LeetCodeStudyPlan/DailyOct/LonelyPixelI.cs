using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.DailyOct
{
    internal class LonelyPixelI
    {
        public int FindLonelyPixel(char[][] picture)
        {
            int m = picture.Length;
            int n = picture[0].Length;

            var rowCount = new int[m];
            var columnCount = new int[n];

            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(picture[i][j] == 'B')
                    {
                        rowCount[i]++;
                        columnCount[j]++;
                    }
                }
            }
            int res = 0;
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (picture[i][j] == 'B' && rowCount[i] == 1 && columnCount[j] == 1)
                        res++;
                }
            }
            
            return res;
        }
        //public int FindLonelyPixel(char[][] picture)
        //{
        //    var rows = picture.Length;
        //    if(rows == 0) return 0;
        //    var cols = picture[0].Length;
        //    if(cols == 0) return 0;
        //    int result = 0;
        //    var visited = new bool[rows, cols];
        //    for(int i = 0; i < rows; i++)
        //    {
        //        for(int j = 0; j < cols; j++)
        //        {
        //            if(!visited[i, j])
        //            {
        //                var size = BFS(picture, i, j, visited);
        //                if (size == 1)
        //                    result++;
        //            }                    
        //        }
        //    }
        //    return result;
        //}
        //public int BFS(char[][] picture, int x, int y, bool[,] visited)
        //{
        //    if (picture[x][y] == 'W')
        //        return 0;
        //    var size = 1;
        //    var queue = new Queue<int[]>();
        //    queue.Enqueue(new int[] {x, y});
        //    var directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
        //    while(queue.Count > 0)
        //    {
        //        var node = queue.Dequeue();
        //        foreach (var dir in directions)
        //        {
        //            var newX = node[0] + dir[0];
        //            var newY = node[1] + dir[1];
        //            if(newX >= 0 && newX < picture.Length && newY >= 0 && newY < picture[0].Length && !visited[newX,newY])
        //            {
        //                if (picture[newX][newY] == 'B')
        //                {
        //                    size++;
        //                    queue.Enqueue(new int[] { newX, newY });
        //                    visited[newX,newY] = true;
        //                }
        //            }
        //        }
        //    }
        //    return size;
        //}
    }
}
