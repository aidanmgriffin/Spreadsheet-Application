using System.Net.Security;
using System.Runtime.CompilerServices;

namespace HW2NS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Load built in WinForms features

            var passedList = new List<int>();
            passedList = GenerateRandomList();
            RunDistinctIntegers(passedList);
        }

        public static List<int> GenerateRandomList()
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

        /* 
         * Function determines how many distinct integers are in a list of 10,000 random integers
         * It takes three seperate approaches and returns output information.
         */
        private void RunDistinctIntegers(List<int> randList)
        {
            HashSet<int> randHash = new HashSet<int>();
            for (int i = 0; i < randList.Count; i++)
            {
                randHash.Add(randList[i]);
            }

            this.textBox1.AppendText("HashSet Method: " + randHash.Count);
            this.textBox1.AppendText(Environment.NewLine);
            this.textBox1.AppendText("Time Complexity: O");
        }
    }
}