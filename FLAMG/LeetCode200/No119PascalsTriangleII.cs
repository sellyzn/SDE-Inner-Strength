using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No119PascalsTriangleII
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        /// T: O(K^2), 
        /// S: 
        public IList<int> GetRow(int rowIndex)
        {
            var curList = new List<int>();
            curList.Add(1);
            if(rowIndex == 0)
            {
                return curList;
            }
            for(int index = 1; index <= rowIndex; index++)
            {                
                var preList = curList;
                curList = new List<int>();
                curList.Add(1);
                for(int i = 1; i < index; i++)
                {
                    curList.Add(preList[i - 1] + preList[i]);
                }
                curList.Add(1);

            }
            return curList;
        }
    }
}
