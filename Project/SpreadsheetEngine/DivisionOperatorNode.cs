
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Handles division case.
    /// </summary>
    internal class DivisionOperatorNode : OperatorNode
    {
        public DivisionOperatorNode() : base('/')
        {
        }

        //Operator, precedence, associativity are all included.
        public override double Evaluate()
        {
            return this.Left.Evaluate() + this.Right.Evaluate();
        }
    }
}
