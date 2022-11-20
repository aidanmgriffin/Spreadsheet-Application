namespace SpreadsheetEngineTests
{
    public class SpreadsheetTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Test the creation of a new spreadsheet
        [Test]
        public void InstantiateSpreadsheetNullTest()
        {
            int numColumns = 0;
            int numRows = 0;

            SpreadsheetEngine.Spreadsheet testSpreadsheet = new SpreadsheetEngine.Spreadsheet(numColumns, numRows);

            Assert.That(testSpreadsheet, Is.Not.Null);
        }

        //Test the retrieval of an individual cell
        [Test]
        public void InstantiateSpreadsheetGetCellTest()
        {
            int numColumns = 26;
            int numRows = 50;

            SpreadsheetEngine.Spreadsheet testSpreadsheet = new SpreadsheetEngine.Spreadsheet(numColumns, numRows);
            SpreadsheetEngine.CellChild testCell = new SpreadsheetEngine.CellChild(5, 5);
            Assert.That(testSpreadsheet.GetCell(5, 5), Is.EqualTo(testCell));
        }

        //Test the ability of single operand cell text to be adopted as cell value.
        [Test]
        public void SpreadsheetTextValueTest()
        {
            int numColumns = 26;
            int numRows = 50;

            SpreadsheetEngine.Spreadsheet testSpreadsheet = new SpreadsheetEngine.Spreadsheet(numColumns, numRows);
            SpreadsheetEngine.CellChild testCell = new SpreadsheetEngine.CellChild(5, 5);
            testCell.CellText = "5";
            Assert.That(testSpreadsheet.GetCell(5, 5).CellValue, Is.EqualTo("5"));
        }

        //Test the ability of the spreadsheet to adopt values using cell locations as variables.
        [Test]
        public void SpreadsheetVariableTest()
        {
            int numColumns = 26;
            int numRows = 50;

            //single references
            SpreadsheetEngine.Spreadsheet testSpreadsheet = new SpreadsheetEngine.Spreadsheet(numColumns, numRows);
            SpreadsheetEngine.CellChild testCell = new SpreadsheetEngine.CellChild(0, 0);
            SpreadsheetEngine.CellChild testCell2 = new SpreadsheetEngine.CellChild(5, 5);
            testCell.CellText = "5";
            testCell2.CellText = "=A1";
            Assert.That(testSpreadsheet.GetCell(5, 5).CellValue, Is.EqualTo("5"));

            //chain reference
            SpreadsheetEngine.CellChild testCell3 = new SpreadsheetEngine.CellChild(0, 0);
            SpreadsheetEngine.CellChild testCell4 = new SpreadsheetEngine.CellChild(0, 1);
            SpreadsheetEngine.CellChild testCell5 = new SpreadsheetEngine.CellChild(6, 6);
            testCell3.CellText = "5";
            testCell4.CellText = "=A1";
            testCell5.CellText = "=A2";

            //multiple references
            SpreadsheetEngine.CellChild testCell6 = new SpreadsheetEngine.CellChild(0, 0);
            SpreadsheetEngine.CellChild testCell7 = new SpreadsheetEngine.CellChild(0, 1);
            SpreadsheetEngine.CellChild testCell8 = new SpreadsheetEngine.CellChild(0, 2);
            testCell6.CellText = "5";
            testCell7.CellText = "=A1";
            testCell8.CellText = "=A1";

            Assert.That(testCell6.CellValue, Is.EqualTo("5"));
            Assert.That(testCell7.CellValue, Is.EqualTo("5"));
            Assert.That(testCell8.CellValue, Is.EqualTo("5"));

        }

        //Test the ability of single operand cell text to be adopted as cell value.
        [Test]
        public void SpreadsheetTextUndoTest()
        {
            int numColumns = 26;
            int numRows = 50;

            SpreadsheetEngine.Spreadsheet testSpreadsheet = new SpreadsheetEngine.Spreadsheet(numColumns, numRows);
            SpreadsheetEngine.CellChild testCell = new SpreadsheetEngine.CellChild(5, 5);
            
            testCell.CellText = "5";
            testCell.CellText = "2";

            
            
            Assert.That(testSpreadsheet.GetCell(5, 5).CellValue, Is.EqualTo("5"));
        }



    }
}