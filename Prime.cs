using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastPrimes2 {
    public static class Prime 
    {

        public static bool CheckIfPrime(UInt32 Number) 
        {
            if (Number == 2 || Number == 3 || Number == 5 || Number == 7 || Number == 11) 
            {
                return true;
            }
            if (Number % 2 == 0 || Number % 3 == 0 || Number % 5 == 0 || Number % 7 == 0 || Number % 11 == 0) 
            {
                return false;
            }
            else {
                for (UInt32 Divisor = 11; Divisor <= Math.Sqrt(Number); Divisor++) 
                {
                    //If this is true the number is not prime and the function returns false
                    if (Number % Divisor == 0) 
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        // this function builds a list of possible prime number by skipping all even numbers accept for 2
        public static void QueuePossiblePrimes(List<UInt32> PossiblePrimes, ref UInt32 LastPossiblePrime, UInt32 QueueSize)
        {

            if (LastPossiblePrime == 2)
            {
                PossiblePrimes.Add(LastPossiblePrime);
                ++LastPossiblePrime;
            }
            while (PossiblePrimes.Count < QueueSize)
            {
                PossiblePrimes.Add(LastPossiblePrime);
                LastPossiblePrime += 2;
            }
        }

        //finds Nth position prime given a Nth position and a size of an array of possible primes that can be tested for being prime on multiple threads
        public static UInt32 FindNPositionPrime(UInt32 NthPositionPrime, UInt32 PossiblePrimesThreadQueueSize)
        {
            List<UInt32> PossiblePrimes = new List<UInt32>();
            List<UInt32> FoundPrimes = new List<UInt32>();

            UInt32 LastPossiblePrime = 2;
            UInt32 CurrentPrimePosition = 1;

            //object used as a mutex
            object LockObject = new object();

            //initially filling the que of possible primes
            Prime.QueuePossiblePrimes(PossiblePrimes, ref LastPossiblePrime, PossiblePrimesThreadQueueSize);

            Console.WriteLine($"please wait while {NthPositionPrime} is calculated...");

            while (NthPositionPrime >= CurrentPrimePosition)
            {
                // if the possible primes list is empty 
                if (PossiblePrimes.Count != PossiblePrimesThreadQueueSize)
                {
                    Prime.QueuePossiblePrimes(PossiblePrimes, ref LastPossiblePrime, PossiblePrimesThreadQueueSize);
                }

                // parallel foreach that uses a thread for each possible prime in the array to test if it is prime
                var ParrallelForEachResult = Parallel.ForEach(PossiblePrimes, new ParallelOptions(), (PossibleValue) =>
                {
                    if (Prime.CheckIfPrime(PossibleValue))
                    {
                        lock (LockObject)
                        {
                            // if the number is prime add it to the list and increment the current prime position
                            FoundPrimes.Add(PossibleValue);
                            ++CurrentPrimePosition;
                        }
                    }
                });

                // clear the array of possible primes because all the primes in it have been found if there were any at all
                PossiblePrimes.Clear();
            }

            // sort the primes by value
            FoundPrimes = FoundPrimes.OrderBy(p => p).Take(((int)NthPositionPrime)).ToList();

            // return the last prime found
            return FoundPrimes[(int)NthPositionPrime - 1];
        }
    }
}