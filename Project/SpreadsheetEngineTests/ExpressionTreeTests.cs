namespace SpreadsheetEngineTests
{
    public class ExpressionTreeTests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void AdditionTest()
        {
            string testInput = "3 + 5";

            SpreadsheetEngine.ExpressionTree testExpression0 = new SpreadsheetEngine.ExpressionTree(testInput);

            Assert.That(testExpression0.Evaluate(), Is.EqualTo(8));

        }

        [Test]
        public void SubtractionTest()
        {
            string testInput = "5-3";

            SpreadsheetEngine.ExpressionTree testExpression0 = new SpreadsheetEngine.ExpressionTree(testInput);

            Assert.That(testExpression0.Evaluate(), Is.EqualTo(2));

        }
        [Test]
        public void MultiplicationTest()
        {
            string testInput = "3*5";

            SpreadsheetEngine.ExpressionTree testExpression0 = new SpreadsheetEngine.ExpressionTree(testInput);

            Assert.That(testExpression0.Evaluate(), Is.EqualTo(15));

        }

        [Test]
        public void DivisionTest()
        {
            string testInput = "4/2";

            SpreadsheetEngine.ExpressionTree testExpression0 = new SpreadsheetEngine.ExpressionTree(testInput);

            Assert.That(testExpression0.Evaluate(), Is.EqualTo(2));

        }

        [Test]
        public void StandaloneTest()
        {
            string testInput = "0";

            SpreadsheetEngine.ExpressionTree testExpression0 = new SpreadsheetEngine.ExpressionTree(testInput);

            Assert.That(testExpression0.Evaluate(), Is.EqualTo(0));

        }



    }
}