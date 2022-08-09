using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Pramp
{
    internal class AwardBudgetCuts
    {
        /// <summary>
        /// 1.Sort - [100, 200, 300, 400 ]
        //  2.Replace maximum value with k, [ 100, 200, 300, k]
        //  3.Calculate k, k = (800 - 100 - 200 - 300) = 200
        //  4.If k is less than the next max, Repeat from step 2 , else done.
        //    2*. [100, 200, k, k]
        //    3* Calculate k, k = (800 - 100 - 200) / 2 = 250
        //    4* Done..
        /// </summary>
        /// <param name="grantsArray"></param>
        /// <param name="newBudget"></param>
        /// <returns></returns>
        /// T: O(NlogN)
        /// S: O(1)
        public double FindGrantsCap(double[] grantsArray, double newBudget)
        {
            Array.Sort(grantsArray);
            double sum = 0;
            foreach (var grant in grantsArray)
            {
                sum += grant;
            }
            var surplus = sum - newBudget;
            if(surplus <= 0)
                return grantsArray[0];

            for(int i = grantsArray.Length - 1; i >= 0; i--)
            {
                sum -= grantsArray[i];
                double k = (newBudget - sum) / (double)(grantsArray.Length - i);
                if (i - 1 >= 0 && k > grantsArray[i - 1] && k <= grantsArray[i])
                    return k;
                else if (i == 0 && k <= grantsArray[i])
                    return k;
            }
            return -1.0;
        }
    }
}
