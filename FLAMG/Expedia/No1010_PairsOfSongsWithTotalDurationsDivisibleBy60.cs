using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No1010_PairsOfSongsWithTotalDurationsDivisibleBy60
    {
        /// <summary>
        /// Brute Force
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public int NumPairsDivisibleBy60(int[] time)
        {
            if (time == null || time.Length < 2)
                return 0;
            int count = 0;
            for(int i = 0; i < time.Length - 1; i++)
            {
                for(int j = i + 1; j < time.Length; j++)
                {
                    if ((time[i] + time[j]) % 60 == 0)
                        count++;
                }
            }
            return count;
        }
        public int NumPairsDivisibleBy60Op(int[] time)
        {
            int[] remainders = new int[60];
            int count = 0;
            foreach (var t in time)
            {
                if (t % 60 == 0)
                    count += remainders[0];
                else
                    count += remainders[60 - t % 60];
                remainders[t % 60]++;
            }
            return count;
        }
    }
}
