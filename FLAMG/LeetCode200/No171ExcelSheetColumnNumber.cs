using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No171ExcelSheetColumnNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnTitle"></param>
        /// <returns></returns>
        /// 
        /// T: O(N)
        /// O: O(1)
        public int TittleToNumber(string columnTitle)
        {
            if(columnTitle == null || columnTitle.Length == 0)
                return 0;
            int res = 0;
            for(int i = 0; i < columnTitle.Length; i++)
            {
                res = res * 26 + (columnTitle[i] - 'A' + 1);
            }
            return res;
        }
    }
}
