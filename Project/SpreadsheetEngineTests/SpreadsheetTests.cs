namespace SpreadsheetEngineTests
{
    public class SpreadsheetTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InstantiateSpreadsheetNullTest()
        {
            int numColumns = 0;
            int numRows = 0;

            SpreadsheetEngine.Spreadsheet testSpreadsheet = new SpreadsheetEngine.Spreadsheet(numColumns, numRows);

            Assert.That(testSpreadsheet, Is.Not.Null);
        }

        [Test]
        public void InstantiateSpreadsheetGetCellTest()
        {
            int numColumns = 26;
            int numRows = 50;

            SpreadsheetEngine.Spreadsheet testSpreadsheet = new SpreadsheetEngine.Spreadsheet(numColumns, numRows);
            SpreadsheetEngine.CellChild testCell = new SpreadsheetEngine.CellChild(5, 5); 
            Assert.That(testSpreadsheet.GetCell(5,5), Is.EqualTo(testCell));
        }
    }
}