using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldII
{
    public class FindTheMissingNumberII
    {
        //Backtracking DFS
        //public int FindMissing2(int n, string str)
        //{
        //    int missing = -1;
        //    var visited = new bool[n + 1];
        //    DFS(n, str, visited, 0, missing);
        //    return missing;
        //}
        //public void DFS(int n, string str, bool[] visited, int count, int missing)
        //{
        //    if (str.Length == 0 && count == n - 1)
        //    {
        //        for (int i = 1; i <= n; i++)
        //        {
        //            if (visited[i] == false)
        //                missing = i;
        //        }
        //    }
        //    for (int i = 1; i <= 2 && i <= str.Length; i++)
        //    {
        //        var num = int.Parse(str.Substring(0, i));

        //        if (num == 0 || num > n || visited[num])
        //            continue;
        //        visited[num] = true;
        //        DFS(n, str.Substring(i, str.Length - i), visited, count, missing);
        //        visited[num] = false;
        //    }
        //}


        int missing = -1;
        public int FindMissing2(int n, String str)
        {
            // write your code here

            DFS(n, str, new bool[n + 1], 0);
            return missing;
        }
        private void DFS(int n, String str, bool[] visited, int count)
        {
            if (str.Length == 0 && count == n - 1)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (visited[i] == false)
                    {
                        missing = i;
                    }
                }
            }

            for (int i = 1; i <= 2 && i <= str.Length; i++)
            {
                int num = int.Parse(str.Substring(0, i));

                if (num == 0 || num > n || visited[num])
                {
                    continue;
                }

                visited[num] = true;
                DFS(n, str.Substring(i, str.Length - i), visited, count + 1);
                visited[num] = false;
            }
        }




        //int missing = -1;
        //public int FindMissing2(int n, String str)
        //{
        //    // write your code here
        //    if (n < 1 || str == null)
        //        return -1;
        //    DFS(n, str, 0, new bool[n + 1], 0);
        //    return missing;
        //}
        //private void DFS(int n, String str, int startIndex, bool[] visited, int count)
        //{
        //    if (startIndex == str.Length && count == n - 1)
        //    {
        //        for (int i = 1; i <= n; i++)
        //        {
        //            if (!visited[i])
        //            {
        //                missing = i;
        //                return;
        //            }
        //        }
        //        return;
        //    }

        //    for (int i = startIndex + 1; i <= startIndex + 2 && i <= str.Length; i++)
        //    {
        //        var subString = str.Substring(startIndex, i);
        //        int num = int.Parse(subString);

        //        if (num == 0 || num > n     //number should be valid 
        //            || visited[num]         //number should not be visited
        //            || num.ToString().Length != subString.Length)       //make sure the number doesn't start with 0
        //        {
        //            continue;
        //        }

        //        visited[num] = true;
        //        DFS(n, str, i, visited, count + 1);
        //        visited[num] = false;
        //    }
        //}










    }
}
