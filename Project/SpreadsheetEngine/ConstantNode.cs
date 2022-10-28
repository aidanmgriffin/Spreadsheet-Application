/*
 * Aidan Griffin
 * 11680523
 */

namespace SpreadsheetEngine
{
    /// <summary>
    /// Instance of ExpressionTreeNode.
    /// </summary>
    internal class ConstantNode : ExpressionTreeNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// </summary>
        /// <param name="value"> Character value from the expression. </param>
        public ConstantNode(double value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets operand value.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Constant evaluate function simply has to return value.
        /// </summary>
        /// <returns> Operand value. </returns>
        public override double Evaluate()
        {
            return this.Value;
        }
    }
}
