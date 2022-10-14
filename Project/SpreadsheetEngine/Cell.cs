namespace SpreadsheetEngine
{
    using System.ComponentModel;
    using System.Reflection.Metadata.Ecma335;

    public abstract class Cell : INotifyPropertyChanged
    {

        public Cell(int columnIndex, int rowIndex)
        {
            this.RowIndex = rowIndex;
            this.ColumnIndex = columnIndex;
        }

        public event PropertyChangedEventHandler PropertyChanged;
     
        /// <summary>
        /// Contains the protected cell text so getting and setting can be altered. All lowercase to differentiate from property of same name.
        /// </summary>
        protected string celltext = string.Empty;

        /// <summary>
        ///  Contains the protected cell value so getting and setting can be altered. All lowercase to differentiate from property of same name.
        /// </summary>
        protected string cellvalue = "";


        /// <summary>
        /// Gets the current index of the row.
        /// </summary>
        public int RowIndex { get; }

        /// <summary>
        /// Gets the current index of the column.
        /// </summary>
        public int ColumnIndex { get; }

        /// <summary>
        /// Get / Set cell text with check for same text. Also allows subscription.
        /// </summary>
        public string cellText
        {
            get
            {
                return celltext;
            }

            set
            {
                if (value != this.celltext) 
                {
                    celltext = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Text"));

                }
            }
        }

        /// <summary>
        /// Get / Set cell value with check for same value. Also allows subscription.
        /// </summary>
        public string cellValue
        {
            get 
            { 
                return cellvalue;
            }

            internal set
            {
                if (value != this.cellvalue)
                {
                    cellvalue = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Value"));

                }
            }
        }
    }
}