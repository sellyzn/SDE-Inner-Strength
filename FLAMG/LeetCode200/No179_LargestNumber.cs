using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    public class CustomCompiler : IComparer<string>
    {
        public int Compare(string a, string b)
        {
            if ((a + b).CompareTo(b + a) > 0)
                return 1;
            else
                return -1;
        }
    }
    internal class No179_LargestNumber
    {
        /// <summary>
        /// 自定义排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        /// T: O()
        /// S: O()
        /// 
        public string LargestNumber(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;
            var strArr = new string[nums.Length];
            for(int i = 0; i < nums.Length; i++)
            {
                strArr[i] = nums[i].ToString();
            }
            strArr = strArr.OrderByDescending(x => x, new CustomCompiler()).ToArray();
            var result = new StringBuilder();
            foreach (var str in strArr)
            {
                result.Append(str);
            }            
            int index = 0;
            while(index < result.Length && result[index] == '0')
            {
                result.Remove(index, 1);               
            }               

            return result.Length == 0 ? "0" : result.ToString();
        }
    }
}
