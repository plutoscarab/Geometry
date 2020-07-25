// GT.cs

using System;

namespace Foundations.Geometry
{
    /// <summary>
    /// GCD domain.
    /// </summary>
    public abstract class GT<T> : RT<T> where T : GT<T>, IEquatable<T>, IEquatable<RT<T>>
    {
        public abstract T Gcd(T other);

        protected abstract (T, T[]) ReduceInternal(params T[] other);

        public (T, T) Reduce(T other)
        {
            (T t, T[] ts) = ReduceInternal(other);
            return (t, ts[0]);
        }

        public (T, T, T) Reduce(T other1, T other2)
        {
            (T t, T[] ts) = ReduceInternal(other1, other2);
            return (t, ts[0], ts[1]);
        }
    }
}