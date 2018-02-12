using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemystifyingLINQ
{
    public interface IOrderingImpl<T> : IEnumerable<T>
    {
        int CompareTo(T left, T right);

        IEnumerable<T> OriginalSequence { get; }
    }
}
