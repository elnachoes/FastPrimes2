using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FastPrimes2
{
    public static class CachePrimes
    {
        public static void Cache(List<UInt32> FoundPrimes, UInt32 TargetPrime)
        {
            FoundPrimes = FoundPrimes.OrderBy(p => p).Take(((int)TargetPrime)).ToList();
            TextWriter textWriter = new StreamWriter("CachedPrimes.txt");
            foreach (var Prime in FoundPrimes)
            {
                textWriter.WriteLine(Prime);
            }
            textWriter.Close();
        }

        public static List<UInt32> Load()
        {
            List<UInt32> CachePrimes = new List<UInt32>();
            TextReader textReader = new StreamReader("CachedPrimes.txt");
            while (textReader.ReadLine() != null)
            {
                CachePrimes.Add(Convert.ToUInt32(textReader.ReadLine()));
            }
            return CachePrimes;
        }
    }
}
