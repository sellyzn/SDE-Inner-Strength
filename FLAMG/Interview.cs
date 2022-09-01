using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG
{
    /*
     
     Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
No duplicate element, you may not use the same element twice.
You can return the answer in any order. 
If there is no such pair, return an empty array.

Input: nums = [2,11,7,15], target = 9
Output: [0,2]
*/
    // hashmap<int, int>
    //         num, index
    internal class Interview
    {
        // a + b = target
        //
        // b = target - a
        /*
                  i
         nums :  [2,11,7,15], target: 9
        diff:     7
        dict: {{2, 0}, }
         
         */

        public int[] TwoSumIndices(int[] nums, int target)
        {
            var result = new int[2];
            var dict = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];
                if (dict.ContainsKey(diff))
                {
                    result[0] = dict[diff];
                    result[1] = i;
                }
                dict.Add(nums[i], i);
            }
            return result;
        }

        public void PrintSinWave(int waveHeight, int waveLength)
        {
            int innerSpace = 1, outerSpace = 2;
            for(int i = 0; i < waveHeight; i++)
            {
                for(int j = 0; j < waveHeight; j++)
                {
                    // intermediate spaces
                    for(int k = 0; k < outerSpace; k++)
                    {
                        Console.WriteLine(" ");
                    }
                    for (int k = 1; k <= innerSpace; k++)
                        Console.Write(" ");

                    // put any symbol
                    Console.Write("0");

                    for (int k = 1; k <= outerSpace; k++)
                        Console.Write(" ");

                    Console.Write(" ");

                }
                // set a value of os to 1 if i+1
                // is not equal to wave height
                // or 0 otherwise
                outerSpace = (i + 1 != waveHeight) ? 1 : 0;

                // set value of is to 3 if i+1 is not
                // equal to wave height or 5 otherwise
                innerSpace = (i + 1 != waveHeight) ? 3 : 5;

                Console.Write("\n");
            }
        }
    }
}
