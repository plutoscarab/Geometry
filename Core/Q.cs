// Q.cs

using System;
using System.Diagnostics;

namespace Foundations.Geometry
{
    public sealed partial class Q : FT<Q>
    {
        public static readonly Q Zero = new Q(Z.Zero, Z.One, true);

        public static readonly Q One = new Q(Z.One, Z.One, true);

        public Q(Z n, Z d)
        {
            if (d.IsZero)
                throw new ArgumentOutOfRangeException(nameof(d));

            if (n.IsZero)
            {
                N = Z.Zero;
                D = Z.One;
                return;
            }

            if (d.Sign < 0)
            {
                n = -n;
                d = -d;
            }
            
            if (!d.IsOne)
            {
                (n, d) = n.Reduce(d);
            }

            N = n;
            D = d;
        }

        public Q((Z N, Z D) fraction)
        : this(fraction.N, fraction.D)
        {
        }

        public Q(Q q)
        : this(q.N, q.D, true)
        {
        }

        public Q(double d)
        : this(d.ToQ())
        {
        }

        private Q(Z N, Z D, bool _)
        {
            this.N = N;
            this.D = D;
        }

        public Z N { get; }

        public Z D { get; }

        public override bool Equals(object obj) => throw new InvalidOperationException($"Values of type {nameof(Q)} cannot be compared for semantic equality.");

        private static readonly int SessionHash = HashCode.Combine("Q", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => HashCode.Combine(SessionHash, N, D);

        static bool warn = true;

        public static bool operator ==(Q a, Q b)
        {
            if (warn)
            {
                warn = false;

                if (System.Diagnostics.Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                if (System.Diagnostics.Debugger.IsLogging())
                {
                    Debug.WriteLine($"Values of type {nameof(Q)} should not be compared for equality. Only use this operator for reference equality.");
                }
            }

            return ReferenceEquals(a, b);
        }

        public static bool operator !=(Q a, Q b) => !(a == b);
    
        public override bool IsZero => N.IsZero;

        public override bool IsOne => N.IsOne && D.IsOne;

        public override bool IsPositive => N.IsPositive;

        public override bool IsNegative => N.IsNegative;

        public override int Sign => N.Sign;

        public static implicit operator Q(double d) => new Q(d);

        public static implicit operator Q(Z z) => new Q(z, Z.One);

        public override string ToString()
        {
            return base.ToString();
        }

        protected override Q Add(Q other)
        {
            if (D == other.D)
            {
                return new Q(N + other.N, D);
            }

            return new Q(N * other.D + other.N * D, D * other.D);
        }
        
        protected override Q Sub(Q other)
        {
            if (D == other.D)
            {
                return new Q(N - other.N, D);
            }

            return new Q(N * other.D - other.N * D, D * other.D);
        }

        protected override Q Neg() => new Q(-N, D, true);

        protected override Q Mul(Q other) => new Q(N * other.N, D * other.D);

        protected override Q Div(Q other) => new Q(N * other.D, D * other.N);

        public override Q Abs() => new Q(N.Abs(), D, true);

        public override double ToDouble() => N.ToDouble() / D.ToDouble();

        public bool Equals(RT<Q> other) => Equals(other as Q);
    }
}