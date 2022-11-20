/*
 * Aidan Griffin
 * 11680523
 */

namespace SpreadsheetEngine
{
    using System.ComponentModel;
    using System.Reflection.Metadata.Ecma335;

    /// <summary>
    /// Abstract cell class defines the methods and values which are contained inside a cell.
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// Contains the protected cell text so getting and setting can be altered. All lowercase to differentiate from property of same name.
        /// </summary>
        protected string celltext = string.Empty;

        /// <summary>
        ///  Contains the protected cell value so getting and setting can be altered. All lowercase to differentiate from property of same name.
        /// </summary>
        protected string cellvalue = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="columnIndex">Sets index of the cell's column. </param>
        /// <param name="rowIndex">Sets index of the cell's row. </param>
        public Cell(int columnIndex, int rowIndex)
        {
            this.RowIndex = rowIndex;
            this.ColumnIndex = columnIndex;
        }

        /// <summary>
        /// Handles cell change events.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Cell changed event can be subscribed to from spreadsheet.
        /// </summary>
        /// <param name="sender"> Sender. </param>
        /// <param name="e"> e. </param>
        public void CellChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
        }

        //change this to hexcode for white.

        // Default color is white: xFFFFFFFF;
        /// <summary>
        /// Gets the current index of the row.
        /// </summary>
        public int RowIndex { get; }

        /// <summary>
        /// Gets the current index of the column.
        /// </summary>
        public int ColumnIndex { get; }

        /// <summary>
        /// Base background color is white.
        /// </summary>
        public uint bgcolor= 4294967295;

        public uint BGColor
        {
            get
            {
                return bgcolor;
            }

            set
            {
                if (bgcolor != value)
                {
                    bgcolor = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs("BGColor"));
                }
            }
        }

        /// <summary>
        /// Gets or sets cell text with check for same text. Also allows subscription.
        /// </summary>
        public string CellText
        {
            get
            {
                return this.celltext;
            }

            set
            {
                if (value != this.celltext)
                {
                    this.celltext = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                }
            }
        }

        /// <summary>
        /// Gets cell value with check for same value. Also allows subscription.
        /// </summary>
        public string CellValue
        {
            get
            {
                return this.cellvalue;
            }

            set
            {
                if (value != this.cellvalue)
                {
                    this.cellvalue = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                }
            }
        }
    }
}