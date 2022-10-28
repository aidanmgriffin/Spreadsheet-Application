/*
 * Aidan Griffin
 * 11680523
 */

using System.Transactions;

namespace SpreadsheetEngine
{
    internal class VariableNode : ExpressionTreeNode
    {
        public VariableNode(string name, Dictionary<string, double> vars)
        {
            this.Name = name;
            this.Vars = vars;
        }

        public double Value { get; set; }
        public string Name { get; set; }

        Dictionary<string, double> Vars;

        public override double Evaluate()
        {
            try
            {
                return this.Vars[this.Name];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Variable not set. Defaulting to 0.");
                return 0;
            }
        }
    }
}
