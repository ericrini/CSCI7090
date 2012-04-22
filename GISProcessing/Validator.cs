using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GISProcessing.Models;

namespace GISProcessing
{
    class Validator
    {

        private List<Measurement> data;

        public Validator(List<Measurement> data)
        {
            this.data = data;
        }

        public void GetResult()
        {
            foreach (Measurement curr in this.data)
            {
                // Build a list of 
            }
        }

        /// <summary>
        /// Configures the validator parameters.
        /// </summary>
        private class ValidatorConfig
        {
            public int MinN;
            public int MaxN;
        }

        /// <summary>
        /// Holds multiple lists of the various datasets.
        /// </summary>
        private class ValidatorData
        {
            public List<List<Measurement>> data;
        }
    }
}
