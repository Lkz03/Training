using System.IO.Compression;

namespace Training.Helpers
{
    internal static class ZipHelper
    {
        internal static Stream OpenFile(string path, string fileName)
        {
            var zip = ZipFile.OpenRead(path);
            var e = zip.GetEntry(fileName);
            return e.Open();
        }
    }
}
