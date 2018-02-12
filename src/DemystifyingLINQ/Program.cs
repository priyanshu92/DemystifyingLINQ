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

            //Console.WriteLine(SequenceFromConsole().Any(x => x.Contains("hello")));
            //return;

            //Console.WriteLine(SequenceFromConsole().Count());
            //return;

            //Console.WriteLine(SequenceFromConsole().Count(x => x.Contains("hello")));
            //return;

            //Console.WriteLine(SequenceFromConsole().Select(x => int.Parse(x)).Sum());
            //return;

            //Console.WriteLine(SequenceFromConsole().Select(x => int.Parse(x)).Sum(10));
            //return;

            //var sum = SequenceFromConsole().Select(x => int.Parse(x))
            //    .Aggregate((partialSum, item) => partialSum + item);
            //Console.WriteLine(sum);
            //return;

            //var sum = SequenceFromConsole().Select(x => int.Parse(x))
            //    .Aggregate(10, (partialSum, item) => partialSum + item);
            //Console.WriteLine(sum);
            //return;

            //var sum = SequenceFromConsole()
            //    .Aggregate<string>("Comma Separated", (existingString, item) => $"{existingString}, {item}");
            //Console.WriteLine(sum);
            //return;

            var sum = SequenceFromConsole().Select(x => int.Parse(x))
                .Aggregate("Comma Separated", (existingString, item) => $"{existingString}, {item}");
            Console.WriteLine(sum);
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
                if (text != null)
                    yield return text;
                text = Console.ReadLine();
            }
        }
    }
}
