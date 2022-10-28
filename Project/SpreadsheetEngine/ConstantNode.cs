/*
 * Aidan Griffin
 * 11680523
 */

namespace SpreadsheetEngine
{
    internal class ConstantNode : ExpressionTreeNode
    {
        public ConstantNode(double value)
        {
            Value = value;
        }

        public double Value { get; set; }

        public override double Evaluate()
        {
            return Value;
        }
    }
}
