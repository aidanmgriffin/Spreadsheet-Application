using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    internal class VariableNode : ExpressionTreeNode
    {
        public double value { get; set; }
        public string name { get; set; }

        public double evaluate()
        {
            return 0;
        }
    }
}
