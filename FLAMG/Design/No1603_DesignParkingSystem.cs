using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Design
{
    internal class No1603_DesignParkingSystem
    {
    }
    public class ParkingSystem
    {

        private int big;
        private int medium;
        private int small;

        public ParkingSystem(int big, int medium, int small)
        {
            this.big = big;
            this.medium = medium;
            this.small = small;
        }

        public bool AddCar(int carType)
        {
            if (carType == 1)
            {
                if (big > 0)
                {
                    big--;
                    return true;
                }
            }
            else if (carType == 2)
            {
                if (medium > 0)
                {
                    medium--;
                    return true;
                }
            }
            else if (carType == small)
            {
                if (small > 0)
                {
                    small--;
                    return true;
                }
            }
            return false;
        }
    }
}
