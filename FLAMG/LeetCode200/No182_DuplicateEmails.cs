using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No182_DuplicateEmails
    {
        //SELECT DISTINCT: used to return only distinct(different) values.
        // HAVING clause was added to SQL because the WHERE keyword cannot be used with aggregate functions.
        //
        //SELECT Email
        //FROM Person
        //GROUP BY Email
        //HAVING COUNT(Email) > 1;

        //SELECT DISTINCT p1.Email
        //FROM Person p1, Person p2
        //WHERE p1.Id != p2.Id AND p1.Email = p2.Email;
    }
}
