namespace HW2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RunDistinctIntegers();
        }

        private static void RunDistinctIntegers()
        {
            var rand = new Random();
            var list = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                int num = rand.Next(20000);
                list.Add(num);
            }
        }

        

    }
}