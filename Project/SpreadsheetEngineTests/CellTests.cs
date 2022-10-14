namespace SpreadsheetEngineTests
{
    public class CellTests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void InstantiateCellTextGetterTest()
        {
            int column = 0;
            int row = 0;

            SpreadsheetEngine.CellChild testCell = new SpreadsheetEngine.CellChild(column, row);
            testCell.CellText = "TestInput";
            testCell.CellText = "NewTestInput";
            Assert.That(testCell.CellText, Is.EqualTo("NewTestInput"));
        }

        [Test]
        public void InstantiateCellTextSetterTest()
        {
            int column = 0;
            int row = 0;

            SpreadsheetEngine.CellChild testCell = new SpreadsheetEngine.CellChild(column, row);
            testCell.CellText = "TestInput";
            testCell.CellText = "TestInput";
            Assert.That(testCell.CellText, Is.EqualTo("TestInput"));
        }

        [Test]
        public void InstantiateCellColumnConstructorTest()
        {
            int column = 0;
            int row = 0;

            SpreadsheetEngine.CellChild testCell = new SpreadsheetEngine.CellChild(column, row);

            Assert.That(testCell.ColumnIndex, Is.EqualTo(column));
        }

        [Test]
        public void InstantiateCellRowConstructorTest()
        {
            int column = 0;
            int row = 0;

            SpreadsheetEngine.CellChild testCell = new SpreadsheetEngine.CellChild(column, row);
            
            Assert.That(testCell.RowIndex, Is.EqualTo(row));
        }

    }
}