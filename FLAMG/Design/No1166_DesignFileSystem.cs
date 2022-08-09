using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Design
{
    internal class No1166_DesignFileSystem
    {
    }
    public class FileSystem
    {
        /// <summary>
        /// T: O(M), M是path的长度，需要O(M)的时间找到path的最后一个"/"。， HashMap时间复杂度为O(1)
        /// S: O(K)， K代表paths的数量
        /// </summary>
        Dictionary<string, int> paths;
        public FileSystem()
        {
            this.paths = new Dictionary<string, int>();
        }
        
        public bool CreatePath(string path, int value)
        {
            if(path == null || (path.Length == 1 && path.Equals("/")) || paths.ContainsKey(path))
                return false;
            int delimIndex = path.LastIndexOf("/");
            var parent = path.Substring(0, delimIndex);

            if(parent.Length > 0 && !paths.ContainsKey(parent))
                return false;

            this.paths.Add(path, value);
            return true;
        }

        public int Get(string path)
        {
            if (paths.ContainsKey(path))
                return paths[path];
            else
                return -1;
        }
    }

    /**
     * Your FileSystem object will be instantiated and called as such:
     * FileSystem obj = new FileSystem();
     * bool param_1 = obj.CreatePath(path,value);
     * int param_2 = obj.Get(path);
     */
}
