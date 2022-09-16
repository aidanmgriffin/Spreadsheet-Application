using HW2NS;
using System;

namespace HW2Tests
{
    /// <summary>
    /// This class contains tests specific to question one, the hash set approach.
    /// </summary>
    public class Q1Tests
    {
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

        /// <summary>
        /// Test which passed an empty list to the TestDistinctIntegers Method.
        /// Method should return 0.
        /// </summary>
        [Test]
        public void TestDistinctIntegersMethodWithEmptyList()
        {
            var testList = new List<int>();

            Form1 testForm = new Form1();

            testForm.RunDistinctIntegers(testList);
            int hashCount = testForm.GetHashCount();
            Assert.That(hashCount, Is.EqualTo(0));
        }
    }

    /// <summary>
    /// This class contains tests specific to question one, the hash set approach.
    /// </summary>
}
