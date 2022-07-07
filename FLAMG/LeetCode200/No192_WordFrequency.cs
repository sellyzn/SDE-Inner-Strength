using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No192_WordFrequency
    {
        // Bash
        // cat words.txt | tr -s ' ' '\n' | sort | uniq -c | sort -r | awk '{ print $2, $1 }'

        // 切割
        // tr: 命令用于转换或删除文件中的字符
        // -s: 所见连续重复的字符成指定的单个字符
        // 排序单词
        // sort: 排序
        // 统计单词出现的次数
        // uniq: 命令用于检查及删除文本文件中重复出现的行列，一般与sort命令结合使用
        // -c: 在每列旁边显示该行重复出现的次数
        // 排序单词出现次数
        // -r: 以相反的顺序来排序
        // 打印
        // awk '{print}'
        // 

        
    }
}
