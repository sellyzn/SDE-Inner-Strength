using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.DailyProblem
{
    internal class TheNumberofWeakCharactersintheGame
    {
        // 1996. The Number of Weak Characters in the Game
        /*
                      i
        properties: [[7,7],[1,2],[9,7],[7,3],[3,10],[9,8],[8,10],[4,3],[1,5],[1,5]]

        properties: [1,2],[1,5],[1,5],[3,10],[4,3],[7,7],[7,3],[8,10],[9,7][9,8]

        dp:           0     0     0     3   
        
        properties: [[7,9],[10,7],[6,9],[10,4],[7,5],[7,10]]
         sorted:    [6,9],[7,9],[7,5],[7,10],[10,7],[10,4]
        sorted1:    [6,9],[7,5],[7,9],[7,10],[10,4],[10,7]

        dp:            0    0     0     1       1      0

         */
        public int NumberOfWeakCharacters(int[][] properties)
        {
            if (properties == null || properties.Length <= 1)
                return 0;
            // sort by the attack values
            //properties = properties.OrderBy(x => x[0]).ToArray();
            Array.Sort(properties, (o1, o2) =>
            {
                return o1[0] == o2[0] ? o2[1] - o1[1] : o2[0] - o1[0];
            });

            // dp[i]: 比properties[i]属性弱的元素个数
            var dp = new int[properties.Length];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = 0;
            }
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (properties[j][0] < properties[i][0] && properties[j][1] < properties[i][1])
                    {
                        dp[i]++;
                    }
                }
            }
            return dp.Max();
        }
        public int NumberOfWeakCharactersAns(int[][] properties)
        {
            if (properties == null || properties.Length <= 1)
                return 0;
            Array.Sort(properties, (o1,o2) =>
            {
                return o1[0] == o2[0] ? o2[1] - o1[1] : o2[1] - o1[0];
            });

            var pre = properties[0][1];
            var ans = 0;
            for(int i = 1; i < properties.Length; i++)
            {
                if(properties[i][1] > pre)
                {
                    ans++;
                }
                else
                {
                    pre = properties[i][1];
                }
            }
            return ans;
        }
    }
}
