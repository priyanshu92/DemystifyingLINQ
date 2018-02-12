using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DemystifyingLINQ
{
    public class MyOrderedEnumerable<T, TKey> : IEnumerable<T> where TKey : IComparable<TKey>
    {
        private IEnumerable<T> source;
        private Comparison<T> comparison;

        public MyOrderedEnumerable(IEnumerable<T> source, Func<T, TKey> comparer)
        {
            this.source = source;
            comparison = (a, b) => comparer(a).CompareTo(comparer(b));
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