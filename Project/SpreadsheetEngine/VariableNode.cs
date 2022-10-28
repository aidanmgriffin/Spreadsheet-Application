/*
 * Aidan Griffin
 * 11680523
 */

namespace SpreadsheetEngine
{
    /// <summary>
    /// Expression Tree Node to facilitate variables.
    /// </summary>
    internal class VariableNode : ExpressionTreeNode
    {

        private readonly Dictionary<string, double> vars;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="name"> Name of key value.</param>
        /// <param name="vars"> Reference to variables dictionary declaired in expressiontree.cs </param>
        public VariableNode(string name, Dictionary<string, double> vars)
        {
            this.Name = name;
            this.vars = vars;
        }

        /// <summary>
        /// Gets or sets name value.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Finds and returns a given node in referenced variables dictionary.
        /// </summary>
        /// <returns> Value at key in dictionary. </returns>
        public override double Evaluate()
        {
            try
            {
                return this.vars[this.Name];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Variable not set. Defaulting to 0.");
                return 0;
            }
        }
    }
}
