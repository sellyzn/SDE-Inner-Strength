using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No193ValidPhoneNumbers
    {
        // -P: 使用Perl拓展正则
        // ^：要求匹配的字符串是在行首，开始位置
        // $：要求匹配的字符串在行尾，结束位置
        // \d： 匹配数字0-9，等价于[0-9]
        // {3}前面的匹配出现三次，就是匹配连续三个数字
        // ()以及中间的| 用来分组，括号内的是一组，这里嵌套了一次括号并用了| 或，为了实现的是(\(\d{3}\) )和(\d{3}-)的二选一
        // \(, \)， 括号转义
        //

        //grep -P '^([0-9]{3}-|\([0-9]{3}\) )[0-9]{3}-[0-9]{4}$' file.txt
    }
}
