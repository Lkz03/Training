using Training.Helpers;
using Training.Objects;

namespace Training
{
    public class PlanTests
    {
        private string xlsPath = @"C:\\Users\\AndriusBogda\\Downloads\\ImportFile.xls";
        private string csvPath = @"C:\\Users\\AndriusBogda\\Downloads\\ExportFile.csv";

        [Test]
        public void CreateCSVFromXlsTest()
        {
            var xls = ExcelHelper.Deserialize(xlsPath);
            var csv = new CsvFile<string>(xls[0]);

            for (int i = 1; i < xls.Length; i++)
            {
                var plan = new Plan(xls[i][0], xls[i][1], xls[i][2], xls[i][3], xls[i][4], xls[i][5]);

                csv.AddRow(
                    plan.ToList()
                );
            }

            csv.SaveAs(csvPath);

            Assert.IsTrue(File.Exists(csvPath));
        }

        [Test]
        public void ValidateCSV()
        {
            var xls = ExcelHelper.Deserialize(xlsPath);
            var csv = new CsvFile<string>(xls[0]);

            for (int i = 1; i < xls.Length; i++)
            {
                var plan = new Plan(xls[i][0], xls[i][1], xls[i][2], xls[i][3], xls[i][4], xls[i][5]);

                csv.AddRow(
                    plan.ToList()
                );
            }

            for (int i = 1; i < xls.Length; i++)
            {
                for (int j = 0; j < xls[i].Length; j++)
                {
                    Assert.IsTrue(csv.Contains(xls[i][j]));
                }
            }
        }
    }
}