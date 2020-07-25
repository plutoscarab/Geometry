// Q.cs

using System;
using System.Numerics;

namespace Foundations.Geometry
{
    public sealed partial class Q : FT<Q>, IEquatable<RT<Q>>
    {
        public static readonly Q Zero = 0;

        public static readonly Q One = 1;

        public Q(Z p, Z q)
        {
            if (q.IsZero)
                throw new ArgumentOutOfRangeException(nameof(q));

            if (p.IsZero)
            {
                N = Z.Zero;
                D = Z.One;
                return;
            }

            if (q.Sign < 0)
            {
                p = -p;
                q = -q;
            }
            
            if (!q.IsOne)
            {
                (p, q) = p.Reduce(q);
            }

            N = p;
            D = q;
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