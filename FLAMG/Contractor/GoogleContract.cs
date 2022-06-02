using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Contractor
{
    public class GoogleContract
    {
        public bool CanConstruct(int[] sequence, int[][] sub_sequence)
        {
            var construct_set = new HashSet<int[]>();
            
            var index = 0;
            var sequence_length = sequence.Length;
            // traverse sequence
            while(index < sequence_length)
            {
                int i;
                //int curIndex = index;
                // For each element in sequence, traverse subsequence
                for (i = 0; i < sub_sequence.Length; i++)
                {                        
                    int cur_index = index;
                    // If the sub_sequence[i] has been selected to contruct the sequence, we should skip this subsequence and continue 
                    if (construct_set.Contains(sub_sequence[i]))
                    {                        
                        continue;
                    }
                    else
                    {
                        // Start from the first element of the sub_sequence: sub_sequence[0]
                        var j = 0;
                        // Use while loop to traverse the current sub_sequence[i]:
                        // If the sub_equence[i][j] is equal to sequence[tempIndex], and traverse process is not finished to the end of sub_sequence[i], we should move tempIndex and j forward.
                        while (cur_index < sequence.Length && j < sub_sequence[i].Length && sub_sequence[i][j] == sequence[cur_index])
                        {
                            cur_index++;
                            j++;
                        }
                        // After traversed the sub_sequence[i], if j == sub_sequence[i].Length, it means that the current sub_sequence[i] can be added to the construct set.
                        // and we should update the index value to the current curIndex value;
                        // break for the next loop
                        if (j == sub_sequence[i].Length)
                        {
                            construct_set.Add(sub_sequence[i]);
                            index = cur_index;
                            break;
                        }                                 
                    }                   
                    
                }
                // After traversed all element in sub_sequence and not found one can construct to the sequence, we will return false in advance
                if (i == sub_sequence.Length && !construct_set.Contains(sub_sequence[i - 1]))
                {
                    return false;
                }
            }            
           
            // If we traversed all elements of sequence, it means we can construct the sequence from sub_sequence, return true, otherwise, return false.
            return index == sequence.Length;
        }
    }
}
