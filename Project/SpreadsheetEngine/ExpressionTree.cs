using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    public class ExpressionTree
    {
        private ExpressionTreeNode root;

        private Dictionary<string, double> variables = new Dictionary<string, double>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// Constructor creates the tree from the specific expression.
        /// </summary>
        /// <param name="expression"></param>
        public ExpressionTree(string expression) 
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="variableValue"></param>
        public void SetVariable(string variableName, double variableValue)
        {

        }

        /// <summary>
        /// Evaluate expression to a double value.
        /// </summary>
        /// <returns>The resulting value from the given expression. </returns>
        public double Evaluate()
        {
            return 0;
        }
    }
}
