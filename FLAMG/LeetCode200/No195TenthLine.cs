using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No195TenthLine
    {
        //Bash
        //方法一，使用 sed 命令 + Linux 管道，先将前九行删除(1,9d），处理结果传到下一个管道，删除从第二行到最后一行，只保留第一行 （2,$d）
        //sed '1,9d' file.txt | sed '2,$d'

        //方法二，sed 命令支持安静模式 -n，使用安静模式会将被 sed 处理的那一行展示出来，结合 10p 打印第十行，就可以将第十行挑出来。
        //sed -n '10p' file.txt


    }
}
