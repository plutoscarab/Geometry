// Fraction.cs

using System;
using System.Numerics;

namespace Foundations.Geometry
{
    public partial struct Fraction
    {
        public Fraction(BigInteger p, BigInteger q)
        {
            if (q.IsZero)
                throw new ArgumentOutOfRangeException(nameof(q));

            if (p.IsZero)
            {
                P = p;
                Q = 1;
                return;
            }

            if (q.Sign < 0)
            {
                p = -p;
                q = -q;
            }
            
            if (!q.IsOne)
            {
                var g = BigInteger.GreatestCommonDivisor(p, q);
                p /= g;
                q /= g;
            }

            P = p;
            Q = q;
        }

        public Fraction((BigInteger P, BigInteger Q) fraction)
        : this(fraction.P, fraction.Q)
        {
        }

        public Fraction(double d)
        : this(d.ToFraction())
        {
        }

        public static Fraction operator +(Fraction a, Fraction b) => a.Q == b.Q ? new Fraction(a.P + b.P, a.Q) : new Fraction(a.P * b.Q + b.P * a.Q, a.Q * b.Q);

        public static Fraction operator -(Fraction a, Fraction b) => a.Q == b.Q ? new Fraction(a.P - b.P, a.Q) : new Fraction(a.P * b.Q - b.P * a.Q, a.Q * b.Q);

        public bool IsZero => P.IsZero;

        public static Fraction operator -(Fraction fraction) => new Fraction(-fraction.P, fraction.Q, true);

        public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.P * b.P, a.Q * b.Q);

        public static implicit operator Fraction(double d) => new Fraction(d);
    }
}