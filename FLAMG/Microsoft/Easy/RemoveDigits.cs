using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Microsoft.Easy
{
    /////////////////////
    // Remove K Digits //
    /////////////////////

    // Stack + Greedy
    // 
    //Greedy method (Delete one digit from a number sequence)
    // traverse from left to right, find the first index i that D(i) < D(i-1), delete D(i-1);
    // If it does not exist, it means that the entire number sequence is monotonous and does not descend, just delete the last number. 
    
    //Greedy method (Delete k digits from a number sequence)
    // stack (using two-side queue List to do remove, add, and get operations)

   

    public class RemoveDigits
    {
        public string RemoveKdigits(string num, int k)
        {
            if (num.Length <= k)
                return "0";
            var queue = new List<char>();
            for (int i = 0; i < num.Length; i++)
            {
                // while loop, make sure all of the digits in stack are smaller than the current traversed digit.
                while (queue.Count > 0 && k > 0 && queue[queue.Count - 1] > num[i])
                {
                    queue.RemoveAt(queue.Count - 1);
                    k--;
                }                    
                queue.Add(num[i]);                
            }
            //case: k still larger than 0 after traversed, means the stack is monotomous increasing
            //      if the num sequence is monotomous increasing, delete the top element of the stack.
            for(int i = 0; i < k; i++)
            {
                queue.RemoveAt(queue.Count - 1);
            }
            // case: the first digit in stack is 0
            int index = 0, len = queue.Count;
            for (int i = 0; i < len; i++)
            {
                if (queue[i] != '0')
                {
                    index = i;
                    break;
                }
                index++;
            }
            // if the last stack is empty after delete the digits of 0 in front, return 0.
            if (index == len)
                return "0";
            //get the result sequence
            var sb = new StringBuilder();
            for(int i = index; i < len; i++)
            {
                sb.Append(queue[i]);
            }
            return sb.ToString();
        }

        ////////////////////////////////
        // Monotone Increasing Digits //
        ////////////////////////////////

        //

        public int MonotoneIncreasingDigits(int n)
        {
            char[] strN = n.ToString().ToCharArray();
            //for(int i = ch.Length - 1; i > 0; i--)
            //{
            //    if(ch[i - 1] > ch[i])
            //    {
            //        ch[i] = '9';
            //        ch[i - 1] -= '1';
            //    }
            //}
            int i = 1;
            while (i < strN.Length && strN[i - 1] <= strN[i])
                i++;
            if(i < strN.Length)
            {
                while(i > 0 && strN[i - 1] > strN[i])
                {
                    strN[i - 1]--;
                    i--;
                }
                for(i += 1;i < strN.Length; i++)
                {
                    strN[i] = '9';
                }
            }
            var sb = new StringBuilder();
            for (int j = 0; j < strN.Length; j++)
            {
                sb.Append(strN[j]);
            }
            return int.Parse(sb.ToString());
        }
        //public int MonotoneIncreasingDigits(int n)
        //{
        //    int res = n;
        //    while(n >= 0)
        //    {
        //        if (IsMonotoneIncreasingDigits(n))
        //        {
        //            res = n;
        //            return res;
        //        }  
        //        else
        //            n--;
        //    }
        //    return res;
        //}
        //public bool IsMonotoneIncreasingDigits(int n)
        //{
        //    var numsequence = NumToString(n);
        //    if (numsequence.Length == 1)
        //        return true;
        //    for(int i = 1; i < numsequence.Length; i++)
        //    {
        //        if (numsequence[i] < numsequence[i - 1])
        //            return false;
        //    }
        //    return true;
        //}
        //public string NumToString(int n)
        //{
        //    var sb = new StringBuilder();
        //    while(n > 0)
        //    {
        //        int digit = n % 10;
        //        sb.Insert(0, digit);
        //        n /= 10;
        //    }
        //    return sb.ToString();
        //}


    }
}
