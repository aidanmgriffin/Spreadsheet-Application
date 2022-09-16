using HW2NS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2Tests
{
    /// <summary>
    /// This class contains the tests concerning question three of the Distinct Integers method.
    /// </summary>
    public class Q3Tests
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
            int sortedCount = testForm.GetSortedCount();
            Assert.That(sortedCount, Is.EqualTo(1));
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
            int sortedCount = testForm.GetSortedCount();
            Assert.That(sortedCount, Is.EqualTo(10000));
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
            int sortedCount = testForm.GetSortedCount();
            Assert.That(sortedCount, Is.EqualTo(0));

        }
    }
}
