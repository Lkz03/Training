using Training.Constants;
using Training.Helpers;
using Training.Objects;

namespace Training
{
    public class PlanTests
    {
        private Plan[] plans;

        [OneTimeSetUp]
        public void Setup()
        {
            plans = ExcelHelper.DeserializeInTo<Plan>(ExcelConstants.ExcelData);
        }

        [Test]
        public void CreateCSVFromXlsTest()
        {
            var xls = ExcelHelper.Deserialize(ExcelConstants.ExcelPlanTemplateFile);

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
            csv.SaveAs(ExcelConstants.excelCsvExportFile);

            Assert.IsTrue(File.Exists(ExcelConstants.excelCsvExportFile), "Csv file was not saved");
        }

        [Test, TestCaseSource(typeof(DataHelper), nameof(DataHelper.GetCsvPlanFile))]
        public void ValidateCSV(Plan csvRecord)
        {
            Plan? csvRow = plans.Where(x => x.EmployeeIdentifier.Equals(csvRecord.EmployeeIdentifier)).FirstOrDefault();

            Assert.IsNotNull(csvRow,
                    $"Could not find row with id: {csvRecord.EmployeeIdentifier}");

            Assert.Multiple(() =>
            {
                Assert.That(csvRecord.ContributionDate, Is.EqualTo(csvRow.ContributionDate),
                    $"value {csvRow.ContributionDate} does not match");
                Assert.That(csvRecord.ContributionDescription, Is.EqualTo(csvRow.ContributionDescription),
                    $"value {csvRow.ContributionDescription} does not match");
                Assert.That(csvRecord.ContributionAmount, Is.EqualTo(csvRow.ContributionAmount),
                    $"value {csvRow.ContributionAmount} does not match");
                Assert.That(csvRecord.PlanName, Is.EqualTo(csvRow.PlanName),
                    $"value {csvRow.PlanName} does not match");
                Assert.That(csvRecord.PriorTaxYear, Is.EqualTo(csvRow.PriorTaxYear),
                    $"value {csvRow.PriorTaxYear} does not match");
            });
        }
    }
}