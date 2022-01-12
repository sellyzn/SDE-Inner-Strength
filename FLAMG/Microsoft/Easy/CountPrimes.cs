using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Microsoft.Easy
{
    public class CountPrimes
    {
        //////////////////
        // Count Primes //
        //////////////////
        ///
        //暴力法运行超时 Brute force method run timeout
        public int CountPrimes_BF(int n)
        {
            if (n <= 1)
                return 0;
            int count = 0;
            for(int i = 2; i < n; i++)
            {
                count += IsPrimes(i) ? 1 : 0;
            }
            return count;
        }
        public bool IsPrimes(int n)
        {
            for(int i = 2; i * i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        //optimize优化
        // If x is a prime, then 2x,3x,4x... are certainly not primes.
        // Define a flag array isPrime, which size is n. default value of isPrime[i] is 0.  assign all the element value of 1.
        // isPrime[i] means whether number i is a prime or not. if yes, remains isPrime[i] as 1, otherwise, change the value to 0;
        // traverse every number, if the number i is prime, then assign all of the multiples of i to 0.
        // 
        // Optimize again
        // flag from x * x, not x * 2
        public int CountPrime_OP(int n)
        {
            if (n <= 1)
                return 0;
            var isPrime = new int[n];
            int count = 0;
            for(int i = 2; i < n; i++)
            {
                if (isPrime[i] == 0)
                {
                    count += 1;
                    if(i * i < n){    // i * 2 is ok  // (long) i * 2 ?? need long?
                        for(int j = i * i; j < n; j += i)   // i * 2 is ok
                        {
                            isPrime[j] = 1;
                        }
                    }
                }
            }
            return count;
        }

        /////////////////
        // Ugly Number //
        /////////////////
        //
        // Math
        //
        // Repeatedly divide n by 2, 3, 5, until n no longer contains prime factors 2,3,5.
        // If the remaining number is equal to 1, it means that n does not contains other prime factors and is an ugly number;
        // otherwise, it means that n contains other prime factors and is not an ugly number.
        //
        // Repeatedly divide n by 2, 3, 5. judge whether the remaining number is equal to 1. If yes, true, otherwise, false.
        //Time complexity: O(logn)

        public bool IsUgly(int num)
        {
            if (num <= 0)
                return false;
            while(num != 1)
            {
                if (num % 2 == 0)
                    num /= 2;
                else if (num % 3 == 0)
                    num /= 3;
                else if (num % 5 == 0)
                    num /= 5;
                else
                    return false;
            }
            return true;
        }




        ////////////////////
        // Ugly Number II //
        ////////////////////
        //
        // Dynamic Programing
        //
        // Define an array dp, which size is n. dp[i] means the (i-1)th ugly number, the nth ugly number is dp[n-1].
        // Define three pointers: p2,p3,p5, means the next ugly number is the ugly number, that the current pointer points to, multiply the corresponding prime number. the initial value of the three number are 0;
        // when 1 <= i < n, dp[i] = Min(dp[p2],dp[p3],dp[p5]), then compare if dp[i] is equal to dp[p2] * 2, or dp[p3] * 3, or dp[p5] * 5, add 1 to the corresponding pointer.
        //
        //TC: O(n)


        public int NthUglyNumber(int n)
        {
            int a = 0, b = 0, c = 0;
            int[] dp = new int[n];
            dp[0] = 1;
            for(int i = 1; i < n; i++)
            {
                int n2 = dp[a] * 2;
                int n3 = dp[b] * 3;
                int n5 = dp[c] * 5;
                dp[i] = Math.Min(Math.Min(n2, n3), n5);
                if (dp[i] == n2)
                    a++;
                if (dp[i] == n3)
                    b++;
                if (dp[i] == n5)
                    c++;
            }
            return dp[n - 1];
        }



    }
}
