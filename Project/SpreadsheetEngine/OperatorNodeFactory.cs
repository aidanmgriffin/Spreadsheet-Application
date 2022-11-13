/*
 * Aidan Griffin
 * 11680523
 */

using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SpreadsheetEngine
{
    class OperatorNodeFactory
    {
        private Dictionary<char, Type> operators = new Dictionary<char, Type>();

        public OperatorNodeFactory()
        {
            this.TraverseAvailableOperators((op, type) => this.operators.Add(op, type));
        }

        private delegate void OnOperator(char op, Type type);

        public OperatorNode CreateOperatorNode(char op)
        {
            if (this.operators.ContainsKey(op))
            {
                object operatorNodeObject = System.Activator.CreateInstance(this.operators[op]);
                if (operatorNodeObject is OperatorNode)
                {
                    return (OperatorNode)operatorNodeObject;
                }
            }
            throw new Exception("Unhandled Operator");
        }

            //// build an operator node
            //ExpressionTreeNode tempNode;

            //// OperatorNode operatorNode = new OperatorNode(expression[expressionIndex]);
            //switch (op)
            //{
            //    case '+':
            //        object addNodeObject = Activator.CreateInstance(typeof(AdditionOperatorNode));
            //        tempNode = (OperatorNode)addNodeObject;
            //        return ((OperatorNode)tempNode);
            //    case '-':
            //        object subNodeObject = Activator.CreateInstance(typeof(SubtractionOperatorNode));
            //        tempNode = (OperatorNode)subNodeObject;
            //        return ((OperatorNode)tempNode);
            //    case '*':
            //        object mulNodeObject = Activator.CreateInstance(typeof(MultiplicationOperatorNode));
            //        tempNode = (OperatorNode)mulNodeObject;
            //        return ((OperatorNode)tempNode);
            //    case '/':
            //        object divNodeObject = Activator.CreateInstance(typeof(DivisionOperatorNode));
            //        tempNode = (OperatorNode)divNodeObject;
            //        return ((OperatorNode)tempNode);
            //    default:
            //        return null;
            //}

            //// we did not find the operator
            //return null;

        private void TraverseAvailableOperators(OnOperator onOperator)
        {
            Type operatorNodeType = typeof(OperatorNode);

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                IEnumerable<Type> operatorTypes = assembly.GetTypes().Where(type => type.IsSubclassOf(operatorNodeType));

                foreach(var type in operatorTypes)
                {
                    PropertyInfo operatorField = type.GetProperty("Operator");
                    if(operatorField != null)
                    {
                        //object value = operatorField.GetValue(Activator.CreateInstance(type, new ConstantNode("0"), new ConstantNode("0")));
                        object instance = System.Activator.CreateInstance(type);
                        object value = operatorField.GetValue(instance);

                        if(value is char)
                        {
                            char operatorSymbol = (char)value;
                            onOperator(operatorSymbol, type);
                        }
                    }
                }

            }
        }
    }
}
