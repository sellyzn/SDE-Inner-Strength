using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudyPlan.BinarySearch
{
    internal class KoKoEatingBananas
    {
        public int MinEatingSpeed(int[] piles, int h)
        {
            int left = 1, right = GetMax(piles);
            while(left < right)
            {
                int mid = left + (right - left) / 2;
                if(CanFinish(piles, mid, h))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }
        public int GetMax(int[] piles)
        {
            var max = 0;
            foreach (var num in piles)
            {
                max = Math.Max(max, num);
            }
            return max;
        }
        public bool CanFinish(int[] piles, int speed, int h)
        {
            int time = 0;
            foreach (var num in piles)
            {
                time += TimeOf(num, speed);
            }
            return time <= h;
        }
        public int TimeOf(int n, int speed)
        {
            return (n / speed) + ((n % speed) > 0 ? 1 : 0);
        }
    }
}
