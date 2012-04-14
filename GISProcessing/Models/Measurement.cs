using System;

namespace GISProcessing.Models
{
    public class Measurement
    {
        
        public int ID;
        public float X;
        public float Y;
        public float Value;
        public Time Time;

        public Measurement(Time time)
        {
            this.ID = 0;
            this.X = 0;
            this.Y = 0;
            this.Value = 0;
            this.Time = time;
        }
    }
}
