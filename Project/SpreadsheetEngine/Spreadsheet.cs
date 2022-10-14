/*
 * Aidan Griffin
 * 11680523
 */

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the various methods required to create a spreadsheet.
    /// </summary>
    public class Spreadsheet
    {
        /// <summary>
        /// Number of columns in spreadsheet.
        /// </summary>
        private static int columnCount = 0;

        /// <summary>
        /// Number of rows in spreadsheet.
        /// </summary>
        private static int rowCount = 0;

        /// <summary>
        /// Declare 2d array.
        /// </summary>
        private CellChild[,] spreadsheetArray;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// Pass number of columns into row and instantiate spreadsheet 2d array.
        /// </summary>
        /// <param name="numColumns">Passed number of columns in the spreadsheet. </param>
        /// <param name="numRows">Passed number of rows in the spreadsheet. </param>
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
                    newChild.PropertyChanged += new PropertyChangedEventHandler(this.CellChangedEvent);
                    this.spreadsheetArray[i, j] = newChild;
                }
            }
        }

        /// <summary>
        /// Declare event handler.
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged;

        /// <summary>
        /// Result of changes in cells. Sets cell value based on text in cell. Additionally, sends result to Form.
        /// </summary>
        /// <param name="sender"> Sender oject. </param>
        /// <param name="e"> PropertyChangedEventArgs. </param>
        public void CellChangedEvent(object sender, PropertyChangedEventArgs e)
        {
            Cell temp = sender as Cell;

            if (e.PropertyName != null)
            {
                if (temp.CellText[0] == '=')
                {
                    temp.CellValue = temp.CellText.Substring(1);
                }
                else
                {
                    temp.CellValue = temp.CellText;
                }

                this.CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("Value"));
            }
        }

        /// <summary>
        /// Fetches and returns cell at given [i,j] index in a spreadsheet object.
        /// </summary>
        /// <param name="columnIndex"> Current index in column. </param>
        /// <param name="rowIndex"> Current index in row. </param>
        /// <returns>Returns object of base cell class. </returns>
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
