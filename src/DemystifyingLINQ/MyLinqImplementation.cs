using System;
using System.Collections.Generic;

namespace DemystifyingLINQ
{
    public static class MyLinqImplementation
    {        
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}