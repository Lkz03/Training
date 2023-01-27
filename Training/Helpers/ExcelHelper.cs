using System.Runtime.InteropServices;
using Training.Objects;
using Excel = Microsoft.Office.Interop.Excel;

namespace Training.Helpers
{
    internal static class ExcelHelper
    {
        internal static string[][] Deserialize(string path, bool ignoreHeader = false)
        {
            // initialize
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            var rowStart = 1;
            if (ignoreHeader)
            {
                rowStart = 2;
            }
            

            // open xls
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(path, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // set range for occupied cells
            range = xlWorkSheet.UsedRange;

            var rows = range.Rows.Count;
            var columns = range.Columns.Count;

            // release objects
            Marshal.ReleaseComObject(xlApp);
            Marshal.ReleaseComObject(xlWorkBook);

            // read xls
            var lines = new string[rows - rowStart + 1][];

            for (var rCnt = rowStart; rCnt <= rows; rCnt++)
            {
                var stringValues = new string[columns];

                for (var cCnt = 1; cCnt <= columns; cCnt++)
                {
                    stringValues[cCnt - 1] = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                }

                lines[rCnt - rowStart] = stringValues;
            }

            // release the rest
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(range);

            return lines;
        }

        public static T[] DeserializeInTo<T>(string path, bool isCsv = false) where T : PlanObject<string>
        {
            var objects = ExcelHelper.Deserialize(path, true);
            T[] list = new T[objects.Length];

            for (int i = 0; i < objects.Length; i++)
            {
                if (isCsv)
                {
                    objects[i] = objects[i].First().Split(',');
                }

                list[i] = (T)Activator.CreateInstance(typeof(T), new object[] { objects[i] });
            }

            return list;
        }
    }
}