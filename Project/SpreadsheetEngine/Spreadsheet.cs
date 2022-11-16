﻿/*
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
    using System.Runtime.InteropServices;
    using System.Security;
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
            columnCount = numColumns;
            rowCount = numRows;

            this.spreadsheetArray = new CellChild[columnCount, rowCount];

            for (int i = 0; i < numColumns; i++)
            {
                for (int j = 0; j < numRows; j++)
                {
                    CellChild newChild = new CellChild(i, j);
                    newChild.PropertyChanged += this.CellChangedEvent;


                    this.spreadsheetArray[i, j] = newChild;
                }
            }
        }

        /// <summary>
        /// List of all the cells that rely on a particular cell's value.
        /// </summary>
        Dictionary<string, List<string>> _dependencies = new Dictionary<string, List<string>>();

        /// <summary>
        /// Declare event handler.
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged;

        public List<string> allVars = new List<string>();

        /// <summary>
        /// Result of changes in cells. Sets cell value based on text in cell. Additionally, sends result to Form.
        /// </summary>
        /// <param name="sender"> Sender oject. </param>
        /// <param name="e"> PropertyChangedEventArgs. </param>
        public void CellChangedEvent(object sender, PropertyChangedEventArgs e)
        { 
            Cell temp = sender as Cell;

            if (temp.CellText != "")
            {
                string key = string.Empty;
                key += (char)(temp.ColumnIndex + 65);
                key += temp.RowIndex + 1;

                if (temp.CellText[0] == '=')
                {
                    foreach (string name in allVars) 
                    {
                        int number = name[0] - 65;
                        int number2 = name[1] - '1';
                        Cell othercell = GetCell(number, number2);
                        othercell.PropertyChanged -= temp.CellChanged;
                    }

                    string cellVal = temp.CellText.Substring(1);
                    ExpressionTree newExp = new ExpressionTree(cellVal);

                    List<string> varNames = new List<string>();

                    varNames = newExp.GetVariableNames();

                    double dictValue = newExp.Evaluate();
                    temp.CellValue = dictValue.ToString();
                    ExpressionTree.variables[key] = dictValue;


                    varNames = newExp.GetVariableNames();

                    foreach (string name in varNames)
                    {
                        int number = name[0] - 65;
                        int number2 = name[1] - '1';
                        Cell othercell = GetCell(number, number2);
                        othercell.PropertyChanged += temp.CellChanged;

                        //if (!this._dependencies.ContainsKey(name))
                        //{
                        //    this._dependencies.Add(name, new List<string>());
                        //}

                        //this._dependencies[name].Add(key);
                    }

                    //this.CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("Value"));

                }
                else
                {
                    temp.CellValue = temp.CellText;

                    double number;
                    double.TryParse(temp.CellValue, out number);

                    ExpressionTree.variables[key] = number;

                }

                allVars.Add(key);


                //if (this._dependencies.ContainsKey(key))
                //{
                //    Console.WriteLine("contains key " + key);

                //    foreach (var dependency in this._dependencies[key].ToList())
                //    {
                //        int depnumber = dependency[0] - 65;
                //        int depnumber2 = dependency[1] - '1';

                //        temp = this.spreadsheetArray[depnumber, depnumber2];

                //        //CellChangedEvent(dependentCell, new PropertyChangedEventArgs("Value"));
                //        if (temp.CellText[0] == '=')
                //        {
                //            string cellVal = temp.CellText.Substring(1);
                //            ExpressionTree newExp = new ExpressionTree(cellVal);

                //            List<string> varNames = new List<string>();

                //            varNames = newExp.GetVariableNames();

                //            double dictValue = newExp.Evaluate();
                //            temp.CellValue = dictValue.ToString();
                //            ExpressionTree.variables[key] = dictValue;


                //            varNames = newExp.GetVariableNames();

                //            foreach (string name in varNames)
                //            {

                //                if (!this._dependencies.ContainsKey(name))
                //                {
                //                    this._dependencies.Add(name, new List<string>());
                //                }

                //                this._dependencies[name].Add(key);
                //            }

                //            //this.CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("Value"));

                //        }
                //        else
                //        {
                //            temp.CellValue = temp.CellText;

                //            double number;
                //            double.TryParse(temp.CellValue, out number);

                //            ExpressionTree.variables[key] = number;

                //        }
                //    }

                //    Console.WriteLine("length = " + _dependencies.Count());
                //    //this._dependencies.Clear();
                //}
            }
            this.CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("Value"));
        }

        /// <summary>
        /// Unsuccsessful attempt at subscribing to second cell change event.
        /// </summary>
        /// <param name="sender">sender. </param>
        /// <param name="e">Property changed args.</param>
        public void CellEvent(object sender, PropertyChangedEventArgs e)
        {
            Cell temp = sender as Cell;

            if (e.PropertyName != null)
            {
                this.CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("Text"));
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
