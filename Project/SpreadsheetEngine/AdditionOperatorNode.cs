/*
 * Aidan Griffin
 * 11680523
 */

namespace SpreadsheetEngine
{
    /// <summary>
    /// Handles addition case.
    /// </summary>
    internal class AdditionOperatorNode : OperatorNode
    {
        public AdditionOperatorNode() : base('+')
        {
        }

        // Operator, precedence, associativity are all included.
        public override double Evaluate()
        {
            return this.Right.Evaluate() + this.Left.Evaluate();
        }
    }
}
