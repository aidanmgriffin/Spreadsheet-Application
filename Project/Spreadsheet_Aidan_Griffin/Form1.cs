/*
 * Aidan Griffin
 * 11680523
 */

namespace Spreadsheet_Aidan_Griffin
{
    using Microsoft.VisualBasic;
    using SpreadsheetEngine;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.Reflection.Metadata;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Windows.Input;

    /// <summary>
    /// Preset Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Private instance of Spreadsheet class.
        /// </summary>
        private Spreadsheet newSpreadsheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// Preset Form1 Constructor.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();

            this.InitializeDataGrid();

            this.newSpreadsheet = new Spreadsheet(26, 50);
            this.newSpreadsheet.CellPropertyChanged += new PropertyChangedEventHandler(this.SpreadsheetPropertyChanged);
        }


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
        /// Struct object gets pushed onto undo stack for each change.
        /// </summary>
        public struct CellElements
        {
            public Cell _cell;
            public string cell_text;
            public uint cell_color;
            public int errorMessage;
        }

        string[] errorMessages = { "changing cell background color", "cell text change" };
        int errorMessage;
        int numColorsChanged = 0;

        /// <summary>
        /// This property updates the GridView cells when the spreadsheet cells are edited.
        /// </summary>
        /// <param name="sender"> Sender parameter. </param>
        /// <param name="e"> PropertyChangedEventArgs parameter. </param>
        private void SpreadsheetPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell temp = sender as Cell;

            if ((string)this.dataGridView1.Rows[temp.RowIndex].Cells[temp.ColumnIndex].Value == string.Empty || ToUint(this.dataGridView1.Rows[temp.RowIndex].Cells[temp.ColumnIndex].Style.BackColor) == 0)
            {
                CellElements emptyElements = new CellElements();
                emptyElements.cell_text = " ";
                emptyElements.cell_color = 4294967295;
                emptyElements._cell = temp;

                switch (e.PropertyName)
                {
                    case "BGColor":
                        emptyElements.errorMessage = 0;
                        break;
                    case "Value":
                        emptyElements.errorMessage = 1;
                        break;
                }

                this.AddEdit(emptyElements);
            }

            CellElements cellElem = new CellElements();

            if (e.PropertyName == "BGColor")
            {
                this.dataGridView1.Rows[temp.RowIndex].Cells[temp.ColumnIndex].Style.BackColor = ToColor(temp.BGColor);
                this.undoActionHereToolStripMenuItem.Text = "undo " + this.errorMessages[0];
                cellElem.cell_color = temp.BGColor;
                cellElem.errorMessage = 0;
            }
            else if (e.PropertyName == "Value")
            {
                this.dataGridView1.Rows[temp.RowIndex].Cells[temp.ColumnIndex].Value = temp.CellValue;
                this.undoActionHereToolStripMenuItem.Text = "undo " + errorMessages[1];
                cellElem.cell_text = temp.CellText;
                cellElem.errorMessage = 1;
            }

            if (e.PropertyName != "Text")
            {
                cellElem._cell = temp;
                this.AddEdit(cellElem);
            }
        }

        //Reference: https://social.msdn.microsoft.com/Forums/vstudio/en-US/23cc280f-306e-444d-9577-3d6458094b99/converting-from-color-to-uint-and-vice-versa?forum=wpf
        private static Color ToColor(uint value)
        {
            return Color.FromArgb((byte)((value >> 24) & 0xFF),
                       (byte)((value >> 16) & 0xFF),
                       (byte)((value >> 8) & 0xFF),
                       (byte)(value & 0xFF));
        }

        private static uint ToUint(Color c)
        {
            return (uint)(((c.A << 24) | (c.R << 16) | (c.G << 8) | c.B) & 0xffffffffL);
        }

        /// <summary>
        /// On button click, the demos are initiated.
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
                temp.CellText = "Hello";
            }

            for (int i = 0; i < 50; i++)
            {
                SpreadsheetEngine.Cell temp = this.newSpreadsheet.GetCell(1, i);
                temp.CellText = "This is cell B" + (i + 1);
            }

            for (int i = 0; i < 50; i++)
            {
                SpreadsheetEngine.Cell temp = this.newSpreadsheet.GetCell(0, i);
                temp.CellText = "=B" + (i + 1);
            }
        }

        /// <summary>
        /// On cell click, display formula.
        /// </summary>
        /// <param name="sender"> Sender. </param>
        /// <param name="e"> e. </param>
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            SpreadsheetEngine.Cell temp = this.newSpreadsheet.GetCell(e.ColumnIndex, e.RowIndex);
            this.dataGridView1.Rows[temp.RowIndex].Cells[temp.ColumnIndex].Value = temp.CellText;

            Console.WriteLine(temp.CellText);
        }

        /// <summary>
        /// When done editing cell, set cell value.
        /// </summary>
        /// <param name="sender"> Sender. </param>
        /// <param name="e"> e. </param>
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SpreadsheetEngine.Cell temp = this.newSpreadsheet.GetCell(e.ColumnIndex, e.RowIndex);

            try
            {
                string msg = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = temp.CellValue;
                temp.CellText = msg;
            }
            catch (Exception ex)
            {
                temp.CellText = null;
            }
        }

        /// <summary>
        /// Number of cells that are colored in a group.
        /// </summary>
        Dictionary<string, int> CellGroup = new Dictionary<string, int>();

        /// <summary>
        /// Change color of cell.
        /// </summary>
        /// <param name="sender"> sender. </param>
        /// <param name="e"> e. </param>
        private void ChangeColor_Click(object sender, EventArgs e)
        {
            ColorDialog newDialog = new ColorDialog();
            newDialog.ShowDialog();

            Color c = newDialog.Color;
            uint colorUint = (uint)(((c.A << 24) | (c.R << 16) | (c.G << 8) | c.B) & 0xffffffffL);


            foreach (DataGridViewCell cell in this.dataGridView1.SelectedCells)
            {
                SpreadsheetEngine.Cell temp = this.newSpreadsheet.GetCell(cell.ColumnIndex, cell.RowIndex);

                string key = string.Empty;
                key += (char)(temp.ColumnIndex + 65);
                key += temp.RowIndex + 1;

                temp.BGColor = colorUint;

                this.CellGroup[key] = this.dataGridView1.SelectedCells.Count;
            }
        }

        private Stack<CellElements> historyStack = new Stack<CellElements>();
        private Stack<CellElements> undoStack = new Stack<CellElements>();

        private bool undoEnabled = false;
        private bool redoEnabled = false;

        /// <summary>
        /// Cell is edited. Used for undo stack.
        /// </summary>
        /// <param name="editCell"> editCell stack. </param>
        public void AddEdit(CellElements editCell)
        {
            this.historyStack.Push(editCell);
            this.undoEnabled = true;
            //this.undoStack.Clear();
            this.redoEnabled = false;
        }

        /// <summary>
        /// Undo button function.
        /// </summary>
        /// <param name="sender"> Sender param. </param>
        /// <param name="e"> e param. </param>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int k = 8;

            for (int i = 0; i < k; i++)
            {
                if (this.undoEnabled)
                {
                    this.undoStack.Push(this.historyStack.Pop());

                    this.redoEnabled = true;
                    CellElements undoCell = this.historyStack.Peek();

                    string key = string.Empty;
                    key += (char)(undoCell._cell.ColumnIndex + 65);
                    key += undoCell._cell.RowIndex + 1;

                    switch (undoCell.errorMessage)
                    {
                        case 0:
                            if (this.CellGroup.ContainsKey(key))
                            {
                                k += this.CellGroup[key] + 1;
                            }

                            undoCell._cell.BGColor = undoCell.cell_color;
                            this.redoToolStripMenuItem.Text = "redo " + errorMessages[0];

                            break;
                        case 1:
                            undoCell._cell.CellText = undoCell.cell_text;
                            this.redoToolStripMenuItem.Text = "redo " + errorMessages[1];

                            break;
                    }

                    if (this.historyStack.Count > 1)
                    {
                        this.undoEnabled = true;
                    }
                    else
                    {
                        this.undoEnabled = false;
                    }

                }
            }


            this.numColorsChanged = 0;
        }

        /// <summary>
        /// Redo button function. Fails redoing colors.
        /// </summary>
        /// <param name="sender"> Sender. </param>
        /// <param name="e"> e. </param>
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int k = 7;
            CellElements redoCell;

            for (int i = 0; i < k; i++)
            {
                if (this.redoEnabled)
                {
                    this.historyStack.Push(this.undoStack.Pop());

                    if (this.undoStack.Count > 0)
                    {
                        this.redoEnabled = true;
                    }

                    redoCell = this.historyStack.Peek();

                    string key = string.Empty;
                    key += (char)(redoCell._cell.ColumnIndex + 65);
                    key += redoCell._cell.RowIndex + 1;

                        switch (redoCell.errorMessage)
                        {
                            case 0:
                            
                                if (this.CellGroup.ContainsKey(key))
                                {
                                    k += this.CellGroup[key] + 1;
                                }
                                redoCell._cell.bgcolor = redoCell.cell_color;
                                break;

                            case 1:
                            
                            if (redoCell.cell_text != " ")
                            {
                                redoCell._cell.CellText = redoCell.cell_text;
                                break;
                            }
                            break;
                        }
                    
                }
            }

        }
    }
}