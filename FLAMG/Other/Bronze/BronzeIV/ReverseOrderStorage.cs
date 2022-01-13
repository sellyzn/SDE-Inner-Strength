using FLAMG.Other.Bronze.BronzeIV;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Bronze.BronzeIV
{
    public class ReverseOrderStorage
    {
        public List<int> ReverseStore(ListNode head)
        {
            ListNode cur = head;
            var res = new List<int>();
            while (cur != null)
            {
                res.Insert(0, cur.val);
                cur = cur.next;
            }
            return res;
        }
    }
}
