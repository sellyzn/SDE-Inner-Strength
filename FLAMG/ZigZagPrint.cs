using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG
{
    internal class ZigZagPrint
    {
        public string Convert(string s, int numsRows)
        {
            if (s == null || s.Length == 0)
                return "";
            int n = s.Length, r = numsRows;
            if (r == 1 || r >= n)
                return s;
            int t = r * 2 - 2;
            int c = (n + t - 1) / t * (r - 1);
            var mat = new char[r, c];
            int x = 0, y = 0;
            for (int i = 0; i < n; i++)
            {
                mat[x, y] = s[i];
                if (i % t < r - 1)
                    x++;
                else
                {
                    x--;
                    y++;
                }

            }
            var res = new StringBuilder();
            for(int i = 0; i < r; i++)
            {
                for(int j = 0; j < c; j++)
                {
                    if (mat[i, j] != null)
                        res.Append(mat[i, j]);
                }
            }

            return res.ToString();
        }
    }
}
