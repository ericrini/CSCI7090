using System;

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
            if ((int)domain == 0)
            {
                this.Value = new int[0];
            }
            else if ((int)domain == 1) 
            {
                this.Value = new int[1];
            }
            else if ((int)domain == 2 || (int)domain == 3)
            {
                this.Value = new int[2];
            }
            else
            {
                this.Value = new int[3];
            }
        }
    }
}
