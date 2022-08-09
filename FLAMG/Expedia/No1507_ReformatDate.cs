using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No1507_ReformatDate
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /// T: O(1)
        /// S: O(1)
        public String ReformatDate(string date)
        {
            var dateArr = date.Split(" ");
            var dict = new Dictionary<string, int>() { { "Jan", 01 }, { "Feb", 02 }, { "Mar", 03 }, { "Apr", 04 }, { "May", 05 }, { "Jun", 06 }, { "Jul", 07 }, { "Aug", 08 }, { "Sep", 09 }, { "Oct", 10 }, { "Nov", 11 }, { "Dec", 12 } };

            var year = dateArr[2];
            var month = dict[dateArr[1]];
            var day = 0;
            int index = 0;
            while (index < dateArr[0].Length)
            {
                if (dateArr[0][index] >= '0' && dateArr[0][index] <= '9')
                    index++;
                else
                    break;
            }

            var dayStr = dateArr[0].Substring(0, index);

            day = int.Parse(dayStr);


            return string.Format("{0}-{1:D2}-{2:D2}", year, month, day);
        }
    }
}
