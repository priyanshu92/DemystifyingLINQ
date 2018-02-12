using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DemystifyingLINQ
{
    public class MyOrderedEnumerable<T, TKey> : IOrderingImpl<T> where TKey : IComparable<TKey>
    {
        private IEnumerable<T> source;
        private Comparison<T> comparison;

        public MyOrderedEnumerable(IEnumerable<T> source, Func<T, TKey> comparer)
        {
            this.source = source;
            comparison = (a, b) => comparer(a).CompareTo(comparer(b));
        }

        public MyOrderedEnumerable(IOrderingImpl<T> source, Func<T, TKey> comparer)
        {
            this.source = source;
            comparison = (a, b) =>
            {
                var originalComparison = source.CompareTo(a, b);
                if (originalComparison != 0)
                    return originalComparison;
                return comparer(a).CompareTo(comparer(b));
            };
        }

        public IEnumerable<T> OriginalSequence => source;

        public int CompareTo(T left, T right)
        {
            return comparison(left, right);
        }

        public IEnumerator<T> GetEnumerator()
        {
            //very poor implementatio but works
            var sorted = source.ToList();
            sorted.Sort(comparison);
            return sorted.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}