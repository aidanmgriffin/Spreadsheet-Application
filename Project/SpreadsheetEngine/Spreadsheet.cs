using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    public class Spreadsheet
    {
        static int columnCount = 0;
        static int rowCount = 0;
        CellChild[,] spreadsheetArray;

        public Spreadsheet(int numColumns, int numRows)
        {
            Console.WriteLine("in spreadsheet");
            columnCount = numColumns;
            rowCount = numRows;

            this.spreadsheetArray = new CellChild[columnCount, rowCount];

            for (int i = 0; i < numColumns; i++)
            {
                for (int j = 0; j < numRows; j++)
                {
                    CellChild newChild = new CellChild(i, j);
                    newChild.PropertyChanged += new PropertyChangedEventHandler(CellChangedEvent);
                    spreadsheetArray[i, j] = newChild;
                }
            }
        }

        public event PropertyChangedEventHandler CellPropertyChanged;

        public void CellChangedEvent(object sender, PropertyChangedEventArgs e)
        {
            Cell temp = sender as Cell;

            if (e.PropertyName != null)
            {
                if (temp.cellText[0] == '=')
                {
                    temp.cellValue = temp.cellText.Substring(1);
                }
                else
                {
                    temp.cellValue = temp.cellText;
                }

                CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("Value"));
            }
        }


        public Cell GetCell(int columnIndex, int rowIndex)
        {
            if (this.spreadsheetArray[columnIndex, rowIndex] != null)
            { 
                return this.spreadsheetArray[columnIndex, rowIndex];
            }
            else
            {
                return null;
            }
        }
    }
}
