using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastPrimes2 {
    public static class Prime 
    {

        public static bool CheckIfPrime(UInt32 number) 
        {
            if (number == 2 || number == 3 || number == 5 || number == 7 || number == 11) 
            {
                return true;
            }
            else if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0 || number % 7 == 0 || number % 11 == 0) 
            {
                return false;
            }
            else {
                for (UInt32 divisor = 11; divisor <= Math.Sqrt(number); divisor++) 
                {
                    //If this is true the number is not prime and the function returns false
                    if (number % divisor == 0) 
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        //both PossiblePrimes and LastPossiblePrime are initialized in main before this function executes
        public static void QueuePossiblePrimes(ref List<UInt32> PossiblePrimes,ref UInt32 LastPossiblePrime)
        {

            if (LastPossiblePrime == 2)
            {
                PossiblePrimes.Add(LastPossiblePrime);
                ++LastPossiblePrime;
            }
            while (PossiblePrimes.Count < 32)
            {
                PossiblePrimes.Add(LastPossiblePrime);
                LastPossiblePrime += 2;
            }

            Console.WriteLine();
        }
    }
}
