// Point.cs

using System;
using System.Numerics;

namespace Foundations.Geometry
{
    public partial struct Point : IEquatable<Point>
    {
        public const int Dimensions = 0;

        public static readonly Point Origin = new Point(0, 0);

        public Point(BigInteger x, BigInteger y, BigInteger w)
        {
            if (w.IsZero)
                throw new ArgumentOutOfRangeException(nameof(w));

            if (w.Sign < 0)
            {
                x = -x;
                y = -y;
                w = -w;
            }

            if (!w.IsOne)
            {
                var g = BigInteger.GreatestCommonDivisor(w, BigInteger.GreatestCommonDivisor(x, y));

                if (!g.IsOne)
                {
                    x /= g;
                    y /= g;
                    w /= g;
                }
            }
            
            X = x;
            Y = y;
            W = w;
        }

        public Point(double x, double y)
        : this(x.ToFraction(), y.ToFraction())
        {
        }

        public Point((BigInteger P, BigInteger Q) x, (BigInteger P, BigInteger Q) y)
        : this(x.P, x.Q, y.P, y.Q)
        {
        }

        public Point(Fraction x, Fraction y)
        : this(x.P, x.Q, y.P, y.Q)
        {
        }

        public Point(BigInteger px, BigInteger qx, BigInteger py, BigInteger qy)
        {
            if (qx == qy)
            {
                W = qx;
            }
            else
            {
                W = qx * qy;
                px *= qy;
                py *= qx;
            }

            var g = BigInteger.GreatestCommonDivisor(W, BigInteger.GreatestCommonDivisor(px, py));
            X = px / g;
            Y = py / g;
            W /= g;
        }

        public static Point operator +(Point point, Vector vector)
        {
            var x = new Fraction(point.X, point.W) + new Fraction(vector.X, vector.W);
            var y = new Fraction(point.Y, point.W) + new Fraction(vector.Y, vector.W);
            return new Point(x, y);
        }

        public static Point operator -(Point point, Vector vector)
        {
            var x = new Fraction(point.X, point.W) - new Fraction(vector.X, vector.W);
            var y = new Fraction(point.Y, point.W) - new Fraction(vector.Y, vector.W);
            return new Point(x, y);
        }

        public static Vector operator -(Point a, Point b)
        {
            var x = new Fraction(a.X, a.W) - new Fraction(b.X, b.W);
            var y = new Fraction(a.Y, a.W) - new Fraction(b.Y, b.W);
            return new Vector(x, y);
        }

        public override string ToString() => $"{(double)X / (double)W}, {(double)Y / (double)W}";

        public (double, double) ToDouble()
        {
            var w = (double)W;
            return ((double)X / w, (double)Y / w);
        }

        public bool Intersects(Empty other) => false;

        public bool Intersects(Point other) => Equals(other);

        public PointOrEmpty Intersection(Point other) => Equals(other) ? new PointOrEmpty(this) : new PointOrEmpty(Empty.Geometry);

        public bool Intersects(PointOrEmpty other)
        {
            switch (other.Which)
            {
                case PointOrEmpty.Option.Empty:
                    return Intersects(other.AsEmpty);

                case PointOrEmpty.Option.Point:
                    return Intersects(other.AsPoint);

                default:
                    return false;
            }
        }

        public PointOrEmpty Intersection(PointOrEmpty other) => other.IsPoint ? Intersection(other.AsPoint) : new PointOrEmpty(Empty.Geometry);
    }
}