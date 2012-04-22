using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GISProcessing.Models
{
    public class DayTimeDomain: ITimeDomain
    {
        private int year = 1;
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

        private double tVal;
        public double TVal
        {
            get
            {
                return this.tVal;
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
            this.tVal++;
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
            this.recaluclate();
        }

        public void SetT(double value)
        {
            DateTime t = new DateTime(this.year, 1, 1);
            t = t.AddDays(value);
            this.year = t.Year;
            this.month = t.Month;
            this.day = t.Day;
            this.recaluclate();
        }

        /// <summary>
        /// Profiler says this is expensive operation so we need to minimize it to only 
        /// occur when it is needed not every time get TVal is called.
        /// </summary>
        private void recaluclate()
        {
            DateTime firstOfYear = new DateTime(this.year, 1, 1);
            TimeSpan ts = this.DateTime.Subtract(firstOfYear);
            this.tVal = ts.TotalDays + 1;
        }
    }
}
