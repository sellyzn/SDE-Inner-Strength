using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Contest
{
    internal class Contest297
    {
        public double CalculateTax(int[][] brackets, int income)
        {
            if (brackets == null || brackets.Length == 0)
                return 0;
            if (income <= 0)
                return 0;
            double tax = 0;
            for(int i = 0; i < brackets.Length; i++)
            {                
                double curTax = 0;
                if(i == 0)
                {
                    if(brackets[i][0] <= income)
                    {

                        //var taxRate = brackets[i][1] * 0.01;
                        //var taxLevel = System.Convert.ToDouble(brackets[i][0]);
                        //curTax = taxLevel * taxRate;
                        curTax = (brackets[i][0] * brackets[i][1]) * 0.01;
                        tax = curTax;
                    }
                    else
                    {
                        curTax = income * brackets[i][1] * 0.01;
                        return curTax;
                    }
                }
                else
                {
                    if (brackets[i - 1][0] < income)
                    {
                        if (income >= brackets[i][0])
                        {
                            curTax = (brackets[i][0] - brackets[i - 1][0]) * brackets[i][1] * 0.01;
                            tax += curTax;
                        }
                        else
                        {
                            curTax = (income - brackets[i - 1][0]) * brackets[i][1] * 0.01;
                            tax += curTax;
                        }
                    }
                    else
                    {
                        break;
                    }
                }                                   
            }
            //if (income >= brackets[brackets.Length - 1][0])
            //{
            //    tax += (income - brackets[brackets.Length - 1][0] * 0.01);
            //}
            return tax;
        }
        //public int MinPathCost(int[][] grid, int[][] moveCost)
        //{
        //    int m = grid.Length;
        //    int n = grid[0].Length;
            
        //}
        //public int DistributeCookies(int[] cookies, int k)
        //{
        //    Array.Sort(cookies);
        //    int n = cookies.Length;
        //    var totalSum = 0;
        //    foreach (var cookie in cookies)
        //    {
        //        totalSum += cookie;
        //    }
        //    int average = totalSum / k;
        //    var max = cookies[n - 1];
        //    var arr = new int[k];
        //    var sum = 0;
        //    for(int i = 0; i < n; i++)
        //    {
                
        //    }

        //}
    }
}
