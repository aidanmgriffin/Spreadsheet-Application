namespace SpreadsheetEngine
{
    /// <summary>
    /// Handles subtraction cases.
    /// </summary>
    internal class SubtractionOperatorNode : OperatorNode
    {
        public SubtractionOperatorNode() : base('-')
        {
        }

        // Operator, precedence, associativity are all included.
        public override double Evaluate()
        {
            return this.Right.Evaluate() - this.Left.Evaluate();
        }
    }
}
