using System;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Threading;

namespace HW2NS
{
    public partial class Form1 : Form
    {
        private int hashCount = 0;
        private int storageCount = 0;
        private int sortedCount = 0;


        public Form1()
        {
            InitializeComponent(); // Load built in WinForms features

            var passedList = new List<int>();
            passedList = GenerateRandomList();
            RunDistinctIntegers(passedList);
        }

        /// <summary>
        ///  A method that generates a 10,000 member list of random integers between 1-20,000.
        /// </summary>
        /// <returns> Returns list of random integers </returns>
        public List<int> GenerateRandomList()
        {
            var rand = new Random();
            var randList = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                int num = rand.Next(20000);
                randList.Add(num);
            }

            return randList;
        }

        /// <summary>
        ///  Function determines how many distinct integers are in a list of 10,000 random integers
        ///  It takes three seperate approaches and returns output information.
        /// </summary>
        public void RunDistinctIntegers(List<int> randList)
        {
            HashSet<int> randHash = new HashSet<int>();
            for (int i = 0; i < randList.Count; i++)
            {
                randHash.Add(randList[i]);
            }

            this.hashCount = randHash.Count;

            for (int index = 1; index < randList.Count; index++)
            {
                int nestedIndex = 0;

                for (nestedIndex = 0; nestedIndex < index; nestedIndex++)
                {
                    if (randList[index] == randList[nestedIndex])
                    {
                        break;
                    }
                }

                if (index == nestedIndex)
                {
                    this.storageCount += 1;
                }
            }

            List<int> sortedList = randList;
            sortedList.Sort();

            int j = -1;

            for (int i = 0; i < sortedList.Count; i++)
            {
                if (i != j)
                {
                    this.sortedCount++;
                    j = i;
                }
            }

            this.textBox1.AppendText("HashSet Method: " + this.hashCount);
            this.textBox1.AppendText(Environment.NewLine);
            this.textBox1.AppendText("Time Complexity: O");
            this.textBox1.AppendText(Environment.NewLine);
            this.textBox1.AppendText("O(1) Storage Method: " + this.storageCount);
            this.textBox1.AppendText(Environment.NewLine);
            this.textBox1.AppendText("Sorted Method: " + this.sortedCount);

        }

        /// <summary>
        /// Getter returns count value from hashing problem.
        /// </summary>
        /// <returns> Number of distinct integers from hashing problem. </returns>
        public int GetHashCount()
        {
            return this.hashCount;
        }

        /// <summary>
        /// Getter returns count from O(1) storage problem.
        /// </summary>
        /// <returns> Number of distinct integers from storage problem. </returns>
        public int GetStorageCount()
        {
            return this.storageCount;
        }

        /// <summary>
        /// Getter returns count from sorted problem.
        /// </summary>
        /// <returns> Number of distinct images derived from sorted problem. </returns>
        public int GetSortedCount()
        {
            return this.sortedCount;
        }
    }
}