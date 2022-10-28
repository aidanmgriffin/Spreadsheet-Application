/*
 * Aidan Griffin
 * 11680523
 */

namespace SpreadsheetEngine
{
    /// <summary>
    /// Handles multiplication case.
    /// </summary>
    internal class MultiplicationOperatorNode : OperatorNode
    {
        public MultiplicationOperatorNode() : base('*')
        {
        }

        //Operator, precedence, associativity are all included.
        public override double Evaluate()
        {
            return this.Right.Evaluate() * Left.Evaluate();
        }
    }
}
