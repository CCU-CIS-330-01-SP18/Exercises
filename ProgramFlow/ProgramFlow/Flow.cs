﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFlow
{
    /// <summary>
    /// Defines methods that demonstrate decision and looping structures.
    /// </summary>
    public static class Flow
    {
        /// <summary>
        /// Returns the inverse value for a boolean.
        /// </summary>
        /// <param name="value">The <see cref="bool"/> value to invert.</param>
        /// <returns><b>true</b> if <paramref name="value"/> is <b>false</b>; <b>false</b> if <paramref name="value"/> is <b>true</b>.</returns>
        public static bool InvertBoolean(bool value)
        {
            // Inverts the value.
            return !value;
        }

        /// <summary>
        /// Returns the correct <see cref="DriverAction"/> value for each <see cref="LightColor"/> using an if-else statement.
        /// </summary>
        /// <param name="value">The <see cref="LightColor"/> for which to return a <see cref="DriverAction"/>.</param>
        /// <returns>The correct <see cref="DriverAction"/> value.</returns>
        public static DriverAction DriveSafelyIfElse(LightColor color)
        {
            // An if-else statement that returns the correct values.
            if (color == LightColor.Green)
            {
                return (DriverAction.ProceedWithCaution);
            }
            else if (color == LightColor.Yellow)
            {
                return (DriverAction.StopIfSafe);
            }
            else if (color == LightColor.Red)
            {
                return (DriverAction.Stop);
            }
            else
            {
                return (DriverAction.Unknown);
            }
        }

        /// <summary>
        /// Returns the correct <see cref="DriverAction"/> value for each <see cref="LightColor"/> using a switch statement.
        /// </summary>
        /// <param name="value">The <see cref="LightColor"/> for which to return a <see cref="DriverAction"/>.</param>
        /// <returns>The correct <see cref="DriverAction"/> value.</returns>
        public static DriverAction DriveSafelySwitch(LightColor color)
        {
            // A switch statement that returns the correct values.
            switch (color)
            {
                case LightColor.Green:
                    return (DriverAction.ProceedWithCaution);
                case LightColor.Yellow:
                    return (DriverAction.StopIfSafe);
                case LightColor.Red:
                    return (DriverAction.Stop);
                default:
                    return (DriverAction.Unknown);
            }
        }

        /// <summary>
        /// Returns the sum of the specified numbers using a for loop.
        /// </summary>
        /// <param name="values">The values to aggregate.</param>
        /// <returns>The sum of the numbers.</returns>
        public static long ForSum(int[] values)
        {
            // Holds the sum total
            int total = 0;

            // A for loop that calculates the sum.
            for (int numberIndex = 0; numberIndex < values.Length; numberIndex++)
            {
                total += values[numberIndex];
            }

            return total;
        }

        /// <summary>
        /// Returns the sum of the specified numbers using a foreach loop.
        /// </summary>
        /// <param name="values">The values to aggregate.</param>
        /// <returns>The sum of the numbers.</returns>
        public static long ForEachSum(int[] values)
        {
            // Holds the sum total.
            int total = 0;

            // A foreach loop that calculates the sum.
            foreach (int numberIndex in values){
                total += numberIndex;  
            }

            return total;
        }
    }
}
