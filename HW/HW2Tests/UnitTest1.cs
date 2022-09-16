using HW2NS;

namespace HW2Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test which passes the distinct integer function a list of zeros. 
        /// Since all elements passed will be 0, there should only be 1 distinct integer.
        /// </summary>
        [Test]
        public void TestDistinctIntegersMethodWithListOfZeroes()
        {
            var testList = new List<int>();

            for (int i = 0; i < 10000; i++)
            {
                testList.Add(0);
            }

            Form1 testForm = new Form1();

            testForm.RunDistinctIntegers(testList);
            int hashCount = testForm.GetHashCount();
            Assert.That(hashCount, Is.EqualTo(1));
        }

        /// <summary>
        /// Test which passes a list of sorted, non-repeating integers from 0-10000 into the 10000 member list.
        /// Since all elements passed are distinct, there should be 10000 disitinct integers.
        /// </summary>
        [Test]
        public void TestDistinctIntegersMethodWithListOfInorderIntegers()
        {
            var testList = new List<int>();

            for (int i = 0; i < 10000; i++)
            {
                testList.Add(i);
            }

            Form1 testForm = new Form1();

            testForm.RunDistinctIntegers(testList);
            int hashCount = testForm.GetHashCount();
            Assert.That(hashCount, Is.EqualTo(10000));
        }
    }
}