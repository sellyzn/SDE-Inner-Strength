using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class No71SimplifyPath
    {
        /// <summary>
        /// .为当前路径   /a/./b/./c/  -> /a/b/c
        /// ..为返回上一路径， /a/b/../../c/  -> /c
        /// ...作为文件名处理， /a/.../b   -> /a/.../b
        /// //作为一个/来处理， /a//b/c  -> /a/b/c
        /// 
        /// Stack
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// T: O(N)
        /// S: O(N)
        public string SimplifyPath(string path)
        {
            // split to array /
            var strArr = path.Split('/');
            var stack = new Stack<string>();
            foreach(var str in strArr)
            {
                if (str == null || str.Length == 0 || str == "." || (str == ".." && stack.Count == 0))                
                    continue;
                else if (str == ".." && stack.Count > 0)                
                    stack.Pop(); 
                else                                   
                    stack.Push(str);                
            }
            var sb = new StringBuilder();
            foreach(var str in stack)
            {
                sb.Insert(0, str);
                sb.Insert(0, "/");
            }
            if (sb.Length == 0)
                return "/";
            return sb.ToString();            
        }
    }
}
