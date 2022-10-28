/*
 * Aidan Griffin
 * 11680523
 */

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
            return this.Right.Evaluate() / this.Left.Evaluate();
        }
    }
}
