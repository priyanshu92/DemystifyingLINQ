using System;
using System.Collections.Generic;

namespace DemystifyingLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(SequenceFromConsole().Any());
            //return;

            //Console.WriteLine(SequenceFromConsole().Any(x => x != null && x.Contains("hello")));
            //return;

            //Console.WriteLine(SequenceFromConsole().Count());
            //return;

            Console.WriteLine(SequenceFromConsole().Count(x => x != null && x.Contains("hello")));
            return;

            var input = SequenceFromConsole();
            foreach (var item in input)
            {
                Console.WriteLine($"\t{item}");
            }

            return;

            var sequence = GenerateSequence()
                .Where(s => s.Length < 2)
                .Select((s, index) =>
                new
                {
                    index,
                    formattedResult = s.PadLeft(20)
                });
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

        private static IEnumerable<string> SequenceFromConsole()
        {
            string text = default(string);
            while (text != "done")
            {
                yield return text;
                text = Console.ReadLine();
            }
        }
    }
}
