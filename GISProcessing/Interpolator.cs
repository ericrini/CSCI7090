using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GISProcessing.Models;
using System.Threading;

namespace GISProcessing
{
    public class Interpolator
    {
        // Report progress.
        public double Max;
        public int Current;

        private List<Measurement> known; // List of known points (with time domain and value initialized).
        private List<Measurement> missing; // List of unknown points (time domain will be replaced by time domain of known data set).
        private int nearest; // The n (and k values).
        private double exponent; // The p value.
        private double timeCoefficient; // Multiplies by all t values... allowing to investigate encoding as intever vs decimal. 
                                        // For example if a time domain has a range 1 - 365 and the t value is 32 and 
                                        // the time coefficient is 0.1 then the t value will represent as 3.2 on a scale of 0.01 to 3.65.

        public Interpolator(List<Measurement> known, List<Measurement> missing, int nearest, double exponent, double timeCoefficient)
        {
            this.Max = missing.Count * known[0].Time.TMax;
            this.Current = 0;
            this.known = known;
            this.missing = missing;
            this.nearest = nearest;
            this.exponent = exponent;
            this.timeCoefficient = timeCoefficient;
        }

        public List<Measurement> GetResults()
        {
            List<Measurement> results = new List<Measurement>();

            // Iterate over missing measurements.
            foreach (Measurement currMissing in missing)
            {
                // We implement a ThreadPool here to maximize CPU core utilization.
                InnerLoopState state = new InnerLoopState();
                state.currMissing = currMissing;
                state.results = results;
                ThreadPool.QueueUserWorkItem(new WaitCallback(InnerLoop), (object)state);
            }

            return results;
        }

        private void InnerLoop(object state)
        {
            // Need to extract state values from the state package object.
            InnerLoopState openState = (InnerLoopState)state;
            Measurement currMissing = openState.currMissing;
            List<Measurement> results = openState.results;

            // This is the time domain of the KNOWN values.
            // We are trying to calculate every unknown element for every value bewteen t=0 and tmax of this time domain.
            ITimeDomain t = (ITimeDomain)Activator.CreateInstance(this.known[0].Time.GetType());
            t.SetProperty("year", this.known[0].Time.DateTime.Year); // Set the year to the year of the first known item. 
                                                                     // No example data sets span multiple years. This is kindof undefined behavior.

            // Iterate over all t values in this time domain.
            for (int i = 0; i < t.TMax; i++)
            {
                currMissing.Time = t; // Use the known time domain as the time domain of the missing data set.
                List<Measurement> nearest = this.calcNearest(currMissing); // Get the n nearest known values.

                // Iterate over the nearset known values and sum up their lambdas.
                double sum = 0.0d;
                foreach (Measurement currNearest in nearest)
                {
                    double numerator = this.calcLambdaNumerator(currNearest, currMissing);
                    double denominator = this.calcLambdaDenominator(nearest, currMissing);
                    double lambda = numerator / denominator;
                    double value = lambda * currNearest.Value;
                    sum += value;
                }

                // We can build a single output model now.
                Measurement output = new Measurement();
                output.ID = currMissing.ID;
                output.X = currMissing.X;
                output.Y = currMissing.Y;
                output.Time = (ITimeDomain)Activator.CreateInstance(this.known[0].Time.GetType());
                output.Time.SetT(t.TVal);
                output.Time.SetProperty("year", t.DateTime.Year);
                output.Value = (float)sum;
                results.Add(output); // We now store this model in a new list.

                t.IncrementT(); // Increment the time domain value.
                this.Current++; // Report row increment... this is how the progressbar knows.
            }
        }

        /// <summary>
        /// HELPER: Finds disatances... used to find di (and dk) values.
        /// 
        /// NOTE: This is currently the least optimized function according to the profiler... I wonder if theres a better 3rd party math library for .NET?
        /// </summary>
        /// <returns></returns>
        private double calcD(Measurement nearest, Measurement missing)
        {
            return Math.Sqrt(
                Math.Pow(nearest.X - missing.X, 2) +
                Math.Pow(nearest.Y - missing.Y, 2) +

                // Notice the TVal is multipled by a scale factor... to allow us control over the range.
                // IE 1-365 or 0.01 - 3.65.
                Math.Pow(this.timeCoefficient * nearest.Time.TVal - this.timeCoefficient * missing.Time.TVal, 2)
            );
        }

        /// <summary>
        /// Finds the n known measurements with the smallest euclidian distance to x, y, t in nearly O(n) time.
        /// </summary>
        private List<Measurement> calcNearest(Measurement measure)
        {
            DistanceMeasurement[] results = new DistanceMeasurement[this.nearest];
            foreach (Measurement curr in this.known)
            {
                double distance = this.calcD(curr, measure);

                // Test if this is a new smallest value.
                bool shift = false;
                DistanceMeasurement shifted = null;
                for (int i = 0; i < results.Length; i++)
                {
                    // A smaller value was found continue shifting the array.
                    if (shift)
                    {
                        DistanceMeasurement temp = results[i];
                        results[i] = shifted;
                        shifted = temp;
                    }
                    // Test if this is one of the first n elements.
                    else if (results[i] == null)
                    {
                        // Build a DistanceMeasurement for this value.
                        DistanceMeasurement dm = new DistanceMeasurement();
                        dm.Measurement = curr;
                        dm.Distance = distance;

                        results[i] = dm;
                    }
                    // Test if value smaller than current element.
                    else if (distance < results[i].Distance)
                    {
                        // Build a DistanceMeasurement for this value.
                        DistanceMeasurement dm = new DistanceMeasurement();
                        dm.Measurement = curr;
                        dm.Distance = distance;

                        // Swap in this value.
                        shifted = results[i];
                        results[i] = dm;

                        // Enter shift mode.
                        shift = true;
                    }
                }
            }

            // Convert from DistanceMeasurement to Measurement.
            List<Measurement> nearest = new List<Measurement>();
            foreach (DistanceMeasurement curr in results)
            {
                nearest.Add(curr.Measurement);
            }

            return nearest; 
        }

        /// <summary>
        /// HELPER: Finds the IDW lambda coefficient for element i.
        /// </summary>
        /// <returns></returns>
        private double calcLambdaNumerator(Measurement nearest, Measurement missing)
        {
            double distance = this.calcD(nearest, missing);
            return Math.Pow(1 / distance, this.exponent);
        }

        /// <summary>
        /// HELPER: Finds the IDW lambda denominator.
        /// </summary>
        /// <returns></returns>
        private double calcLambdaDenominator(List<Measurement> nearest, Measurement missing)
        {
            double sum = 0;
            foreach (Measurement currNearest in nearest)
            {
                sum += this.calcLambdaNumerator(currNearest, missing);
            }
            return sum;
        }

        /// <summary>
        /// INTERNAL CLASS: Used internally to represent a measurement with a known distance from another measurement.
        /// </summary>
        private class DistanceMeasurement : IComparable
        {
            public Measurement Measurement;
            public double Distance;

            // Need to implement IComparable for list sorting.
            public int CompareTo(object obj)
            {
                if (obj is DistanceMeasurement)
                {
                    DistanceMeasurement dm = (DistanceMeasurement)obj;
                    return this.Distance.CompareTo(dm.Distance);
                }
                else
                {
                    throw new Exception("Illegal comparison.");
                }
            }
        }

        /// <summary>
        /// INTERNAL CLASS: Used to transfer the loop state to the inner loop thread.
        /// </summary>
        private class InnerLoopState
        {
            public Measurement currMissing;
            public List<Measurement> results;
        }
    }
}
