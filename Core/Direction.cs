// Point.cs

using System;
using System.Numerics;

namespace Foundations.Geometry
{
    public partial struct Direction : IEquatable<Direction>
    {
        public static readonly Direction XAxis = new Direction(Z.One, Z.Zero);

        public static readonly Direction YAxis = new Direction(Z.Zero, Z.One);

        public Direction(BigInteger x, BigInteger y)
        {
            if (x.IsZero && y.IsZero)
                throw new ArgumentException("Either X or Y must be non-zero.");

            var g = BigInteger.GreatestCommonDivisor(x, y);
            X = x / g;
            Y = y / g;
        }

        public Direction(double x, double y)
        : this(x.ToQ(), y.ToQ())
        {
        }

        public Direction((Z N, Z D) x, (Z N, Z D) y)
        : this(x.N, x.D, y.N, y.D)
        {
        }

        public Direction(Q x, Q y)
        : this(x.N, x.D, y.N, y.D)
        {
        }

        public Direction(Z px, Z qx, Z py, Z qy)
        {
            if (qx.IsZero)
                throw new ArgumentOutOfRangeException(nameof(qx));

            if (qy.IsZero)
                throw new ArgumentOutOfRangeException(nameof(qy));

            if (px.IsZero && py.IsZero)
                throw new ArgumentException($"Either {nameof(px)} or {nameof(py)} must be non-zero.");

            X = px * qy;
            Y = py * qx;
            (X, Y) = X.Reduce(Y);
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

        public Direction Opposite => -this;

        public static Direction operator -(Direction direction) => new Direction(-direction.X, -direction.Y, true);
    }
}