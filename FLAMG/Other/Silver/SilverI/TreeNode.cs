﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverI
{
    public class TreeNode
    {
        public int val;
        public TreeNode left, right;
        public TreeNode(int val)
        {
            this.val = val;
            this.left = this.right = null;
        }
    }
}
