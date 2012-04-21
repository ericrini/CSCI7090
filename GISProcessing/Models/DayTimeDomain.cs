using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GISProcessing.Models
{
    public class DayTimeDomain: ITimeDomain
    {
        private int year = 2000;
        private int month = 1;
        private int day = 1;

        public string Name
        {
            get 
            {
                return "Daily";
            }
        }

        public DateTime DateTime
        {
            get
            {
                return new DateTime(this.year, this.month, this.day);
            }
        }

        public double TVal
        {
            get
            {
                DateTime firstOfYear = new DateTime(this.year, 1, 1);
                TimeSpan ts = this.DateTime.Subtract(firstOfYear);
                return ts.TotalDays;
            }
        }

        public double TMax
        {
            get 
            {
                return 365;
            }
        }

        public void IncrementT()
        {
            DateTime current = this.DateTime;
            current = current.AddDays(1);
            this.year = current.Year;
            this.month = current.Month;
            this.day = current.Day;
        }


        public void SetProperty(string property, int value)
        {
            if (property == "day")
            {
                this.day = value;
            }
            else if (property == "month")
            {
                this.month = value;
            }
            else if (property == "year")
            {
                this.year = value;
            }
            else
            {
                throw new Exception("The property: " + property + " is invalid for this TimeDomain.");
            }
        }

        public void SetT(double value)
        {
            DateTime t = new DateTime(this.year, 1, 1);
            t = t.AddDays(value - 1);
            this.year = t.Year;
            this.month = t.Month;
            this.day = t.Day;
        }
    }
}
