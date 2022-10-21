using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Implementation for the expression tree.
    /// </summary>
    public class ExpressionTree
    {
        private ExpressionTreeNode root;

        private Dictionary<string, double> variables = new Dictionary<string, double>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// Constructor creates the tree from the specific expression.
        /// </summary>
        /// <param name="expression"> Expression given by user. </param>
        public ExpressionTree(string expression)
        {
            this.root = Compile(expression);
        }

        private static ExpressionTreeNode Compile(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }

            // define the operators we want to look for in that order
            char[] operators = { '+', '-', '*', '/' };
            foreach (char op in operators)
            {
                ExpressionTreeNode n = Compile(s, op);
                if (n != null)
                {
                    return n;
                }
            }

            // what can we see here?  
            double number;
            // a constant
            if (double.TryParse(s, out number))
            {
                // We need a ConstantNode
                return new ConstantNode(number);
            }
            // or variable
            else
            {
                // We need a VariableNode
                return new VariableNode(s, number);
            }
        }

        Dictionary<char, Type> symbols = new Dictionary<char, Type>() { { '+', typeof(AdditionOperatorNode) } };

        /// <summary>
        /// Compile tree of nodes. No need to worry about paranthesis.
        /// </summary>
        /// <param name="expression">Passed expression. </param>
        /// <param name="op">Given operator. </param>
        /// <returns>Base node type. </returns>
        private static ExpressionTreeNode Compile(string expression, char op)
        {
            // iterate from back to front
            for (int expressionIndex = expression.Length - 1; expressionIndex >= 0; expressionIndex--)
            {
                // if the counter is at 0 and we have the operator that we are looking for
                if (op == expression[expressionIndex])
                {
                    // build an operator node
                    ExpressionTreeNode tempNode;

                    // OperatorNode operatorNode = new OperatorNode(expression[expressionIndex]);
                    switch (expression[expressionIndex])
                    {
                        case '+':
                            object addNodeObject = Activator.CreateInstance(typeof(AdditionOperatorNode));
                            tempNode = (OperatorNode)addNodeObject;
                            ((OperatorNode)tempNode).Left = Compile(expression.Substring(0, expressionIndex));
                            ((OperatorNode)tempNode).Right = Compile(expression.Substring(expressionIndex + 1));
                            return ((OperatorNode)tempNode);
                            break;
                        case '-':
                            object subNodeObject = Activator.CreateInstance(typeof(SubtractionOperatorNode));
                            tempNode = (OperatorNode)subNodeObject;
                            ((OperatorNode)tempNode).Left = Compile(expression.Substring(0, expressionIndex));
                            ((OperatorNode)tempNode).Right = Compile(expression.Substring(expressionIndex + 1));
                            return ((OperatorNode)tempNode);
                            break;
                        case '*':
                            object mulNodeObject = Activator.CreateInstance(typeof(MultiplicationOperatorNode));
                            tempNode = (OperatorNode)mulNodeObject;
                            ((OperatorNode)tempNode).Left = Compile(expression.Substring(0, expressionIndex));
                            ((OperatorNode)tempNode).Right = Compile(expression.Substring(expressionIndex + 1));
                            return ((OperatorNode)tempNode);
                            break;
                        case '/':
                            object divNodeObject = Activator.CreateInstance(typeof(DivisionOperatorNode));
                            tempNode = (OperatorNode)divNodeObject;
                            ((OperatorNode)tempNode).Left = Compile(expression.Substring(0, expressionIndex));
                            ((OperatorNode)tempNode).Right = Compile(expression.Substring(expressionIndex + 1));
                            return ((OperatorNode)tempNode);
                            break;

                    }

                    /// and start over with the left and right sub-expressions
                    /// tempNode.Left = Compile(expression.Substring(0, expressionIndex));
                    /// tempNode.Right = Compile(expression.Substring(expressionIndex + 1));
                    /// return tempNode;
                }
            }

            // we did not find the operator
            return null;
        }

        /// <summary>
        /// Set a variable in the dictionary.
        /// </summary>
        /// <param name="variableName"> Name of variable. </param>
        /// <param name="variableValue">Value of variable. </param>
        public void SetVariable(string variableName, double variableValue)
        {
            this.variables[variableName] = variableValue;
        }

        public double GetVariable(string variableName)
        {
            return this.variables[variableName];
        }

        /// <summary>
        /// Evaluate expression to a double value.
        /// </summary>
        /// <returns>The resulting value from the given expression. </returns>
        public double Evaluate()
        {
            return Evaluate(root);
            //return this.root.Evaluate();
        }

        private double Evaluate(ExpressionTreeNode node)
        {
            // try to evaluate the node as a constant
            // the "as" operator is evaluated to null 
            // as opposed to throwing an exception
            ConstantNode constantNode = node as ConstantNode;
            if (null != constantNode)
            {
                return constantNode.Value;
            }

            // as a variable
            VariableNode variableNode = node as VariableNode;
            if (null != variableNode)
            {
                return variables[variableNode.Name];
            }

            // it is an operator node if we came here
            OperatorNode operatorNode = node as OperatorNode;
            if (null != operatorNode)
            {
                
                // but which one?
                switch (operatorNode.operatorVal)
                {
                    case '+':
                        return Evaluate(operatorNode.Left) + Evaluate(operatorNode.Right);
                    case '-':
                        return Evaluate(operatorNode.Left) - Evaluate(operatorNode.Right);
                    case '*':
                        return Evaluate(operatorNode.Left) * Evaluate(operatorNode.Right);
                    case '/':
                        return Evaluate(operatorNode.Left) / Evaluate(operatorNode.Right);
                    //case '^':
                    //    return Math.Pow(Evaluate(operatorNode.Left), Evaluate(operatorNode.Right));
                    default: // if it is not any of the operators that we support, throw an exception:
                        throw new NotSupportedException(
                            "Operator " + operatorNode.operatorVal.ToString() + " not supported.");
                }
            }

            throw new NotSupportedException();
        }
    }
}
