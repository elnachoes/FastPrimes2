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
            if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0 || number % 7 == 0 || number % 11 == 0) 
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

        public static List<UInt32> SortFoundPrimes(List<UInt32> FoundPrimes)
        {
            List<UInt32> Sort = new List<UInt32>();
            foreach (UInt32 prime in FoundPrimes)
            {

            }
            return Sort;
        }
    }
}
