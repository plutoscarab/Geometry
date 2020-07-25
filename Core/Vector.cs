// Point.cs

using System;
using System.Numerics;

namespace Foundations.Geometry
{
    public sealed partial class Vector
    {
        public static readonly Vector Zero = new Vector(0, 0);
        
        public static readonly Vector XAxis = new Vector(1, 0);

        public static readonly Vector YAxis = new Vector(0, 1);

        public Vector(Z x, Z y, Z w)
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

        public Vector(double x, double y)
        : this(x.ToQ(), y.ToQ())
        {
        }

        public Vector((BigInteger P, BigInteger Q) x, (BigInteger P, BigInteger Q) y)
        : this(x.P, x.Q, y.P, y.Q)
        {
        }

        public Vector(Q x, Q y)
        : this(x.N, x.D, y.N, y.D)
        {
        }

        public Vector(Z px, Z qx, Z py, Z qy)
        {
            var p = new Point(px, qx, py, qy);
            X = p.X;
            Y = p.Y;
            W = p.W;
        } 

        public Vector(Direction direction)
        : this(direction.X, direction.Y, 1)
        {
        }

        public Vector(Line line)
        : this(new Direction(line))
        {
        }

        public Vector(Segment segment)
        : this(segment.Target - segment.Source)
        {
        }

        public Vector(Vector vector)
        : this(vector.X, vector.Y, vector.W, true)
        {
        }

        public Vector(Point source, Point target)
        : this(target - source)
        {
        }

        public Q SquaredLength() => new Q(X * X + Y * Y, W * W);

        public static Vector operator +(Vector a, Vector b)
        {
            var x = new Q(a.X, a.W) + new Q(b.X, b.W);
            var y = new Q(a.Y, a.W) + new Q(b.Y, b.W);
            return new Vector(x, y);
        }

        public static Vector operator -(Vector a, Vector b)
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

        public static Vector operator *(Vector vector, Q scalar) => new Vector(vector.X * scalar.N, vector.Y * scalar.N, vector.W * scalar.D);

        public static Vector operator /(Vector vector, Q scalar) => new Vector(vector.X * scalar.D, vector.Y * scalar.D, vector.W * scalar.N);

        public static Vector operator *(Q scalar, Vector vector) => new Vector(vector.X * scalar.N, vector.Y * scalar.N, vector.W * scalar.D);   
    }
}