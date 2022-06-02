using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.BFS
{
    public class KeysAndRooms
    {
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            if (rooms.Count == 0)
                return true;

            var visited = new HashSet<int>();
            var queue = new Queue<int>();
            var visitNums = 0;
            foreach (var item in rooms[0])
            {
                if (!visited.Contains(item))
                {
                    visitNums++;
                    queue.Enqueue(item);
                    visited.Add(item);
                }
            }
            while (queue.Count > 0)
            {
                var length = queue.Count;
                for (int i = 0; i < length; i++)
                {
                    var num = queue.Dequeue();
                    foreach (var item in rooms[num])
                    {
                        if (!visited.Contains(item))
                        {
                            visitNums++;
                            queue.Enqueue(item);
                            visited.Add(item);
                        }
                    }
                }
            }
            if (visited.Contains(0))
                return visitNums == rooms.Count;
            else
                return visitNums == rooms.Count - 1;

            //注意：无论有没有数字0， 第一次访问的房间都是从0号房间开始
            // 不用特意处理room元素中的空list
        }
    }
}
