using FLAMG.LeetCode200;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.ExpediaVO
{
    internal class ConvertBinaryNumberInALinkedListToInteger
    {
        public int GetDecimalValue(ListNode head)
        {
            //var num = head.val;
            //while(head.next != null)
            //{
            //    num = num * 2 + head.next.val;
            //    head = head.next;
            //}
            //return num;
            var num = 0;
            while(head != null)
            {
                num = num * 2 + head.val;
                head = head.next;
            }
            return num;
        }
    }
}
