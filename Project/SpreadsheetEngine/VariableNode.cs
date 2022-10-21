using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    internal class VariableNode : ExpressionTreeNode
    {
        public VariableNode(string name, double value)
        {
            Name = name;
            Value = value;
        }

        public double Value { get; set; }
        public string Name { get; set; }

       

        public override double Evaluate()
        {
            return Value;
        }
    }
}
