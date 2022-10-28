using SpreadsheetEngine;
using System.Linq.Expressions;

namespace SpreadsheetEngineTests
{
    public class ExpressionTreeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]

        public void PostfixTests()
        {
            Dictionary<string, string> postfixData = new Dictionary<string, string>();
            postfixData.Add("3+5",  "3 5 + ");
            postfixData.Add("3 + 5", "3 5 + ");
            postfixData.Add("A1+5", "A1 5 + ");
            postfixData.Add("A1 + 5", "A1 5 + ");
            postfixData.Add("A1+5+3", "A1 5 + 3 + ");
            postfixData.Add("A1 + 5 + 3", "A1 5 + 3 + ");
            postfixData.Add("a1*(b2+5)", "a1 b2 5 + * ");
            postfixData.Add("a1 * (b2 + 5)", "a1 b2 5 + * ");
            postfixData.Add("5+6-3+2 ", "5 6 + 3 - 2 + ");
            postfixData.Add("5 + 6 - 3 + 2 ", "5 6 + 3 - 2 + ");
            postfixData.Add("5*((a1/3)+2)", "5 a1 3 / 2 + * ");
            postfixData.Add("5 * ((a1 / 3) + 2)", "5 a1 3 / 2 + * ");


            foreach (KeyValuePair<string, string> entry in postfixData)
            {
                ExpressionTree testExpression = new ExpressionTree(entry.Key);
                CollectionAssert.AreEqual(expected: testExpression.PostfixOrder(entry.Key), actual: entry.Value);

            }
        }

        [Test]

        [TestCase("3+5", ExpectedResult=8)]
        [TestCase("0+5", ExpectedResult = 5)]
        [TestCase("5+0", ExpectedResult = 5)]
        [TestCase("13+5", ExpectedResult = 18)]
        [TestCase("3+15", ExpectedResult = 18)]
        [TestCase("0+0", ExpectedResult = 0)]
        [TestCase("3+5+2", ExpectedResult = 10)]
  
        public double AdditionTests(string expression)
        {
            ExpressionTree testExpression = new SpreadsheetEngine.ExpressionTree(expression);

            return testExpression.Evaluate();
        }

        [Test]

        [TestCase("5-3", ExpectedResult = 2)]
        [TestCase("5-0", ExpectedResult = 5)]
        [TestCase("0-5", ExpectedResult = -5)]
        [TestCase("13-5", ExpectedResult = 8)]
        [TestCase("3-15", ExpectedResult = -12)]
        [TestCase("0-0", ExpectedResult = 0)]
        [TestCase("5-3-2", ExpectedResult = 0)]
        [TestCase("5-3-1", ExpectedResult = 1)]


        public double SubtractionTests(string expression)
        {
            ExpressionTree testExpression = new SpreadsheetEngine.ExpressionTree(expression);

            return testExpression.Evaluate();
        }

        [Test]

        [TestCase("5*3", ExpectedResult = 15)]
        [TestCase("5*1", ExpectedResult = 5)]
        [TestCase("0*5", ExpectedResult = 0)]
        [TestCase("10*5", ExpectedResult = 50)]
        [TestCase("5*10", ExpectedResult = 50)]
        [TestCase("0*0", ExpectedResult = 0)]
        [TestCase("5*3*2", ExpectedResult = 30)]

        public double MultiplicationTests(string expression)
        {
            ExpressionTree testExpression = new SpreadsheetEngine.ExpressionTree(expression);

            return testExpression.Evaluate();
        }

        [Test]

        [TestCase("4/2", ExpectedResult = 2)]
        [TestCase("10/2", ExpectedResult = 5)]
        [TestCase("5/2", ExpectedResult = 2.5)]
        [TestCase("0/5", ExpectedResult = 0)]


        public double DivisionTests(string expression)
        {
            ExpressionTree testExpression = new SpreadsheetEngine.ExpressionTree(expression);

            return testExpression.Evaluate();
        }

        [Test]

        [TestCase("5*3+2", ExpectedResult = 17)]
        [TestCase("4/(2*1) + 3", ExpectedResult = 5)]
        [TestCase("5 - 0 + 1", ExpectedResult = 6)]
        [TestCase("15 + (2*6)", ExpectedResult = 27)]
        [TestCase("(1 + 2 + 3) * 0", ExpectedResult = 0)]
        [TestCase("(4 * (2 + 2))", ExpectedResult = 16)]


        public double MixedOperatorTests(string expression)
        {
            ExpressionTree testExpression = new SpreadsheetEngine.ExpressionTree(expression);

            return testExpression.Evaluate();
        }

        [Test]
        public void DivideByZeroTest()
        {
            ExpressionTree testExpression = new SpreadsheetEngine.ExpressionTree("5 / 0");

            Assert.That(testExpression.Evaluate(), Is.EqualTo(double.PositiveInfinity));
        }

        [Test]
        public void SingleOperandTest()
        {
            SpreadsheetEngine.ExpressionTree testExpression = new SpreadsheetEngine.ExpressionTree("0");

            Assert.That(testExpression.Evaluate(), Is.EqualTo(0));
        }

        [Test]
        public void ExpressionWithVariablesTest()
        {
            SpreadsheetEngine.ExpressionTree testExpression = new SpreadsheetEngine.ExpressionTree("A1 + B2 - C3 * 1");
            testExpression.variables["A1"] = 5;
            testExpression.variables["B2"] = 7;
            testExpression.variables["C3"] = 2;

            Assert.That(testExpression.Evaluate(), Is.EqualTo(10));
        }
    }
}