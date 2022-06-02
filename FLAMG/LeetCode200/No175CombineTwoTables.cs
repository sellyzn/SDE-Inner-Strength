using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No175CombineTwoTables
    {
        // from table1 left join table2 on ... :  LEFT JOIN关键字从左表table1返回所有的行，即使右表table2中没有匹配。如果右表中没有匹配，则结果为Null
        // 

        // MySQL
        //select FirstName, LastName, City, State
        //from Person left join Address
        //on Person.PersonId = Address.PersonId
        //;

        //select firstName, lastName, city, state
        //from Person left join Address
        //on Person.personId = Address.personId
    }
}
