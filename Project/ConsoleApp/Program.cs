// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    internal class ConsoleApp
    {
        public static void Main(string[] args)
        {
            string currentExpression = "A1-12-C1";
            string input;

            ExpressionTree expressionTree = new ExpressionTree(currentExpression);

            while (true)
            {
                DisplayOptions(currentExpression);
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        currentExpression = Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Enter variable name: ");
                        string variableName = Console.ReadLine();
                        Console.WriteLine("Enter variable value: ");
                        Double variableValue = double.Parse(Console.ReadLine());
                        expressionTree.SetVariable(variableName, variableValue);
                        break;
                    case "3":
                        expressionTree.Evaluate();
                        break;
                    case "4":
                        Console.WriteLine("Done");
                        Environment.Exit(0);
                        break;
                    default:
                        break;

                }
            }
        }

        private static void DisplayOptions(string currentExpression)
        {
            Console.WriteLine("Menu (Current Expression = \"" + currentExpression + "\")");
            Console.WriteLine("1 = Enter a new expression");
            Console.WriteLine("2 = Set a variable value");
            Console.WriteLine("3 = Evaluate tree");
            Console.WriteLine("4 = Quit");
        }
    }
}