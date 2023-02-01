﻿using System.Text;

namespace Training.Objects
{
    public class CsvFile<T>
    {
        private T[] _header;
        private List<List<T>> _table;

        public T this[int i, int j] => _table[i][j];

        public CsvFile(ICollection<T> header)
        {
            _header = new T[header.Count];
            _table = new List<List<T>>();

            for (var i = 0; i < header.Count; i++)
            {
                _header[i] = header.ElementAt(i);
            }
        }

        public bool Contains(T value)
        {
            foreach (var row in _table)
            {
                foreach (var column in row)
                {
                    if (value.Equals(column))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void AddRow(ICollection<T> row)
        {
            if (row.Count != _header.Length)
            {
                throw new InvalidDataException("Given row does not match the format");
            }

            _table.Add(row.ToList());
        }

        public void SaveAs(string path)
        {
            using (StreamWriter file = new StreamWriter(path, false))
            {
                var sb = new StringBuilder();

                for (int i = 0; i < _header.Length; i++)
                {
                    sb.Append(_header[i]);
                    sb.Append(",");
                }

                file.WriteLine(
                    sb.ToString()
                    );


                for (int i = 0; i < _table.Count; i++)
                {
                    sb.Clear();

                    for (int j = 0; j < _header.Length; j++)
                    {
                        sb.Append(_table[i][j]);

                        if (j < _header.Length - 1)
                        {
                            sb.Append(",");
                        }
                    }

                    file.WriteLine(
                    sb.ToString()
                    );
                }
            }
        }
    }
}
