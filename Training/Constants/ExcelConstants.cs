using System.Reflection;

namespace Training.Constants
{
    public static class ExcelConstants
    {
        private static string ExcutingAssembly => Path.Combine(Assembly.GetExecutingAssembly().Location.Replace("Training.dll", @"..\\..\\..\\"));
        public static string Assets => ExcutingAssembly + @"\\Assets";
        public static string ExcelPlanTemplateFile => Assets + @"\\ImportFile.xls";
        public static string ExcelData => Assets + @"\\ImportFile2.xls";
        public static string excelCsvExportFile => Assets + @"\\ExportFile.csv";
    }
}
