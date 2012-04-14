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
        private Time.TimeDomain domain;
        private int skip;

        public List<Measurement> Data;
        public enum Columns { ID = 1, X = 2, Y = 3, Value = 4, Year = 5, Quarter = 6, Month = 7, Day = 8 }

        public Loader(string file, string delimiter, Columns[] columns, Time.TimeDomain domain, int skip)
        {
            // Populate fields.
            this.Data = new List<Measurement>();
            this.columns = columns;
            this.delimiter = "\t";
            this.domain = domain;
            this.skip = skip;
            
            // Loop through the file and parse each value into memory.
            int skipped = 0;
            this.sr = new StreamReader(File.OpenRead(file));
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
            }
            sr.Close();
        }

        private Measurement parseLine(string text)
        {
            // Tokenize the string.
            string[] tokens = text.Split(new string[] {this.delimiter}, StringSplitOptions.RemoveEmptyEntries);

            // Populate the measurement.
            Measurement measurement = new Measurement(new Time(domain));
            for (int i = 0; i < tokens.Length; i++)
            {
                switch (this.columns[i])
                {
                    case Columns.ID:
                        measurement.ID = int.Parse(tokens[i]);
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
                        measurement.Time.Value[0] = int.Parse(tokens[i]);
                        break;
                    case Columns.Quarter:
                        measurement.Time.Value[1] = int.Parse(tokens[i]);
                        break;
                    case Columns.Month:
                        measurement.Time.Value[1] = int.Parse(tokens[i]);
                        break;
                    case Columns.Day:
                        measurement.Time.Value[2] = int.Parse(tokens[i]);
                        break;
                }
            }
            return measurement;
        }
    }
}
