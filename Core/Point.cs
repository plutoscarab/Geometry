// Point.cs

using System;
using System.Numerics;

namespace Foundations.Geometry
{
    public sealed partial class Point : IEquatable<Point>
    {
        public const int Dimensions = 0;

        public static readonly Point Origin = new Point(0, 0);

        public Point(Z x, Z y, Z w)
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
                (x, y, w) = x.Reduce(y, w);
            }
            
            X = x;
            Y = y;
            W = w;
        }

        public Point(double x, double y)
        : this(x.ToQ(), y.ToQ())
        {
        }

        public Point((BigInteger P, BigInteger Q) x, (BigInteger P, BigInteger Q) y)
        : this(x.P, x.Q, y.P, y.Q)
        {
        }

        public Point(Q x, Q y)
        : this(x.N, x.D, y.N, y.D)
        {
        }

        public Point(Z px, Z qx, Z py, Z qy)
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

            (X, Y, W) = px.Reduce(py, W);
        }

        public static Point operator +(Point point, Vector vector)
        {
            var x = new Q(point.X, point.W) + new Q(vector.X, vector.W);
            var y = new Q(point.Y, point.W) + new Q(vector.Y, vector.W);
            return new Point(x, y);
        }

        public static Point operator -(Point point, Vector vector)
        {
            var x = new Q(point.X, point.W) - new Q(vector.X, vector.W);
            var y = new Q(point.Y, point.W) - new Q(vector.Y, vector.W);
            return new Point(x, y);
        }

        public static Vector operator -(Point a, Point b)
        {
            var x = new Q(a.X, a.W) - new Q(b.X, b.W);
            var y = new Q(a.Y, a.W) - new Q(b.Y, b.W);
            return new Vector(x, y);
        }

        public override string ToString() => $"{(double)X / (double)W}, {(double)Y / (double)W}";

        public (double, double) ToDouble()
        {
            var w = (double)W;
            return ((double)X / w, (double)Y / w);
        }

        internal bool IntersectsInternal(Point point) => Equals(point);

        internal IGeometry IntersectionInternal(Point point) => Equals(point) ? (IGeometry)this : Empty.Geometry;
   }
}