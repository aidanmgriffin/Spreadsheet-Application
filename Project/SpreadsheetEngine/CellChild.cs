namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Allows spreadsheet class to create instances of abstract cell class.
    /// </summary>
    public class CellChild : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CellChild"/> class.
        /// Facilitates Cell having no option for 0 parameters by adding columnindex and rowindex parameters.
        /// </summary>
        /// <param name="columnIndex"> Current index of column required for cell class. </param>
        /// <param name="rowIndex"> Current index of row required for cell class. </param>
        public CellChild(int columnIndex, int rowIndex)
            : base(columnIndex, rowIndex)
        {
        }
    }
}
