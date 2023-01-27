using System.Linq;
using System.Numerics;
using Training.Helpers;
using Training.Objects;

namespace Training
{
    public class PlanTests
    {
        private string xlsPath = @"C:\\Users\\AndriusBogda\\Downloads\\ImportFile.xls";
        private string csvPath = @"C:\\Users\\AndriusBogda\\Downloads\\ExportFile.csv";
        private string newValues = @"C:\\Users\\AndriusBogda\\Downloads\\ImportFile2.xls";

        private Plan[] plans;

        [OneTimeSetUp]
        public void Setup()
        {
            plans = ExcelHelper.DeserializeInTo<Plan>(newValues);
        }

        [Test]
        public void CreateCSVFromXlsTest()
        {
            var xls = ExcelHelper.Deserialize(xlsPath);

            // create csv file with custom header from xls
            var csv = new CsvFile<string>(xls[0]);

            // add default values from xls
            for (int i = 1; i < xls.Length; i++)
            {
                var plan = new Plan(xls[i]);

                csv.AddRow(
                    plan.ToList()
                );
            }

            // add custom values from another xls
            foreach (var row in plans)
            {
                csv.AddRow(
                    row.ToList()
                );
            }

            // save csv file
            csv.SaveAs(csvPath);

            Assert.IsTrue(File.Exists(csvPath), "Csv file was not saved");
        }

        [Test]
        public void ValidateCSV()
        {
            var csvValues = ExcelHelper.DeserializeInTo<Plan>(csvPath, true);

            foreach (var plan in plans)
            {
                Assert.IsTrue(csvValues.Where(
                    x => x.EmployeeIdentifier.Equals(plan.EmployeeIdentifier) &&
                    x.ContributionDate.Equals(plan.ContributionDate) &&
                    x.ContributionDescription.Equals(plan.ContributionDescription) &&
                    x.ContributionAmount.Equals(plan.ContributionAmount) &&
                    x.PlanName.Equals(plan.PlanName) &&
                    x.PriorTaxYear.Equals(plan.PriorTaxYear)).Any(),
                    "Csv file does not contain any custom values");
            }
        }
    }
}