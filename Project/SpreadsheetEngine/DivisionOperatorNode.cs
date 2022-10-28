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
        /// <summary>
        /// Initializes a new instance of the <see cref="DivisionOperatorNode"/> class.
        /// </summary>
        public DivisionOperatorNode()
            : base('/')
        {
        }

        // Operator, precedence, associativity are all included.


        /// <summary>
        /// Evaluates by dividing left and right subtrees.
        /// </summary>
        /// <returns> Evaluated value. </returns>
        public override double Evaluate()
        {
            return this.Right.Evaluate() / this.Left.Evaluate();
        }
    }
}
