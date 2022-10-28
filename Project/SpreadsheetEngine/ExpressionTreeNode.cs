namespace SpreadsheetEngine
{
    /// <summary>
    /// Base abstract tree node.
    /// </summary>
    public abstract class ExpressionTreeNode
    {
        /// <summary>
        /// Evalueate(): abstract per class notes.
        /// </summary>
        /// <returns> Double. </returns>
        public abstract double Evaluate();
    }
}
