using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading
{
    public class ParallelPrimeNumbers
    {
        /// <summary>
        /// Activatges 'Calculations' and makes the range from 0-5000.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Calculations(0, 0);
        }

        /// <summary>
        /// Creates a range of numbers, tests if those numbers are prime numbers in parallel, writes the prime numbers and the length of time it took to aquire them to the console.
        /// </summary>
        /// <param name="min">
        /// The minimum positive number you want in your range that is a prime number.
        /// </param>
        /// <param name="max">
        /// The maximum positive number you want in your range that is a prime number.
        /// </param>
        /// /// <returns>
        /// Will return the list of prime numbers generated in parallel.
        /// </returns>
        public static int[] Calculations(uint min, uint max)
        {
            if(min > max)
            {
                throw new ArgumentOutOfRangeException(nameof(min), "Minimum number is larger than the maximum number");
            }
            else if(min == 0 && max < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(min), "If the minimum number is 0, the maximum number must have a value of 2 or greater");
            }
            else
            {
                // Cast min and max to integers so that .Range can use them.
                var source = Enumerable.Range((int)min, (int)max);

                Stopwatch stopWatch = new Stopwatch();

                stopWatch.Start();

                // This statement grabs only the numbers inside of 'source' that are prime in parallel.
                // Most of the time, the array ends up incremental, but there are cases in which one can see the numbers are out of order.
                var parallelQuery = source.AsParallel().Where(n => IsPrime(n) == true).Select(n => n);

                var result = parallelQuery.ToArray();

                stopWatch.Stop();

                // This writes out each value in the 'parallelQuery' array.
                foreach (var prime in parallelQuery)
                {
                    Console.WriteLine(prime);
                }

                Console.WriteLine("Elapsed time: {0:n0}ms", stopWatch.ElapsedMilliseconds);

                // Return an array to be used in testing.
                return result;
            }
        }

        /// <summary>
        /// Determines whether or not the given number is a prime number.
        /// </summary>
        /// <param name="number">
        /// The integer number one whishes to test to see if it is a prime number.
        /// </param>
        /// <returns>
        /// Wll return true if the given number is prime, otherwise will return false.
        /// </returns>
        public static bool IsPrime(int number)
        {
            if ((number & 1) == 0)
            {
                return (number == 2);
            }

            int limit = (int)Math.Sqrt(number);

            for (int i = 3; i <= limit; i += 2)
            {
                if ((number % i) == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
