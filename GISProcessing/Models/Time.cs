using System;
using System.Text;

namespace GISProcessing.Models
{
    public class Time
    {
        public enum TimeDomain { None = 0, Year = 1, Quarter = 2, Month = 3, Day = 4 };
        public TimeDomain Domain;
        public int[] Value;

        public Time(TimeDomain domain)
        {
            // Set the time domain.
            this.Domain = domain;

            // Initialize the value array to the corect number of elements for the time domain.
            if (domain == TimeDomain.None)
            {
                this.Value = new int[0];
            }
            else if (domain == TimeDomain.Year) 
            {
                this.Value = new int[1];
            }
            else if (domain == TimeDomain.Month || domain == TimeDomain.Quarter)
            {
                this.Value = new int[2];
            }
            else // Day
            {
                this.Value = new int[3];
            }
        }

        public Time(TimeDomain domain, int year)
        {
            // Set the time domain.
            this.Domain = domain;

            // Initialize the value array to the corect number of elements for the time domain.
            if (domain == TimeDomain.None)
            {
                this.Value = new int[0];
            }
            else if (domain == TimeDomain.Year)
            {
                this.Value = new int[1];
                this.Value[0] = year;
            }
            else if (domain == TimeDomain.Month || domain == TimeDomain.Quarter)
            {
                this.Value = new int[2];
                this.Value[0] = year;
                this.Value[1] = 1;
            }
            else // Day
            {
                this.Value = new int[3];
                this.Value[0] = year;
                this.Value[1] = 1;
                this.Value[2] = 1;
            }
        }

        public int MaxT
        {
            get 
            {
                // Determine the maximum value.
                int max = 1;
                if (this.Domain == TimeDomain.Day)
                {
                    max = 365;
                }
                else if (this.Domain == TimeDomain.Month)
                {
                    max = 12;
                }
                else if (this.Domain == TimeDomain.Quarter)
                {
                    max = 4;
                }
                return max;
            }
        }

        /// <summary>
        /// This converts the array into a t (or z) value in the interpolation calculations.
        /// </summary>
        public double GetCurrentT(double scaleFactor)
        {
            // Determine the maximum value.
            int max = this.MaxT;

            // Determine the current value.
            double current = 1;
            if (this.Domain == TimeDomain.Day) {
                DateTime first = new DateTime(this.Value[0], 1, 1);
                DateTime actual = new DateTime(this.Value[0], this.Value[1], this.Value[2]);
                TimeSpan difference = actual.Subtract(first);
                current = difference.TotalDays + 1;
            }
            else if (this.Domain == TimeDomain.Month) {
                current = this.Value[1];
            }
            else if (this.Domain == TimeDomain.Quarter) {
                current = this.Value[1];
            }

            // Return the percentage complete * the scaleFactor.
            return (current / max) * scaleFactor;
        }

        public void IncrementT()
        {
            if (this.Domain == TimeDomain.Day)
            {
                DateTime actual = new DateTime(this.Value[0], this.Value[1], this.Value[2]);
                actual.AddDays(1);
                this.Value[0] = actual.Year;
                this.Value[1] = actual.Month;
                this.Value[2] = actual.Day;
            }
            else if (this.Domain == TimeDomain.Month)
            {
                
            }
            else if (this.Domain == TimeDomain.Quarter)
            {
            }
        }


        public string ToString()
        {
            StringBuilder b = new StringBuilder();
            for (int i = 0; i < this.Value.Length; i++)
            {
                if (i > 0)
                {
                    b.Append(", ");
                }
                b.Append(this.Value[i]);
            }
            return b.ToString();
        }
    }
}
