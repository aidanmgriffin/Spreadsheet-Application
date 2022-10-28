/*
 * Aidan Griffin
 * 11680523
 */

namespace SpreadsheetEngine
{
    internal class OperatorNodeFactory
    {

        public OperatorNode CreateOperatorNode(char op)
        {
            // build an operator node
            ExpressionTreeNode tempNode;

            // OperatorNode operatorNode = new OperatorNode(expression[expressionIndex]);
            switch (op)
            {
                case '+':
                    object addNodeObject = Activator.CreateInstance(typeof(AdditionOperatorNode));
                    tempNode = (OperatorNode)addNodeObject;
                    return ((OperatorNode)tempNode);
                    break;
                case '-':
                    object subNodeObject = Activator.CreateInstance(typeof(SubtractionOperatorNode));
                    tempNode = (OperatorNode)subNodeObject;
                    return ((OperatorNode)tempNode);
                    break;
                case '*':
                    object mulNodeObject = Activator.CreateInstance(typeof(MultiplicationOperatorNode));
                    tempNode = (OperatorNode)mulNodeObject;
                    return ((OperatorNode)tempNode);
                    break;
                case '/':
                    object divNodeObject = Activator.CreateInstance(typeof(DivisionOperatorNode));
                    tempNode = (OperatorNode)divNodeObject;
                    return ((OperatorNode)tempNode);
                    break;
            }

            // we did not find the operator
            return null;
        }
    }
}
