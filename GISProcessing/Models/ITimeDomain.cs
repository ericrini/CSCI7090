using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GISProcessing.Models
{
    public interface ITimeDomain
    {
        /// <summary>
        /// A string to display this item in lists.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The value as a .NET date.
        /// </summary>
        DateTime DateTime { get; }

        /// <summary>
        /// The value as an integer.
        /// Ranges are like 1-12, 1-365, etc...
        /// </summary>
        double TVal { get; }

        /// <summary>
        /// The maximum possible integer value.
        /// </summary>
        double TMax { get; }

        /// <summary>
        /// Increments by one tick.
        /// </summary>
        void IncrementT();

        /// <summary>
        /// Sets the t value from a property name.
        /// </summary>
        /// <param name="property">The property like date, month, year, quarter.</param>
        /// <param name="value">The value.</param>
        void SetProperty(string property, int value);

        /// <summary>
        /// Sets the properties from a t value.
        /// Ranges are like 1-12, 1-365, etc...
        /// </summary>
        /// <param name="value"></param>
        void SetT(double value);
    }
}
