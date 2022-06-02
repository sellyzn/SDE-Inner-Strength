using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG
{
    public class NintendoAssignment
    {
        //public IList<string> File1NotInFile2(IList<string> file1, IList<string> file2)
        //{
        //    var file1NotInFile2 = new List<string>();

        //    if (file1 == null || file1.Count == 0)
        //        return null;

        //    var file2Set = new HashSet<string>();
        //    foreach (var item in file2)
        //    {
        //        file2Set.Add(item);
        //    }

        //    foreach (var item in file1)
        //    {
        //        if (!file2Set.Contains(item))
        //            file1NotInFile2.Add(item);
        //    }

        //    return file1NotInFile2;
        //}

        // 
        public IList<string> File1NotInFile2(Dictionary<string, string> file1, Dictionary<string, string> file2)
        {
            var file1NotInFile2 = new List<string>();

            if (file1 == null || file1.Count == 0)
                return null;
                        
            foreach (var file1Item in file1)
            {
                if (!file2.ContainsKey(file1Item.Key))
                    file1NotInFile2.Add(file1Item.Value);
            }

            return file1NotInFile2;
        }
                
        // Split each line in the file into sha1 and the file name, and store as the Dictionary<string, string> format
        public Dictionary<string, string> fileFormat(string[] file)
        {
            var res = new Dictionary<string, string>();
            var sha1Length = 40;
            foreach (var line in file)
            {
                var sha1 = line.Substring(0, sha1Length);
                var fileName = line.Substring(sha1Length + 1);
                res.Add(sha1, fileName);
            }
            return res;
        }
        

}
}
