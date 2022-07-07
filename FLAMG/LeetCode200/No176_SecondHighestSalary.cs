using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No176_SecondHighestSalary
    {
        // MySQL
        //SELECT
        //    IFNULL(
        //      (SELECT DISTINCT Salary
        //       FROM Employee
        //       ORDER BY Salary DESC
        //        LIMIT 1 OFFSET 1),
        //    NULL) AS SecondHighestSalary
    }
}
