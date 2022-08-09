using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class IsSubarray
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        /// T: O(MN)
        /// S: O(1)
        public bool IsSubarray1(int[] source, int[] target)
        {
            if(source.Length < target.Length)
                return false;
            int subLen = target.Length;
            for(int i = 0; i < source.Length && i + subLen <= source.Length; i++)
            {
                if(source[i] == target[0])
                {
                    int index = 0;
                    while(index < target.Length)
                    {
                        if (target[index] != source[i])
                            break;
                        else
                            index++;
                    }
                    if(index == target.Length)
                        return true;
                }
            }
            return false;
        }        
    }
}
