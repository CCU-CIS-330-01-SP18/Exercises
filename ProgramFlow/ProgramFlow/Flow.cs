using System;
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
            return !value;
        }

        /// <summary>
        /// Returns the correct <see cref="DriverAction"/> value for each <see cref="LightColor"/> using an if-else statement.
        /// </summary>
        /// <param name="value">The <see cref="LightColor"/> for which to return a <see cref="DriverAction"/>.</param>
        /// <returns>The correct <see cref="DriverAction"/> value.</returns>
        public static DriverAction DriveSafelyIfElse(LightColor color)
        {
            var returnValue = DriverAction.Unknown;

            if (color.Equals(LightColor.Green))
            {
                returnValue = DriverAction.ProceedWithCaution;
            }
            else if (color.Equals(LightColor.Red))
            {
                returnValue = DriverAction.Stop;
            }
            else if (color.Equals(LightColor.Yellow))
            {
                returnValue = DriverAction.StopIfSafe;
            }
            return returnValue;
        }

        /// <summary>
        /// Returns the correct <see cref="DriverAction"/> value for each <see cref="LightColor"/> using a switch statement.
        /// </summary>
        /// <param name="value">The <see cref="LightColor"/> for which to return a <see cref="DriverAction"/>.</param>
        /// <returns>The correct <see cref="DriverAction"/> value.</returns>
        public static DriverAction DriveSafelySwitch(LightColor color)
        {
            switch (color)
            {
                case LightColor.Green:
                    return DriverAction.ProceedWithCaution;

                case LightColor.Red:
                    return DriverAction.Stop;

                case LightColor.Yellow:
                    return DriverAction.StopIfSafe;

                default:
                    return DriverAction.Unknown;
            }
        }

        /// <summary>
        /// Returns the sum of the specified numbers using a for loop.
        /// </summary>
        /// <param name="values">The values to aggregate.</param>
        /// <returns>The sum of the numbers.</returns>
        public static long ForSum(int[] values)
        {
            int sum = 0;

            for (int index = 0; index < values.Length; index++)
            {
                sum += values[index];
            }
            return sum;
        }

        /// <summary>
        /// Returns the sum of the specified numbers using a foreach loop.
        /// </summary>
        /// <param name="values">The values to aggregate.</param>
        /// <returns>The sum of the numbers.</returns>
        public static long ForEachSum(int[] values)
        {
            int sum = 0;

            foreach (int addend in values)
            {
                sum += addend;
            }
            return sum;
        }
    }
}
