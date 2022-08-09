using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class ValidSudoku
    {
        /// <summary>
        /// 给一个二维数组，判断其是否为有效的数独
        /// 有效数独满足条件：
        /// 同一个数字在每一行只能出现一次
        /// 同一个数字在每一列只能出现一次
        /// 同一个数字在每一个小九宫格只能出现一次
        /// 
        /// 记录每一行，每一列，每一个小九宫格中，每个数字出现的次数。 
        /// 遍历一边数度表，在遍历的过程中更新计数，如果某个数字的个数 > 1， 则返回false， 若遍历完后都没有出现大于1的情况，则符合条件，为有效数独。
        /// 
        /// rows[9,9]: rows[i,index], 表示第i行的单元格所在行中，数字index+1出现的次数，其中0 <= index < 9，对应的数字index+1满足1 <= index+1 <= 9
        /// columns[9,9]： columns[i,index]表示第j列中。。。。。
        /// subBoxes[3,3,9]： subBoxes【i/3，j/3,index]: 第i行第i列所在的小九宫格中，。。。。。
        /// 
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        /// 一次遍历二维数组
        /// T: O(1)，81个格子
        /// S: O(1)
        public bool IsValidSudoku(char[][] board)
        {
            var rows = new int[9, 9];
            var columns = new int[9, 9];
            var subBoxes = new int[3, 3, 9];
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    var c = board[i][j];
                    if(c != '.')
                    {
                        int index = c - '0' - 1;
                        rows[i, index]++;
                        columns[j, index]++;
                        subBoxes[i / 3, j / 3, index]++;
                        if (rows[i, index] > 1 || columns[j, index] > 1 || subBoxes[i / 3, j / 3, index] > 1)
                            return false;
                    }
                }
            }
            return true;
        }
    }
}
