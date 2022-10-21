using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    internal class ConstantNode : ExpressionTreeNode
    {
        public ConstantNode(double value)
        {
            Value = value;
        }

        public double Value { get; set; }

        public override double Evaluate()
        {
            return Value;
        }
    }
}
