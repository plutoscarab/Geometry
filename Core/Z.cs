// Z.cs

using System;
using System.Numerics;
using System.Linq;

namespace Foundations.Geometry
{
    /// <summary>
    /// Integer.
    /// </summary>
    public sealed class Z : GT<Z>, IEquatable<Z>, IEquatable<RT<Z>>
    {
        public static readonly Z Zero = 0;

        public static readonly Z One = 1;

        private BigInteger n;

        public Z()
        {
            n = BigInteger.Zero;
        }

        public override bool IsZero => n.IsZero;

        public override bool IsOne => n.IsOne;

        public override bool IsPositive => n.Sign > 0;

        public override bool IsNegative => n.Sign < 0;

        public override int Sign => n.Sign;

        private static readonly Z One_ = new Z(BigInteger.One);

        public Z(long n)
        {
            this.n = n;
        }

        public static implicit operator Z(long n) => new Z(n);

        public Z(BigInteger n)
        {
            this.n = n;
        }

        public static implicit operator Z(BigInteger n) => new Z(n);

        protected override Z Add(Z other) => new Z(n + other.n);

        protected override Z Sub(Z other) => new Z(n - other.n);

        protected override Z Neg() => new Z(-n);

        protected override Z Mul(Z other) => new Z(n * other.n);

        public override bool Equals(object obj) => obj is Z z && Equals(z);

        public override int GetHashCode() => n.GetHashCode();

        public override string ToString() => n.ToString();

        public bool Equals(Z other) => n.Equals(other.n);

        public override Z Gcd(Z other) => new Z(BigInteger.GreatestCommonDivisor(n, other.n));

        protected override (Z, Z[]) ReduceInternal(params Z[] other)
        {
            var g = this;

            foreach (var o in other)
            {
                g = g.Gcd(o);

                if (g.IsOne)
                {
                    return (this, other);
                }
            }

            return (n / g.n, other.Select(o => new Z(o.n / g.n)).ToArray());
        }

        public bool Equals(RT<Z> other) => Equals(other as Z);

        public override double ToDouble() => (double)n;

        public override Z Abs() => new Z(BigInteger.Abs(n));

        public static bool operator ==(Z a, Z b) => a.Equals(b);

        public static bool operator !=(Z a, Z b) => !a.Equals(b);
    }
}