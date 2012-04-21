using System;
using System.Text;

namespace GISProcessing.Models
{
    public class Measurement
    {
        private long id;
        public long ID
        {
            get {return this.id;}
            set { this.id = value; }
        }

        private double x;
        public double X
        {
            get {return this.x;}
            set { this.x = value; }
        }

        private double y;
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        private double value;
        public double Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        private ITimeDomain time;
        public ITimeDomain Time
        {
            get { return this.time; }
            set { this.time = value; }
        }

        public Measurement()
        {
            this.id = 0;
            this.x = 0;
            this.y = 0;
            this.value = 0;
            this.time = new NoTimeDomain();
        }
    }
}
