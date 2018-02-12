using System;
using System.Collections.Generic;

namespace DemystifyingLINQ
{
    public static class MyLinqImplementation
    {        
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            Console.WriteLine("Start: Using Custom Where Implementation");
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
            Console.WriteLine("End: Using Custom Where Implementation");
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            Console.WriteLine("Start: Using Custom Select Implementation");
            foreach (TSource item in source)
            {
                yield return selector(item);
            }
            Console.WriteLine("End: Using Custom Select Implementation");
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            Console.WriteLine("Start: Using Custom Select Implementation");
            int index = 0;
            foreach (TSource item in source)
            {
                yield return selector(item, index++);
            }
            Console.WriteLine("End: Using Custom Select Implementation");
        }

        public static bool Any<T>(this IEnumerable<T> source)
        {
            return source.GetEnumerator().MoveNext();
        }

        public static bool Any<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.Where(predicate).GetEnumerator().MoveNext();
        }
    }
}