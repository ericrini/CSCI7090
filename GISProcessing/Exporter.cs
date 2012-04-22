using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GISProcessing.Models
{
    public class Exporter
    {
        public enum Columns { ID = 1, X = 2, Y = 3, Value = 4, Year = 5, Quarter = 6, Month = 7, Day = 8 }

        private string path;
        private List<Measurement> measurements; 
        private Columns[] columns;
        private string lineTerminator;
        private string delimiter;
        private bool header;
        private StreamWriter sw;

        public Exporter(string path, List<Measurement> measurements, Columns[] columns, string lineTerminator, string delimiter, bool header)
        {
            this.path = path;
            this.measurements = measurements;
            this.columns = columns;
            this.lineTerminator = lineTerminator;
            this.delimiter = delimiter;
            this.header = header;
        }

        public void Save()
        {
            this.sw = new StreamWriter(File.OpenWrite(this.path));

            // Write the header row.
            if (this.header)
            {
                for (int i = 0; i < this.columns.Length; i++)
                {
                    // Write out a delimiter character if this is not the first column.
                    if (i != 0)
                    {
                        sw.Write(this.delimiter);
                    }

                    // Write out the column name.
                    sw.Write(this.columns[i].ToString());

                    // Write out a carriage return if this is the last column.
                    if (i == this.columns.Length - 1)
                    {
                        sw.Write(this.lineTerminator);
                    }
                }
            }

            // Loop through the measures and write each row.
            foreach (Measurement currM in this.measurements)
            {
                for (int i = 0; i < this.columns.Length; i++)
                {
                    // Write out a delimiter character if this is not the first column.
                    if (i != 0)
                    {
                        sw.Write(this.delimiter);
                    }

                    // Write out the data value.
                    switch (this.columns[i])
                    {
                        case Columns.ID:
                            sw.Write(currM.ID);
                            break;
                        case Columns.X:
                            sw.Write(currM.X);
                            break;
                        case Columns.Y:
                            sw.Write(currM.Y);
                            break;
                        case Columns.Value:
                            sw.Write(currM.Value);
                            break;
                        case Columns.Year:
                            sw.Write(currM.Time.DateTime.Year);
                            break;
                        case Columns.Quarter:
                            sw.Write(currM.Time.DateTime.Month);
                            break;
                        case Columns.Month:
                            sw.Write(currM.Time.DateTime.Month);
                            break;
                        case Columns.Day:
                            sw.Write(currM.Time.DateTime.Day);
                            break;
                    }

                    // Write out a carriage return if this is the last column.
                    if (i == this.columns.Length - 1)
                    {
                        sw.Write(this.lineTerminator);
                    }
                }
            }

            this.sw.Flush();
            this.sw.Close();
        }
    }
}
