using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GISProcessing.Models
{
    public class MonthTimeDomain: ITimeDomain
    {
        public string Name
        {
            get { return "Monthly"; }
        }

        public DateTime DateTime
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double TVal
        {
            get { throw new NotImplementedException(); }
        }

        public double TMax
        {
            get { throw new NotImplementedException(); }
        }

        public void IncrementT()
        {
            throw new NotImplementedException();
        }

        public void SetProperty(string property, int value)
        {
            throw new NotImplementedException();
        }

        public void SetT(double value)
        {
            throw new NotImplementedException();
        }
    }
}
