/*
 * Aidan Griffin
 * 11680523
 */

using System.Reflection;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Instance of the ExpressionTreeNode class.
    /// </summary>
    abstract class OperatorNode : ExpressionTreeNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// </summary>
        /// <param name="c">Operator from expression. </param>
        public OperatorNode(char c)
        {
            this.Operator = c;
            this.Left = null;
            this.Right = null;
        }

        /// <summary>
        /// Gets or sets character value.
        /// </summary>
        public char Operator { get; set; }

        /// <summary>
        /// Gets precedence value.
        /// </summary>
        public int Precedence { get; }

        /// <summary>
        /// Gets or sets left subtree.
        /// </summary>
        public ExpressionTreeNode Left { get; set; }

        /// <summary>
        /// Gets or sets Right subtree.
        /// </summary>
        public ExpressionTreeNode Right { get; set; }

        /// <summary>
        /// Passed along evaluate function.
        /// </summary>
        /// <returns>Double value. </returns>
        public abstract override double Evaluate();
    }
}
