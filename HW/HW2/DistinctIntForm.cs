// <copyright file="DistinctIntForm.cs" company="Aidan Griffin">
// Copyright (c) Washington State University. All rights reserved.
// </copyright>

namespace HW2NS
{
    /// <summary>
    /// The class which describes the actions of the winform Form.
    /// Includes methods to set up window and solve Q1, Q2, Q3.
    /// </summary>
    public partial class DistinctIntForm : Form
    {
        /// <summary>
        /// Number of Distinct Integers counted using the hash set approach.
        /// </summary>
        private int hashCount = 0;

        /// <summary>
        /// Number of Distinct Integers counted using the O(1) storage approach.
        /// </summary>
        private int storageCount = 0;

        /// <summary>
        /// Number of Distinct Integers counted using the sorting approach.
        /// </summary>
        private int sortedCount = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistinctIntForm"/> class.
        /// Generates a random list and passes it into distinct int solver method.
        /// </summary>
        public DistinctIntForm()
        {
            this.InitializeComponent(); // Load built in WinForms features

            var passedList = new List<int>();
            passedList = this.GenerateRandomList();
            this.RunDistinctIntegers(passedList);
        }

        /// <summary>
        ///  A method that generates a 10,000 member list of random integers between 1-20,000.
        /// </summary>
        /// <returns> Returns list of random integers. </returns>
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
        /// <param name="randList"> A list of 10,000 random integers spanning from 0 - 20,000. </param>
        public void RunDistinctIntegers(List<int> randList)
        {
            // Throw exception if list passed in is null.
            if (randList is null)
            {
                throw new ArgumentNullException(nameof(randList));
            }

            this.hashCount = 0;
            this.storageCount = 0;
            this.sortedCount = 0;

            // Hash set approach hashes each random integer from randList, since only one spot can be taken up by each value, repeating integers are disregarded.
            // Calculating hash key and hashing takes O(1) for each entry. As it's in a for-loop with a known number n loops, the hashset approach takes O(n).
            HashSet<int> randHash = new HashSet<int>();
            for (int i = 0; i < randList.Count; i++)
            {
                randHash.Add(randList[i]);
            }

            // The size of the hash will be returned.
            this.hashCount = randHash.Count;

            // O(1) storage approach. Achieves this by declaring no additional lists/hashes/etc.
            // Uses a nested loop, and only adds to the list when matching elements have the same index.
            // If the element has occured in the list already, the loop will break at the lower index, and the integer will not be counted as unique.
            for (int index = 0; index < randList.Count; index++)
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
                    this.storageCount++;
                }
            }

            // Sorted approach. Similar numbers will follow one another.
            // When a number is found, it will be stored until a new number is found, ensuring that only distinct integers are counted.
            List<int> sortedList = randList;
            sortedList.Sort();

            int j = -1;

            for (int i = 0; i < sortedList.Count; i++)
            {
                if (sortedList[i] != j)
                {
                    this.sortedCount++;
                    j = sortedList[i];
                }
            }

            // Show results to user through the window.
            this.textBox1.AppendText("HashSet Method: " + this.hashCount);
            this.textBox1.AppendText(Environment.NewLine);
            this.textBox1.AppendText("Time Complexity: O(n). Calculating hash key and hashing takes O(1) for each entry. As it's in a for-loop with a known number n loops, the hashset approach takes O(n) time complexity.");
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