using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.TopologicalSorting
{
    public class DirectedGraghNode
    {
        public int label;
        public List<DirectedGraghNode> neighbors;
        public DirectedGraghNode(int x)
        {
            label = x;
            neighbors = new List<DirectedGraghNode>();
        }
    }
}
