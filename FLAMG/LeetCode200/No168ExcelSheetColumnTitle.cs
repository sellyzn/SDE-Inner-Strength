using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No168ExcelSheetColumnTitle
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <returns></returns>
        /// T: O(log26columnNumber)
        /// S: O(1)
        public string ConvertToTittle(int columnNumber)
        {
            if (columnNumber <= 0)
                return "";
            var sb = new StringBuilder();
            while(columnNumber > 0)
            {
                var ch = (char)((columnNumber - 1) % 26 + 'A');
                sb.Insert(0, ch);
                columnNumber = (columnNumber - 1) / 26;
            }
            return sb.ToString();
        }
    }
}
