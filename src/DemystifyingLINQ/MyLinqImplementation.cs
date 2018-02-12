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

        public static int Count<T>(this IEnumerable<T> source)
        {
            int count = 0;
            foreach (var item in source)
                count++;
            return count;
        }

        public static int Count<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.Where(predicate).Count();
        }

        public static int Sum(this IEnumerable<int> source)
        {
            var sum = 0;
            foreach (var item in source)
            {
                sum += item;
            }
            return sum;
        }

        public static int Sum(this IEnumerable<int> source, int seed)
        {
            var sum = seed;
            foreach (var item in source)
            {
                sum += item;
            }
            return sum;
        }

        public static int Aggregate(this IEnumerable<int> source, Func<int, int, int> function)
        {
            var sum = 0;
            foreach (var item in source)
                sum = function(sum, item);
            return sum;
        }

        public static int Aggregate(this IEnumerable<int> source, int seed, Func<int, int, int> function)
        {
            var sum = seed;
            foreach (var item in source)
                sum = function(sum, item);
            return sum;
        }

        public static T Aggregate<T>(this IEnumerable<T> source, Func<T, T, T> function)
        {
            var sum = default(T);
            foreach (var item in source)
                sum = function(sum, item);
            return sum;
        }

        public static T Aggregate<T>(this IEnumerable<T> source, T seed, Func<T, T, T> function)
        {
            var sum = seed;
            foreach (var item in source)
                sum = function(sum, item);
            return sum;
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, Func<TAccumulate, TSource, TAccumulate> function)
        {
            var sum = default(TAccumulate);
            foreach (var item in source)
                sum = function(sum, item);
            return sum;
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> function)
        {
            var sum = seed;
            foreach (var item in source)
                sum = function(sum, item);
            return sum;
        }

        public static MyOrderedEnumerable<T, TKey> OrderBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> comparer)
            where TKey : IComparable<TKey>
        {
            return new MyOrderedEnumerable<T, TKey>(source, comparer);
        }

        public static MyOrderedEnumerable<T, TKey> OrderByDescending<T, TKey>(this IEnumerable<T> source, Func<T, TKey> comparer)
            where TKey : IComparable<TKey>
        {
            int descendingComparer(T left, T right) => comparer(right).CompareTo(comparer(left));
            return new MyOrderedEnumerable<T, TKey>(source, descendingComparer);
        }

        public static IOrderingImpl<T> ThenBy<T, TKey>(this IOrderingImpl<T> source, Func<T, TKey> comparer)
            where TKey : IComparable<TKey>
        {
            return new MyOrderedEnumerable<T, TKey>(source, comparer);
        }

        public static IOrderingImpl<T> ThenByDescending<T, TKey>(this IOrderingImpl<T> source, Func<T, TKey> comparer)
            where TKey : IComparable<TKey>
        {
            Comparison<T> descendingComparer = (left, right) => comparer(right).CompareTo(comparer(left));
            return new MyOrderedEnumerable<T, TKey>(source, descendingComparer);
        }
    }
}