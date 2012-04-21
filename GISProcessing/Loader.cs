using System;
using System.Collections.Generic;
using System.IO;
using GISProcessing.Models;

namespace GISProcessing
{
    public class Loader
    {
        private StreamReader sr;
        private string delimiter;
        private Columns[] columns;
        private ITimeDomain timeDomain;
        private int skip;
        private string file;

        public List<Measurement> Data;
        public string Name;
        public enum Columns { ID = 1, X = 2, Y = 3, Value = 4, Year = 5, Quarter = 6, Month = 7, Day = 8 }
        public int CurrentLine;

        public Loader(string file, string delimiter, Columns[] columns, ITimeDomain timeDomain, int skip)
        {
            // Populate fields.
            this.CurrentLine = 1;
            this.Name = new FileInfo(file).Name;
            this.Data = new List<Measurement>();
            this.columns = columns;
            this.delimiter = "\t";
            this.timeDomain = timeDomain;
            this.skip = skip;
            this.file = file;
        }

        public void Parse()
        {
            // Loop through the file and parse each value into memory.
            int skipped = 0;
            this.sr = new StreamReader(File.OpenRead(this.file));
            while (sr.Peek() > -1)
            {
                string text = sr.ReadLine();
                if (skipped == this.skip)
                {
                    this.Data.Add(this.parseLine(text));
                }
                else
                {
                    skipped++;
                }
                this.CurrentLine++;
            }
            sr.Close();
        }

        private Measurement parseLine(string text)
        {
            // Tokenize the string.
            string[] tokens = text.Split(new string[] {this.delimiter}, StringSplitOptions.RemoveEmptyEntries);

            // Populate the measurement.
            Measurement measurement = new Measurement();
            measurement.Time = (ITimeDomain)Activator.CreateInstance(this.timeDomain.GetType());
            for (int i = 0; i < tokens.Length; i++)
            {
                switch (this.columns[i])
                {
                    case Columns.ID:
                        measurement.ID = long.Parse(tokens[i]);
                        break;
                    case Columns.X:
                        measurement.X = float.Parse(tokens[i]);
                        break;
                    case Columns.Y:
                        measurement.Y = float.Parse(tokens[i]);
                        break;
                    case Columns.Value:
                        measurement.Value = float.Parse(tokens[i]);
                        break;
                    case Columns.Year:
                        measurement.Time.SetProperty("year", int.Parse(tokens[i]));
                        break;
                    case Columns.Quarter:
                        measurement.Time.SetProperty("quarter", int.Parse(tokens[i]));
                        break;
                    case Columns.Month:
                        measurement.Time.SetProperty("month", int.Parse(tokens[i]));
                        break;
                    case Columns.Day:
                        measurement.Time.SetProperty("day", int.Parse(tokens[i]));
                        break;
                }
            }

            return measurement;
        }
    }
}
