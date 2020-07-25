// FT.cs

using System;

namespace Foundations.Geometry
{
    /// <summary>
    /// Field.
    /// </summary>
    public abstract class FT<T> : RT<T> where T : RT<T>, IEquatable<RT<T>>, IEquatable<T>
    {
        protected abstract T Div(T other);

        public static T operator /(FT<T> a, T b) => a.Div(b);
    }
}