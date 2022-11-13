﻿/*
 * Aidan Griffin
 * 11680523
 */

using System.ComponentModel;
using System.Net;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Implementation for the expression tree.
    /// </summary>
    public class ExpressionTree
    {
        public static Dictionary<string, double> variables = new Dictionary<string, double>();

        /// <summary>
        /// Values indicate the order of precedence amongst operators.
        /// </summary>
        /// <returns> Dictionary entry containing operator and precedence. </returns>
        private readonly Dictionary<char, int> precedenceDictionary = new Dictionary<char, int>()
        {
            { '+', 1 },
            { '-', 1 },
            { '*', 2 },
            { '/', 2 },
            { '^', 3 },
            { '(', -1 },
        };

        private ExpressionTreeNode root;

        private string expression;


        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// Constructor creates the tree from the specific expression.
        /// </summary>
        /// <param name="expression"> Expression given by user. </param>
        public ExpressionTree(string expression)
        {
            this.expression = this.PostfixOrder(expression);
            this.root = this.Compile(this.expression);
        }

        /// <summary>
        /// Set a variable in the dictionary.
        /// </summary>
        /// <param name="variableName"> Name of variable. </param>
        /// <param name="variableValue">Value of variable. </param>
        public void SetVariable(string variableName, double variableValue)
        {
            //variables[variableName] = variableValue;
            //Console.WriteLine("Here" + variables[variableName]);

        }

        List<string> variableNames = new List<string>();

        public List<string> GetVariableNames()
        {
            return this.variableNames;
        }

        public event PropertyChangedEventHandler CellPropertyChanged;

        /// <summary>
        /// Compiles expression tree from postfix expression using a stack.
        /// </summary>
        /// <param name="expression"> Expression in postfix form.</param>
        /// <returns> Compiled tree. </returns>
        private ExpressionTreeNode Compile(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                return null;
            }

            OperatorNodeFactory nodeFactory = new OperatorNodeFactory();

            Stack<ExpressionTreeNode> treeStack = new Stack<ExpressionTreeNode>();

            // Read postfix expression one symbol at a time.
            for (int expressionIndex = 0; expressionIndex <= expression.Length - 1; expressionIndex++)
            {
                char val = expression[expressionIndex];

                // Account for whitespace in postfix expression. Whitespace exists to allow for multi-digit numbers and variables.
                if (char.IsWhiteSpace(val))
                {
                    continue;
                }

                // If char is an operand. Check if it's a multi-digit number or variable based on it's first digit.
                else if (char.IsDigit(val))
                {
                    double num = 0;

                    while (char.IsDigit(val))
                    {
                        num = (num * 10) + (val - 48);
                        expressionIndex++;
                        val = expression[expressionIndex];
                    }

                    expressionIndex--;

                    ConstantNode isConstantOperand = new ConstantNode(num);

                    treeStack.Push(isConstantOperand);
                }
                else if (char.IsLetter(val))
                {
                    string str = string.Empty;


                    char nextVal = expression[expressionIndex + 1 ];

                    if(char.IsDigit(nextVal))
                    { 
                        str += val;
                        str += nextVal;

                        int number = val - 65;
                        int nextAdj = nextVal;
                        nextAdj -= 49;
                        VariableNode isVariableOperand = new VariableNode(str, variables);

                        treeStack.Push(isVariableOperand);

                        expressionIndex++;
                    }
                }

                // Value is an operator. Pop two trees from stack. Create a new operator tree and push to stack.
                else
                {

                    ExpressionTreeNode rightSubtree = treeStack.Pop();
                    ExpressionTreeNode leftSubtree = treeStack.Pop();


                    ExpressionTreeNode isOperator = nodeFactory.CreateOperatorNode(val);

                    ((OperatorNode)isOperator).Right = leftSubtree;
                    ((OperatorNode)isOperator).Left = rightSubtree;

                    treeStack.Push(isOperator);
                }
            }

            return treeStack.Pop();
        }

        /// <summary>
        /// Transform the expression string into a postfix order using Djikstra's Shunting yard algorithm.
        /// </summary>
        /// <param name="expression">Infix expression. </param>
        public string PostfixOrder(string expression)
        {
            Stack<char> postfixStack = new Stack<char>();

            string postfixExpression = "";

            for (int expressionIndex = 0; expressionIndex <= expression.Length - 1; expressionIndex++)
            {
                char val = expression[expressionIndex];

                if (char.IsWhiteSpace(val))
                {
                    continue;
                }
                // If the incoming symbol is an operand, output it.
                else if (char.IsLetterOrDigit(val))
                {

                    string key = string.Empty;
                    bool isVar = false;

                    while (expressionIndex + 1 < expression.Length && char.IsLetterOrDigit(expression[expressionIndex + 1]))
                    {
                        postfixExpression += expression[expressionIndex];
                        key += expression[expressionIndex];
                        expressionIndex++;
                        isVar = true;
                    }

                    postfixExpression += expression[expressionIndex];
                    key += expression[expressionIndex];
                    if (isVar) { variableNames.Add(key); }

                    postfixExpression += ' ';
                }
                // If the incoming symbol is a left parenthesis, push it on the stack.
                else if (val == '(')
                {
                    postfixStack.Push(val);
                }
                // If the incoming symbol is a right parenthesis, discard the right parenthesis and pop elements off the stack until left parenthesis is reached. Then, pop the left parenthesis.
                else if (val == ')')
                {
                    while (postfixStack.Count > 0 && postfixStack.Peek() != '(')
                    {
                        char newpopval = postfixStack.Pop();
                        postfixExpression += newpopval;
                        postfixExpression += ' ';
                    }

                    postfixStack.Pop();
                }
                // If the incoming symbol is an operator; No need to declare an OperatorNodeFactory, because all other cases have been covered.
                else
                {
                    // If the operator has a greator precedence than the top of the stack, push to stack. If top of stack is left parenthisis, operator will be pushed to stack.
                    if (postfixStack.Count > 0 && this.precedenceDictionary[val] > this.precedenceDictionary[postfixStack.Peek()])
                    {
                        postfixStack.Push(val);
                    }
                    // If the operator has a lower than or equal precedence than the top of the stack, pop until this is no longer the case. Then, push the new operator. If stack is empty, operator will be pushed to stack.
                    else
                    {
                        while (postfixStack.Count > 0 && this.precedenceDictionary[val] <= this.precedenceDictionary[postfixStack.Peek()])
                        {
                            char newpopval = postfixStack.Pop();
                            postfixExpression += newpopval;
                            postfixExpression += ' ';
                        }

                        postfixStack.Push(val);
                    }

                }
            }

            // At the end of expression, all operators on stack are popped and outputted.
            while (postfixStack.Count > 0)
            {
                char newpopval = postfixStack.Pop();
                postfixExpression += newpopval;
                postfixExpression += ' ';
            }

            Console.WriteLine(postfixExpression);
            return postfixExpression;

        }

        public void CellEvent(object sender, PropertyChangedEventArgs e)
        {
            Cell temp = sender as Cell;

            if(e.PropertyName != null)
            {
                this.CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("Text"));
            }
        }

        /// <summary>
        /// Evaluate expression to a double value.
        /// </summary>
        /// <returns>The resulting value from the given expression. </returns>
        public double Evaluate()
        {
            return this.root.Evaluate();

        }
    }
}
