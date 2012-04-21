using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GISProcessing.Models
{
    public class NoTimeDomain: ITimeDomain
    {
        public string Name
        {
            get 
            {
                return "None";
            }
        }

        public DateTime DateTime
        {
            get
            {
                throw new Exception("A NoTimeDomain type does not have a value.");
            }
            set
            {
                throw new Exception("Cannot set value for NoTimeDomain type.");
            }
        }

        public double TVal
        {
            get
            {
                return 1;
            }
        }

        public double TMax
        {
            get { 
                return 1; 
            }
        }

        public void IncrementT()
        {
            throw new Exception("Cannot increment a NoTimeDomain type.");
        }

        public void SetProperty(string property, int value)
        {
            throw new Exception("Cannot set value of a NoTimeDomain type.");
        }

        public void SetT(double value)
        {
            throw new Exception("Cannot set value of a NoTimeDomain type.");
        }
    }
}
