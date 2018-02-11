using System;
using System.Collections.Generic;

namespace DemystifyingLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in GeneratedSequence())
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<string> GeneratedSequence()
        {
            int i = 0;
            while (i++ < 100)
                yield return i.ToString();
        }
    }
}
