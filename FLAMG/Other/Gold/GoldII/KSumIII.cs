using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldII
{
    public class KSumIII
    {
        //K Sum III
        //Given n positive integers, integer k and a number target.
        //Find k odd numbers or k even numbers where sum is target.Calculate how many solutions there are?

        int n, result;
        int[] b;
        public int GetAns(int[] a, int k, int target)
        {
            // write your code here
            n = a.Length;
            b = new int[n + 1];
            result = 0;
            for (int i = 0; i < n; i++)
            {
                b[i] = a[i];
            }
            DFS(0, k, -1, target);
            return result;
        }
        void DFS(int start, int count, int flag, int sum)
        {
            if (count <= 0)
            {
                if (sum == 0) result++;
                return;
            }
            for (int i = start; i < n; i++)
            {
                if (flag == -1 || flag == (b[i] & 1))
                {
                    DFS(i + 1, count - 1, b[i] & 1, sum - b[i]);
                }
            }
        }



        //// K Sum II
        ////Given n unique postive integers, number k (1<=k<=n) and target.
        ////Find all possible k integers where their sum is target.
        //public List<List<int>> KSumII(int[] A, int k, int target)
        //{
        //    // write your code here
        //}



        //// K Sum
        ////Given n distinct positive integers, integer k (k≤n) and a number target.
        ////Find k numbers where sum is target.Calculate how many solutions there are?
        //public int KSumI(int[] A, int k, int target)
        //{
            
        //}


    }
}
