using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG
{
    public class BeaconfireInterview
    {
        public int MaxProfit(int[] prices)
        {

            //1.find the min index and value
            //int index = 0;
            int minValue = prices[0];
            int maxProfit = 0;
            for(int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minValue)
                {
                    minValue = prices[i];
                    //index = i;                     
                }
                maxProfit = Math.Max(maxProfit, prices[i] - minValue);
            }
            //// search the array from index to the end, find the max profit
            //for(int i = index; i < prices.Length; i++)
            //{
            //}

            return maxProfit;
        }
    }
}
