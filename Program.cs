using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FastPrimes2 {
    public class Program {

        public static void Main(string[] args) {

            var Watch = new Stopwatch();
            Watch.Start();

            const UInt32 PossiblePrimesQueueSize = 10000;

            List<UInt32> PossiblePrimes = new List<UInt32>();
            List<UInt32> FoundPrimes = new List<UInt32>();
            
            UInt32 NthPositionPrime = 100;
            UInt32 LastPossiblePrime = 2;
            UInt32 CurrentPrimePosition = 1;

            object LockObject = new object();

            Prime.QueuePossiblePrimes(PossiblePrimes, ref LastPossiblePrime, PossiblePrimesQueueSize);

            while (NthPositionPrime >= CurrentPrimePosition)
            {

                if (PossiblePrimes.Count != PossiblePrimesQueueSize)
                {
                    Prime.QueuePossiblePrimes(PossiblePrimes, ref LastPossiblePrime, PossiblePrimesQueueSize);
                }

                var ParrallelForEachResult = Parallel.ForEach(PossiblePrimes, new ParallelOptions(), (PossibleValue) =>
                {
                    if (Prime.CheckIfPrime(PossibleValue))
                    {
                        lock (LockObject)
                        {
                            FoundPrimes.Add(PossibleValue);
                            ++CurrentPrimePosition;
                        }
                    }
                });

                PossiblePrimes.Clear();
            }

            FoundPrimes = FoundPrimes.OrderBy(p => p).Take(((int)NthPositionPrime)).ToList();

            Watch.Stop();
            Console.WriteLine($"prime number {NthPositionPrime} : {FoundPrimes[(int)NthPositionPrime - 1]}");
            Console.WriteLine($"{Watch.Elapsed}");
        }
    }
}