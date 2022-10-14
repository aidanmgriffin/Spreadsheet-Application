using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace SpreadsheetEngine
{
    public abstract class Cell : INotifyPropertyChanged
    {

        public Cell(int columnIndex, int rowIndex)
        {
            this.rowIndex = rowIndex;
            this.columnIndex = columnIndex;
        }

        public int rowIndex { get; }
        public int columnIndex { get; }

        protected string celltext = "";

        public event PropertyChangedEventHandler PropertyChanged; //= delegate { };

        public string cellText
        {
            get { return celltext; }

            set
            {
                if (value != this.celltext) 
                {
                    celltext = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Text"));

                }
            }
        }

        protected string cellvalue = "";
        public string cellValue
        {
            get { return cellvalue; }
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