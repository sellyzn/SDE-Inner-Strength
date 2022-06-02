using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Google.MockInterview
{
    public class DIStringMatch
    {
        public int[] DiStringMatch(string s)
        {
            var n = s.Length;
            var res = new int[n + 1];
            if (s == null || s.Length == 0)
                return res;
            int low = 0, high = n;
            for (int i = 0; i < n; i++)
            {
                if (s[i] == 'I')
                    res[i] = low++;
                if (s[i] == 'D')
                    res[i] = high--;
            }
            res[n] = high;   /// or low
            return res;
        }
    }
}
