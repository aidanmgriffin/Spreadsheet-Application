using System.ComponentModel;

namespace SpreadsheetEngine
{
    public abstract class Cell : INotifyPropertyChanged
    {

        public Cell(int rowIndex, int columnIndex)
        {
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
        }

        public int rowIndex { get; }
        public int columnIndex { get; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected string cellText
        {
            get { return cellText; }
            set
            {
                if (value == cellText) { return; }
                cellText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("cellText"));
            }
        }

        protected string cellValue
        {
            get { return cellValue; }
        }
    }
}