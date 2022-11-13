/*
 * Aidan Griffin
 * 11680523
 */

using System.Runtime.CompilerServices;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Handles addition case.
    /// </summary>
    internal class AdditionOperatorNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionOperatorNode"/> class.
        /// </summary>
        public AdditionOperatorNode()
            : base('+')
        {
        }

        public int Precedence = 1;

        // Operator, precedence, associativity are all included.

        /// <summary>
        /// Returns evaluation by adding together left and right subtrees.
        /// </summary>
        /// <returns> Added value. </returns>
        public override double Evaluate()
        {
            return this.Right.Evaluate() + this.Left.Evaluate();
        }
    }
}
