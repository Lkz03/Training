using Training.Helpers;

namespace Training
{
    public class PlanTests
    {
        private string xlsPath = @"C:\\Users\\AndriusBogda\\Downloads\\ImportFile.xls";
        private string csvPath = @"C:\\Users\\AndriusBogda\\Downloads\\ExportFile.csv";

        [Test]
        public void CreateCSVFromXlsTest()
        {
            CsvHelper.WriteTo(
                csvPath,
                ExcelHelper.Deserialize(xlsPath, true));

            Assert.IsTrue(File.Exists(csvPath));
        }

        [Test]
        public void ValidateCSV()
        {
            var csv = ExcelHelper.Deserialize(csvPath);
            var xls = ExcelHelper.Deserialize(xlsPath, true);

            for (int i = 0; i < xls.Length; i++)
            {
                for (int j = 0; j < xls[i].Length; j++)
                {
                    Assert.AreEqual(xls[i][j], csv[j][i].Replace(",", ""));
                }
            }
        }
    }
}