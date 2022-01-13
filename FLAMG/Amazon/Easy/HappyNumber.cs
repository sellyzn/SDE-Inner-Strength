using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Amazon.Easy
{
    public class HappyNumber
    {
        //////////////////
        // Happy Number //
        //////////////////
        //
        // 1. use Hashset to detect cycles
        // 2. Two Pointers


        //
        //Three possible cases:
        //      1. End up with result is 1.
        //      2. Enter a loop
        //      3. The value will get larger and larger, and finally approach infinity (Impossible case)
        //
        // TC: O(logn)
        // SC: O(logn)

        public bool IsHappy(int n)
        {
            var set = new HashSet<int>();
            while (n != 1 && !set.Contains(n))
            {
                set.Add(n);
                n = GetNext(n);
            }
            return n == 1;
        }
        public int GetNext(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                int digit = n % 10;
                sum += digit * digit;
                n /= 10;
            }
            return sum;
        }

        // Two pointers
        // TC: O(logn)
        // SC: O(1)
        public bool IsHappy_TP(int n)
        {
            int slow = n;
            int fast = GetNext(n);   // wrong: fast = n;
            while (fast != 1 && slow != fast)
            {
                slow = GetNext(slow);
                fast = GetNext(GetNext(fast));
            }
            return fast == 1;
        }


        ///////////////////////
        // Linked List Cycle //
        ///////////////////////
        //
        //
        //






        /////////////////
        // Ugly Number //
        /////////////////
        //
        //
        //
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
        //
        //
        public int NthUglyNumber(int n)
        {
            int i2 = 0, i3 = 0, i5 = 0;
            int[] dp = new int[n];
            dp[0] = 1;
            for (int i = 1; i < n; i++)
            {
                int n2 = dp[i2] * 2;
                int n3 = dp[i3] * 3;
                int n5 = dp[i5] * 5;
                dp[i] = Math.Min(Math.Min(n2, n3), n5);
                if (dp[i] == n2)
                    i2++;
                if (dp[i] == n3)
                    i3++;
                if (dp[i] == n5)
                    i5++;
            }
            return dp[n - 1];
        }

        ////////////////
        // Add Digits //
        ////////////////
        //
        // Math, Simulation
        //
        public int AddDigits(int num)
        {
            if (num == 0)
                return 0;
            
            while(num > 9)
            {
                num = GetSum(num);
            }
            return num;
        }
        public int GetSum(int num)
        {
            int sum = 0;
            while(num > 0)
            {
                int digit = num % 10;
                sum += digit;
                num /= 10;
            }
            return sum;
        }




    }
}
