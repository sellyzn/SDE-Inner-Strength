using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.DailyOct
{
    internal class MinimumTimeToMakeRopeColorful
    {
        public int MinCost(string colors, int[] neededTime)
        {
            if(colors == null || colors.Length <= 1)
                return 0;
            var totalCost = 0;
            foreach(var time in neededTime)
            {
                totalCost += time;
            }
            int left = 0, right = 0;            
            while (right < colors.Length)
            {
                while(right < colors.Length && colors[right] == colors[left])
                {
                    right++;
                }
                var maxValue = FindMax(neededTime, left, right);
                totalCost -= maxValue;
                left = right;
                
            }
            return totalCost;
        }
        public int FindMax(int[] arr, int left, int right)
        {
            var maxValue = arr[left];
            for(int i = left; i < right; i++)
            {
                maxValue = Math.Max(arr[i], maxValue);
            }
            return maxValue;
        }
        
    }
}
