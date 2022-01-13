using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldI
{
    public class ReachANumber
    {
        public int ReachNumber(int target)
        {
            //target = Math.Abs(target);
            //int k = 0;
            //while (target > 0)
            //    target -= ++k;
            //return target % 2 == 0 ? k : k + 1 + k % 2;


            target = Math.Abs(target);

            int step = 1, pos = 0;
            while (pos < target)
            {
                pos += step;
                step++;
            }
            step--;

            if (pos == target) return step;

            pos -= target;
            if (pos % 2 == 0)
            {
                return step;
            }
            else if ((step + 1) % 2 == 1)
            {
                return step + 1;
            }
            else
            {
                return step + 2;
            }
        }
    }
}
