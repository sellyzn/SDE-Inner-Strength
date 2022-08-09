using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No278_FirstBadVersion
    {
        public int FirstBadVersion(int n)
        {
            int left = 1, right = n;
            while(left < right)
            {
                int mid = left + (right - left) / 2;
                if (IsBadVersion(mid))
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }
        public bool IsBadVersion(int i)
        {
            return true;
        }
    }
}
