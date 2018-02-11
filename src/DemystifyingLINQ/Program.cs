using System;
using System.Collections.Generic;

namespace DemystifyingLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = GenerateSequence()
                .Where(s => s.Length < 2);
            foreach (var item in sequence)
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
