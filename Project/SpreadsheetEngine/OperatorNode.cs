namespace SpreadsheetEngine
{
    abstract class OperatorNode : ExpressionTreeNode
    {
        public OperatorNode(char c)
        {
            this.operatorVal = c;
            this.Left = null;
            this.Right = null;
        }
        public char operatorVal { get; set; }

        /// <summary>
        /// Left subtree.
        /// </summary>
        public ExpressionTreeNode Left { get; set; }

        /// <summary>
        /// Right subtree.
        /// </summary>
        public ExpressionTreeNode Right { get; set; }

        /// <summary>
        /// Passed along evaluate function.
        /// </summary>
        /// <returns>Double value. </returns>
        public abstract override double Evaluate();
    }
}
