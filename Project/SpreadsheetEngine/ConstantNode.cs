using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    internal class ConstantNode : ExpressionTreeNode
    {
        public double value { get; set; }

        public double evaluate()
        {
            return 0;
        }
    }
}
