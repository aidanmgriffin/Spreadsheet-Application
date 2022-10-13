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
        Cell[,] spreadsheetArray = new Cell[columnCount, rowCount];

        public Spreadsheet(int numColumns, int numRows)
        {
            columnCount = numColumns;
            rowCount = numRows;

            for (int i = 0; i < numColumns; i++)
            {
                for (int j = 0; j < numRows; j++)
                {
                    CellChild newChild = new CellChild(i, j);

                    spreadsheetArray[i, j] = newChild;
                    newChild.PropertyChanged += CellPropertyChanged;

                }
            }

            Console.WriteLine(spreadsheetArray[5, 5].columnIndex + spreadsheetArray[5, 5].rowIndex);
        }

        static int columnCount = 0;
        static int rowCount = 0;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        
        
        public void CellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("pc");
        }

        
        Cell GetCell(int columnIndex, int rowIndex)
        {
            if (this.spreadsheetArray[columnIndex, rowIndex] == null)
            {
                return null;
            }
            else 
            {
                return this.spreadsheetArray[columnIndex, rowIndex]; 
            }
        }



    }
}
