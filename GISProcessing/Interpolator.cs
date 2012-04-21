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

        private List<Measurement> known;
        private List<Measurement> missing;
        private int nearest;
        private double exponent;

        public Interpolator(List<Measurement> known, List<Measurement> missing, int nearest, double exponent)
        {
            this.Max = missing.Count * known[0].Time.TMax;
            this.Current = 0;
            this.known = known;
            this.missing = missing;
            this.nearest = nearest;
            this.exponent = exponent;
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
            // We initialize it to the first period of the year of the first known element.
            ITimeDomain t = (ITimeDomain)Activator.CreateInstance(this.known[0].Time.GetType());
            t.SetT(1);

            // Iterate over all t values in this time domain.
            for (int i = 0; i < t.TMax; i++)
            {
                currMissing.Time = t; // Copy the current time value onto missing (the missing values have no time domain - we need to add one based off the know values).
                List<Measurement> nearest = this.calcNearest(currMissing); // Get the n nearest known values. This is a massive performance hit...

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
                output.Value = (float)sum;
                results.Add(output); // We now store this model in a new list.

                t.IncrementT(); // Increment the time domain value.
                this.Current++;
            }
        }

        /// <summary>
        /// HELPER: Finds disatances... used to find di (and dk) values.
        /// </summary>
        /// <returns></returns>
        private double calcD(Measurement nearest, Measurement missing)
        {
            return Math.Sqrt(
                Math.Pow(nearest.X - missing.X, 2) +
                Math.Pow(nearest.Y - missing.Y, 2) +
                Math.Pow(nearest.Time.TVal - missing.Time.TVal, 2)
            );
        }

        /// <summary>
        /// Finds the n known measurements with the smallest euclidian distance to x, y.
        /// </summary>
        private List<Measurement> calcNearest(Measurement measure)
        {
            // Create a better data structure for this.
            List<DistanceMeasurement> measures = new List<DistanceMeasurement>();
            foreach (Measurement curr in this.known)
            {
                DistanceMeasurement dm = new DistanceMeasurement();
                dm.Measurement = curr;
                measures.Add(dm);
            }

            // Calculate the euclidian distance from measure for each known point.
            foreach (DistanceMeasurement curr in measures)
            {
                curr.Distance = this.calcD(curr.Measurement, measure);
            }
            measures.Sort(); // Sort the array from smallest to largest using IComparable logic below.
            
            // Return the top n Measurements
            List<Measurement> result = new List<Measurement>();
            foreach (DistanceMeasurement curr in measures.Take(this.nearest))
            {
                result.Add(curr.Measurement);
            }
            return result; 
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
