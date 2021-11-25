using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FastPrimes2 {
    public class Program {

        public static void Main(string[] args) {
            /*Console.WriteLine($" {Prime.CheckIfPrime(4)}");*/

            List<UInt32> PossiblePrimes = new List<UInt32>();
            UInt32 LastPossiblePrime = 2;
            
            Thread FetchPossiblePrimes = new Thread(() => Prime.QueuePossiblePrimes(ref PossiblePrimes, ref LastPossiblePrime));

            FetchPossiblePrimes.Start();
            FetchPossiblePrimes.Join();

            Console.WriteLine("");
        }
    }
}