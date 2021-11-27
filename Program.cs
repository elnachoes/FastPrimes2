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

            UInt32 PositionPrime;
            UInt32 PossiblePrimesChunkSize;

            if (args.Length > 0)
            {
                PositionPrime = Convert.ToUInt32(args[0]);
            }
            else
            {
                Console.Error.WriteLine("Error : enter a position of prime number. OPTIONAL : second argument PossiblePrimesChunkSize");
                return;
            }

            if (args.Length == 2)
            {
                PossiblePrimesChunkSize = Convert.ToUInt32(args[1]);
            }
            else
            {
                PossiblePrimesChunkSize = 1;
            }

            Watch.Start();
            
            UInt32 TargetPrime = Prime.FindNPositionPrime(PositionPrime, PossiblePrimesChunkSize);

            Watch.Stop();

            Console.WriteLine($"prime number {PositionPrime} : {TargetPrime}");
            Console.WriteLine($"{Watch.Elapsed}");
        }
    }
}