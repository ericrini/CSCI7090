using System;
using System.Text;

namespace GISProcessing.Models
{
    public class Measurement
    {
        private int id;
        public int ID
        {
            get {return this.id;}
            set { this.id = value; }
        }

        private float x;
        public float X
        {
            get {return this.x;}
            set { this.x = value; }
        }

        private float y;
        public float Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        private float value;
        public float Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        private Time time;
        public Time Time
        {
            get { return this.time; }
            set { this.time = value; }
        }

        public Measurement(Time time)
        {
            this.id = 0;
            this.x = 0;
            this.y = 0;
            this.value = 0;
            this.time = time;
        }

        public float[] ToArray()
        {
            int length = 4 + this.Time.Value.Length;
            float[] value = new float[length];
            value[0] = this.ID;
            value[1] = this.X;
            value[2] = this.Y;
            value[3] = this.Value;

            for (int i = 0; i < this.Time.Value.Length; i++)
            {
                value[3 + i] = this.Time.Value[i];
            }

            return value;
        }

        public string ToString()
        {
            StringBuilder b = new StringBuilder();
            float[] array = this.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0)
                {
                    b.Append(", ");
                }
                b.Append(array[i]);
            }
            return b.ToString();
        }
    }
}
