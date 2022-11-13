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
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplicationOperatorNode"/> class.
        /// </summary>
        public MultiplicationOperatorNode()
            : base('*')
        {
        }

        public int Precedence = 2;

        // Operator, precedence, associativity are all included next assignment.

        /// <summary>
        /// Evaluates by multiplying left and right subtrees.
        /// </summary>
        /// <returns> Evaluated value. </returns>
        public override double Evaluate()
        {
            return this.Right.Evaluate() * this.Left.Evaluate();
        }
    }
}
