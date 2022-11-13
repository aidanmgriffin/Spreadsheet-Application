/*
 * Aidan Griffin
 * 11680523
 */

namespace SpreadsheetEngine
{
    /// <summary>
    /// Handles subtraction cases.
    /// </summary>
    internal class SubtractionOperatorNode : OperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubtractionOperatorNode"/> class.
        /// </summary>
        public SubtractionOperatorNode()
            : base('-')
        {
        }

        public int Precedence = 1;

        // Operator, precedence, associativity are all included in class for the next assignment.
        // char operator = '-'
        // char precedence = 1;
        // enum associativity = left;

        /// <summary>
        /// Evaluate using subtraction.
        /// </summary>
        /// <returns>Evaluated double value. </returns>
        public override double Evaluate()
        {
            return this.Right.Evaluate() - this.Left.Evaluate();
        }
    }
}
