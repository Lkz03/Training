using Training.Constants;
using Training.Objects;

namespace Training.Helpers
{
    public static class DataHelper
    {
        public static IEnumerable<Plan> GetCsvPlanFile()
        {
            foreach (var plan in ExcelHelper.DeserializeInTo<Plan>(ExcelConstants.excelCsvExportFile, true))
            {
                yield return plan;
            }
        }
    }
}
