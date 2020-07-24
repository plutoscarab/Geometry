// Point.cs

using System;
using System.Numerics;

namespace Foundations.Geometry
{
    public partial struct Direction : IEquatable<Direction>
    {
        public static readonly Direction XAxis = new Direction(1d, 0d);

        public static readonly Direction YAxis = new Direction(0d, 1d);

        public Direction(BigInteger x, BigInteger y)
        {
            if (x.IsZero && y.IsZero)
                throw new ArgumentException("Either X or Y must be non-zero.");

            var g = BigInteger.GreatestCommonDivisor(x, y);
            X = x / g;
            Y = y / g;
        }

        public Direction(double x, double y)
        : this(x.ToFraction(), y.ToFraction())
        {
        }

        public Direction((BigInteger P, BigInteger Q) x, (BigInteger P, BigInteger Q) y)
        : this(x.P, x.Q, y.P, y.Q)
        {
        }

        public Direction(Fraction x, Fraction y)
        : this(x.P, x.Q, y.P, y.Q)
        {
        }

        public Direction(BigInteger px, BigInteger qx, BigInteger py, BigInteger qy)
        {
            if (qx.IsZero)
                throw new ArgumentOutOfRangeException(nameof(qx));

            if (qy.IsZero)
                throw new ArgumentOutOfRangeException(nameof(qy));

            if (px.IsZero && py.IsZero)
                throw new ArgumentException($"Either {nameof(px)} or {nameof(py)} must be non-zero.");

            X = px * qy;
            Y = py * qx;
            var g = BigInteger.GreatestCommonDivisor(X, Y);
            X /= g;
            Y /= g;
        }

        public Direction(Vector vector)
        : this(vector.X * vector.W, vector.Y * vector.W)
        {
        }

        public Direction(Ray ray)
        : this(ray.Direction.X, ray.Direction.Y, true)
        {
        }

        public Direction(Line line)
        : this(line.B, -line.A)
        {
        }

        public Direction(Segment segment)
        : this(segment.Target - segment.Source)
        {
        }

        public override string ToString()
        {
            var angle = Math.Atan2((double)Y, (double)X) * 180 / Math.PI;
            return angle + "°";
        }

        public (double, double) ToDouble()
        {
            var x = (double)X;
            var y = (double)Y;
            var r = Math.Sqrt(x * x + y * y);
            return (x / r, y / r);
        }
    }
}