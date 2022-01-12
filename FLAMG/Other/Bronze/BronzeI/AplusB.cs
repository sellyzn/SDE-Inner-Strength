using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzeI
{
    public class AplusB
    {
        public int aplusb(int a, int b)
        {
            while (b != 0)
            {
                int carry = (a & b) << 1;
                a ^= b;
                b = carry;
            }
            return a;
        }
    }
}
