using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverI
{
    public class CombinationAndJudgmentPrimeNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></the n numbers>
        /// <param name="k"></the number of integer you can choose>
        /// <returns></how many ways that the sum of the k integers is a prime number>
        public int GetWays(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            return DFS(nums, k, 0, 0, 0);
        }
        public bool IsPrime(int n)
        {
            for(int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></the n numbers>
        /// <param name="k"></param>
        /// <param name="index"></the index of current traversed number>
        /// <param name="numberAlreadPick"></ the current already picked numbers>
        /// <param name="sum"></current sum of the numbers alread picked>
        /// <returns></returns>
        public int DFS(int[] nums, int k, int index, int numberAlreadPick, int sum)
        {
            if(numberAlreadPick == k)
            {
                return IsPrime(sum) ? 1 : 0;
            }
            if(index >= nums.Length)
            {
                return 0;
            }

            //?????????????????????????????????????????????????????????????
            int count = 0;
            count += DFS(nums, k, index + 1, numberAlreadPick + 1, sum);
            count += DFS(nums, k, index + 1, numberAlreadPick, sum);
            return count;
        }
    }
}
