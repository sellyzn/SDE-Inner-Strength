using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Amazon.Easy
{
    public class SearchMatrix
    {
        //From right-top element, to do traverse
        //overtime xxxxxx
        public bool SearchMatrixI(int[][] matrix, int target)
        {
            int nr = matrix.Length;
            int nc = matrix[0].Length;
            int r = 0, c = nc - 1;
            while(r < nr && c >= 0)
            {
                int cur = matrix[r][c];
                if (cur == target)
                    return true;
                else if (cur < target)
                    r++;
                else
                    nc--;
            }
            return false;
        }
        public bool SearchMatrixI_BS1(int[][] matrix, int target)
        {
            int nr = matrix.Length;
            int nc = matrix[0].Length;
            int low = 0, high = nr * nc - 1;
            while(low <= high)
            {
                int mid = low + (high - low) / 2;
                int cur = matrix[mid / nc][mid % nc];
                if (cur < target)
                    low = mid + 1;
                else if (cur > target)
                    high = mid - 1;
                else
                    return true;
            }
            return false;
        }

        //From left-bottom
        public bool SearchMatrixII_LB(int[][] matrix, int target)
        {
            int nr = matrix.Length;
            int nc = matrix[0].Length;
            int r = nr - 1, c = 0;
            while(r >= 0 && c < nc)
            {
                if (matrix[r][c] == target)
                    return true;
                else if (matrix[r][c] > target)
                    r--;
                else
                    c++;
            }
            return false;
        }
        //From right-top
        //T: O(m + n)
        public bool SearchMatrixII_RT(int[][] matrix, int target)
        {
            int nr = matrix.Length;
            int nc = matrix[0].Length;
            int r = 0, c = nc - 1;
            while (r < nr && c >= 0)
            {
                if (matrix[r][c] == target)
                    return true;
                else if (matrix[r][c] > target)
                    c--;
                else
                    r++;
            }
            return false;
        }
        //Binary Search (Do BS for each row)
        //T:O(mlogn)
        public bool SearchMatrixII_BS(int[][] matrix, int target)
        {
            foreach (int[] row in matrix)
            {
                int index = Search(row, target);
                if (index >= 0)
                {
                    return true;
                }
            }
            return false;

        }
        public int Search(int[] nums, int target)
        {
            int low = 0, high = nums.Length - 1;
            while (low <= high)
            {
                int mid = (high - low) / 2 + low;
                int num = nums[mid];
                if (num == target)
                {
                    return mid;
                }
                else if (num > target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return -1;
        }

        
    }
}
