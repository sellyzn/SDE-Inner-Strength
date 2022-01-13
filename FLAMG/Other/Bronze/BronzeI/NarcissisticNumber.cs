using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzeI
{
    public class NarcissisticNumber
    {
        //public List<int> GetNarcissisticNumber(int n)
        //{
        //    List<int> res = new List<int>();
        //    int minValue = 0;
        //    int maxValue = 0;
        //    while(n > 0)
        //    {
        //        maxValue = maxValue * 10 + 9;
        //        n--;
        //    }
        //    minValue = maxValue / 10 + 1;
        //    for (int i = minValue; i <= maxValue; i++)
        //    {
        //        if (IsNarcissisticNumber(i))
        //        {
        //            res.Add(i);
        //        }
        //    }
        //    return res;
        //}
        //public bool IsNarcissisticNumber(int n)
        //{
        //    if (n == 0)
        //        return true;
        //    int sum = 0;
        //    int power = 0;
        //    int m = n;
        //    while (m > 0)
        //    {
        //        power++;
        //        m /= 10;
        //    }
        //    while (n > 0)
        //    {
        //        int digit = n % 10;
        //        int p = power;
        //        while (p > 0)
        //        {
        //            digit *= digit;
        //            p--;
        //        }
        //        sum += digit;
        //    }
        //    return sum == n;
        //}
        public List<int> GetNarcissisticNumbers(int n)
        {
            var res = new List<int>();
            if (n == 0)
                return res;
            int minValue = (int)Math.Pow(10, n - 1);
            if (n == 1)
                minValue = 0;
            int maxValue = (int)Math.Pow(10, n);
            for (int i = minValue; i < maxValue; i++)
            {
                //if (IsNarcissisticNumber(i))
                //{
                //    res.Add(i);
                //}
                int sum = 0;
                int k = i;
                while(k > 0)
                {
                    sum += (int)Math.Pow(k % 10, n);
                    k /= 10;
                }
                if(sum == i)
                {
                    res.Add(i);
                }
            }
            return res;
        }
    }
}
