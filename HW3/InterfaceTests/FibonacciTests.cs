
namespace Interface
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Feed 0 into Fibonacci sequence. With zero values in the sequence, there should only be a newline returned.
        /// </summary>
        [Test]
        public void FibonacciTextReaderWithInputZero()
        {
            FibonacciTextReader testFibonacci = new FibonacciTextReader(0);

            string fibonacciTestString = testFibonacci.ReadToEnd();

            Assert.That(fibonacciTestString, Is.EqualTo("\r\n"));
        }

        /// <summary>
        /// Feed a 1 into Fibonacci sequence. There should only be one line of output, the first value in the fibonacci sequence(which is a special case): 0.
        /// </summary>
        [Test]
        public void FibonacciTextReaderWithInputOne()
        {
            FibonacciTextReader testFibonacci = new FibonacciTextReader(1);

            string fibonacciTestString = testFibonacci.ReadToEnd();

            Assert.That(fibonacciTestString, Is.EqualTo("1: 0\r\n\r\n"));
        }

        /// <summary>
        /// Feed a 2 into Fibonacci sequence. There should only be two lines of output, the special cases 0 and 1.
        /// </summary>
        [Test]
        public void FibonacciTextReaderWithInputTwo()
        {
            FibonacciTextReader testFibonacci = new FibonacciTextReader(2);

            string fibonacciTestString = testFibonacci.ReadToEnd();

            Assert.That(fibonacciTestString, Is.EqualTo("1: 0\r\n2: 1\r\n\r\n"));
        }
    }
}