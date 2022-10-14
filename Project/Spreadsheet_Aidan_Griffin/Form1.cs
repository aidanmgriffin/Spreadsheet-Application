using SpreadsheetEngine;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Spreadsheet_Aidan_Griffin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();

            this.InitializeDataGrid();

            this.newSpreadsheet = new Spreadsheet(26, 50);
            this.newSpreadsheet.CellPropertyChanged += new PropertyChangedEventHandler(this.SpreadsheetPropertyChanged);
        }

        public Spreadsheet newSpreadsheet;

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

        /// <summary>
        /// This property updates the GridView cells when the spreadsheet cells are edited.
        /// </summary>
        /// <param name="sender"> Sender parameter. </param>
        /// <param name="e"> PropertyChangedEventArgs parameter. </param>
        private void SpreadsheetPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell temp = sender as Cell;

            this.dataGridView1.Rows[temp.rowIndex].Cells[temp.columnIndex].Value = temp.cellValue; 
        }

        /// <summary>
        /// On button click, the demo is initiated.
        /// </summary>
        /// <param name="sender"> Sender parameter. </param>
        /// <param name="e"> EventArgs parameter. </param>
        private void Button1Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                int random_column = rnd.Next(0, 26);
                int random_row = rnd.Next(0, 50);

                SpreadsheetEngine.Cell temp = this.newSpreadsheet.GetCell(random_column, random_row);
                temp.cellText = "Hello";
            }

            for (int i = 0; i < 50; i++)
            {
                SpreadsheetEngine.Cell temp = this.newSpreadsheet.GetCell(1, i);
                temp.cellText = "This is cell B" + (i + 1);
            }


            for (int i = 0; i < 50; i++)
            {
                SpreadsheetEngine.Cell temp = this.newSpreadsheet.GetCell(0, i);
                temp.cellText = "=B" + (i + 1);
            }
        }
    }
}