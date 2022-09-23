
namespace Interface
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FibonacciTextReaderWithZeroInput()
        {
            FibonacciTextReader testFibonacci = new FibonacciTextReader(0);

            string fibonacciTestString = testFibonacci.ReadToEnd();

            Assert.That(fibonacciTestString, Is.EqualTo("\r\n"));

        }

        [Test]
        public void FibonacciTextReaderWithOneInput()
        {
            FibonacciTextReader testFibonacci = new FibonacciTextReader(1);

            string fibonacciTestString = testFibonacci.ReadToEnd();

            Assert.That(fibonacciTestString, Is.EqualTo("1: 0\r\n\r\n"));

        }
    }
}