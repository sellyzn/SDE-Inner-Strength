using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No1423_MaximumPointsYouCanObtainFromCards
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="cardPoints"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// T: O(K)
        /// S: O(K)
        public int MaxScore(int[] cardPoints, int k)
        {
            int n = cardPoints.Length;
            var frontSetOfCards = new int[k + 1];
            var rearSetOfCards = new int[k + 1];
            frontSetOfCards[0] = 0;
            rearSetOfCards[0] = 0;
            for(int i = 1; i <= k; i++)
            {
                frontSetOfCards[i] = frontSetOfCards[i - 1] + cardPoints[i - 1];
                rearSetOfCards[i] = rearSetOfCards[i - 1] + cardPoints[n - i];
            }
            int maxScore = 0;
            for(int i =0; i <= k; i++)
            {
                var currentScore = frontSetOfCards[i] + rearSetOfCards[k - i];
               maxScore = Math.Max(maxScore, currentScore);
            }
            return maxScore;
        }

        /// <summary>
        /// 由于只能从开头和末尾拿 k 张卡牌，所以最后剩下的必然是连续的 n-k 张卡牌。
        /// 可以通过求出剩余卡牌点数之和的最小值，来求出拿走卡牌点数之和的最大值。
        /// 滑动窗口长度n - k
        /// </summary>
        /// <param name="cardPoints"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(1)
        public int MaxScore_SlidingWindow(int[] cardPoints, int k)
        {
            // 求所有卡牌点数和
            int n = cardPoints.Length;
            int windowSize = n - k;
            int sum = 0;
            foreach (var point in cardPoints)
            {
                sum += point;
            }
            int windowSum = 0;
            for(int i = 0; i < windowSize; i++)
            {
                windowSum += cardPoints[i];
            }
            int minSum = windowSum;
            for(int i = windowSize; i < n; i++)
            {
                windowSum = windowSum + cardPoints[i] - cardPoints[i - windowSize];
                minSum = Math.Min(minSum, windowSum);
            }
            return sum - minSum;
        }
    }
}
