using System;
using System.Collections.Generic;

namespace DemystifyingLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in GenerateSequence())
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<string> GenerateSequence()
        {
            int i = 0;
            while (i++ < 100)
                yield return i.ToString();
        }
    }
}
