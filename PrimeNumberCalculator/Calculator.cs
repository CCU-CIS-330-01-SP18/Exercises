using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeNumberCalculator
{

    /// <summary>
    /// Class that represents a prime number claculator with threadding functionality.  
    /// </summary>
    public class Calculator
    {

        /// <summary>
        /// Function that calculates prime numbers, not formatted for threading.
        /// </summary>
        /// <param name="initialValue">Value to begin calculation.</param>
        /// <param name="maxValue">Value to end calculation.</param>
        /// <returns>A lits of ints that are the results of the prim number check.</returns>
        public List<int> CalculatePrime(int initialValue, int maxValue)
        {
            List<int> primes = new List<int>();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = initialValue; i <= maxValue; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime == true && i > 1)
                {
                    primes.Add(i);
                }
            }
            stopwatch.Stop();

            primes.Add((int)stopwatch.ElapsedMilliseconds);
            return primes;
        }


        /// <summary>
        /// Function that calculates prime numbers, formatted for threading.
        /// </summary>
        /// <param name="initialValue">Value to begin calculation.</param>
        /// <param name="maxValue">Value to end calculation.</param>
        /// <returns>A lits of ints that are the results of the prim number check.</returns>
        public List<int> CalculatePrimeT(int initialValue, int maxValue)
        {
            List<int> primes = new List<int>();

            for (int i = initialValue; i <= maxValue; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime == true && i > 1)
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        /// <summary>
        /// Calculates prime numbers between an initial value and a max value using the Threads.
        /// </summary>
        /// <param name="initialValue">Value to begin calculation.</param>
        /// <param name="maxValue">Value to end calculation.</param>
        /// <returns>A lits of ints that are the results of the prim number check.</returns>
        public List<int> CalculatePrimeThreads(int initialValue, int maxValue)
        {
            Stopwatch stopwatch = new Stopwatch();

            List<int> primes = new List<int>();
            List<int> primes0 = new List<int>();
            List<int> primes1 = new List<int>();
            List<int> primes2 = new List<int>();
            List<int> primes3 = new List<int>();

            stopwatch.Start();
            Thread t0 = new Thread(() => primes0 = CalculatePrimeT(initialValue, (maxValue / 4) - 1));
            Thread t1 = new Thread(() => primes1 = CalculatePrimeT(maxValue / 4, (maxValue / 2 - 1)));
            Thread t2 = new Thread(() => primes2 = CalculatePrimeT(maxValue / 2, (3 * maxValue / 4) - 1));
            Thread t3 = new Thread(() => primes3 = CalculatePrimeT(3 * maxValue / 4, maxValue));
            t0.Start();
            t1.Start();
            t2.Start();
            t3.Start();
            t0.Join();
            t1.Join();
            t2.Join();
            t3.Join();
            stopwatch.Stop();


            primes.AddRange(primes0);
            primes.AddRange(primes1);
            primes.AddRange(primes2);
            primes.AddRange(primes3);
            primes.Add((int)stopwatch.ElapsedMilliseconds);

            return primes;
        }

        /// <summary>
        /// Calculates prime numbers between an initial value and a max value using the Tasks
        /// </summary>
        /// <param name="initialValue">Value to begin calculation.</param>
        /// <param name="maxValue">Value to end calculation.</param>
        /// <returns>A lits of ints that are the results of the prim number check.</returns>
        public List<int> CalculatePrimeTasks(int initialValue, int maxValue)
        {
            Stopwatch stopwatch = new Stopwatch();

            List<int> primes = new List<int>();
            List<int> primes0 = new List<int>();
            List<int> primes1 = new List<int>();
            List<int> primes2 = new List<int>();
            List<int> primes3 = new List<int>();

            stopwatch.Start();
            Task.WaitAll(
                Task.Run(() => primes0 = CalculatePrimeT(initialValue, (maxValue / 4) - 1)),
                Task.Run(() => primes1 = CalculatePrimeT(maxValue / 4, (maxValue / 2 - 1))),
                Task.Run(() => primes2 = CalculatePrimeT(maxValue / 2, (3 * maxValue / 4) - 1)),
                Task.Run(() => primes3 = CalculatePrimeT(3 * maxValue / 4, maxValue))
                );
            stopwatch.Stop();


            primes.AddRange(primes0);
            primes.AddRange(primes1);
            primes.AddRange(primes2);
            primes.AddRange(primes3);
            primes.Add((int)stopwatch.ElapsedMilliseconds);

            return primes;
        }

        /// <summary>
        /// Calculates prime numbers between an initial value and a max value using the ThreadPool
        /// </summary>
        /// <param name="initialValue">Value to begin calculation.</param>
        /// <param name="maxValue">Value to end calculation.</param>
        /// <returns>A lits of ints that are the results of the prim number check.</returns>
        public List<int> CalculatePrimeThreadPool(int initialValue, int maxValue)
        {
            Stopwatch stopwatch = new Stopwatch();

            List<int> primes = new List<int>();
            List<int> primes0 = new List<int>();
            List<int> primes1 = new List<int>();
            List<int> primes2 = new List<int>();
            List<int> primes3 = new List<int>();

            stopwatch.Start();
            CountdownEvent countdown = new CountdownEvent(4);
            ThreadPool.QueueUserWorkItem(s => { primes0 = CalculatePrimeT(initialValue, (maxValue / 4) - 1); countdown.Signal(); });
            ThreadPool.QueueUserWorkItem(s => { primes1 = CalculatePrimeT(maxValue / 4, (maxValue / 2 - 1)); countdown.Signal(); });
            ThreadPool.QueueUserWorkItem(s => { primes2 = CalculatePrimeT(maxValue / 2, (3 * maxValue / 4) - 1); countdown.Signal(); });
            ThreadPool.QueueUserWorkItem(s => { primes3 = CalculatePrimeT(3 * maxValue / 4, maxValue); countdown.Signal(); });
            countdown.Wait();
            stopwatch.Stop();


            primes.AddRange(primes0);
            primes.AddRange(primes1);
            primes.AddRange(primes2);
            primes.AddRange(primes3);
            primes.Add((int)stopwatch.ElapsedMilliseconds);

            return primes;
        }
    }
}
