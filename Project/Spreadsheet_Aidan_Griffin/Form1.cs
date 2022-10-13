using SpreadsheetEngine;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Spreadsheet_Aidan_Griffin
{
    public partial class Form1 : Form
    {
        //Spreadsheet newSpreadsheet = new Spreadsheet(26,50);


        public Form1()
        {
            this.InitializeComponent();
            this.InitializeDataGrid();
            Spreadsheet newSpreadsheet = new Spreadsheet(26, 50);
            newSpreadsheet.PropertyChanged += SpreadsheetPropertyChanged;
        }
        
        

        /// <summary>
        /// This method programatically adds columns and rows to dataGridView.
        /// </summary>
        public void InitializeDataGrid()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            foreach (char c in alphabet)
            {
                string columnName = "columnName" + c;
                this.dataGridView1.Columns.Add(columnName, char.ToString(c));
            }

            for (int i = 0; i < 50; i++)
            {
                string rowName = "rowName" + i;
                this.dataGridView1.Rows.Add();
            }

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void SpreadsheetPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("cs");
        }

    }
}