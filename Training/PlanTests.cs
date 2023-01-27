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
            csv.SaveAs(ExcelConstants.ExcelCsvExportFile);

            Assert.IsTrue(File.Exists(ExcelConstants.ExcelCsvExportFile), "Csv file was not saved");
        }

        [Test]
        public void ValidateCSV()
        {
            var csvValues = ExcelHelper.DeserializeInTo<Plan>(ExcelConstants.ExcelCsvExportFile, true);

            foreach (var plan in plans)
            {
                var csvRow = csvValues.Where(x => x.EmployeeIdentifier.Equals(plan.EmployeeIdentifier)).FirstOrDefault();

                Assert.IsNotNull(csvRow,
                        $"Could not find row with id: {plan.EmployeeIdentifier}");

                Assert.Multiple(() =>
                {
                    Assert.That(csvRow.ContributionDate, Is.EqualTo(plan.ContributionDate),
                        $"value {plan.ContributionDate} does not match");
                    Assert.That(csvRow.ContributionDescription, Is.EqualTo(plan.ContributionDescription),
                        $"value {plan.ContributionDescription} does not match");
                    Assert.That(csvRow.ContributionAmount, Is.EqualTo(plan.ContributionAmount),
                        $"value {plan.ContributionAmount} does not match");
                    Assert.That(csvRow.PlanName, Is.EqualTo(plan.PlanName),
                        $"value {plan.PlanName} does not match");
                    Assert.That(csvRow.PriorTaxYear, Is.EqualTo(plan.PriorTaxYear),
                        $"value {plan.PriorTaxYear} does not match");
                });
            }
        }
    }
}