namespace Training.Helpers
{
    public static class CsvHelper
    {
        public static void WriteTo(string path, string[][] table)
        {
            using (StreamWriter file = new StreamWriter(path, false))
            {
                for (int i = 0; i < table.Length; i++)
                {
                    for (int j = 0; j < table[i].Length; j++)
                    {
                        if (j < table[i].Length - 1)
                        {
                            file.WriteLine(table[i][j] + ',');
                        }
                        else
                        {
                            file.WriteLine(table[i][j]);
                        }
                    }
                }
            }
        }
    }
}
