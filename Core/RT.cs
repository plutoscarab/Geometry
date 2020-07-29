// RT.cs

using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace Foundations.Geometry
{
    /// <summary>
    /// Integral domain.
    /// </summary>
    public abstract class RT<T> where T : RT<T>
    {
        protected abstract T Add(T other);

        protected abstract T Sub(T other);

        protected abstract T Neg();

        protected abstract T Mul(T other);

        public abstract T Abs();

        public abstract bool IsZero { get; }

        public abstract bool IsOne { get; }

        public abstract bool IsPositive { get; }

        public abstract bool IsNegative { get; }

        public abstract int Sign { get; }

        public abstract double ToDouble();

        public static T operator +(RT<T> a, T b) => a.Add(b);

        public static T operator -(RT<T> a, T b) => a.Sub(b);

        public static T operator -(RT<T> r) => r.Neg();

        public static T operator *(RT<T> a, T b) => a.Mul(b);

        public static explicit operator double(RT<T> r) => r.ToDouble();
    }
}