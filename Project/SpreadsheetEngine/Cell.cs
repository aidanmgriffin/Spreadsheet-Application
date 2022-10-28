/*
 * Aidan Griffin
 * 11680523
 */

namespace SpreadsheetEngine
{
    using System.ComponentModel;

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
        /// Gets the current index of the row.
        /// </summary>
        public int RowIndex { get; }

        /// <summary>
        /// Gets the current index of the column.
        /// </summary>
        public int ColumnIndex { get; }

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

            internal set
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