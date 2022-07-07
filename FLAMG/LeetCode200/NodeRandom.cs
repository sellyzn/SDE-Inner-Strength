using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.LeetCode200
{
    internal class NodeRandom
    {
        public int val;
        public NodeRandom next;
        public NodeRandom random;
        public NodeRandom(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}
