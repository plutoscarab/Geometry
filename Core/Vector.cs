// Point.cs

using System;
using System.Numerics;

namespace Foundations.Geometry
{
    public partial struct Vector
    {
        public static readonly Vector Zero = new Vector(0, 0);
        
        public static readonly Vector XAxis = new Vector(1, 0);

        public static readonly Vector YAxis = new Vector(0, 1);

        public Vector(BigInteger x, BigInteger y, BigInteger w)
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

        public Vector(double x, double y)
        : this(x.ToFraction(), y.ToFraction())
        {
        }

        public Vector((BigInteger P, BigInteger Q) x, (BigInteger P, BigInteger Q) y)
        : this(x.P, x.Q, y.P, y.Q)
        {
        }

        public Vector(Fraction x, Fraction y)
        : this(x.P, x.Q, y.P, y.Q)
        {
        }

        public Vector(BigInteger px, BigInteger qx, BigInteger py, BigInteger qy)
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

        public Fraction SquaredLength() => new Fraction(X * X + Y * Y, W * W);

        public static Vector operator +(Vector a, Vector b)
        {
            var x = new Fraction(a.X, a.W) + new Fraction(b.X, b.W);
            var y = new Fraction(a.Y, a.W) + new Fraction(b.Y, b.W);
            return new Vector(x, y);
        }

        public static Vector operator -(Vector a, Vector b)
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

        public static Vector operator *(Vector vector, Fraction scalar) => new Vector(vector.X * scalar.P, vector.Y * scalar.P, vector.W * scalar.Q);

        public static Vector operator /(Vector vector, Fraction scalar) => new Vector(vector.X * scalar.Q, vector.Y * scalar.Q, vector.W * scalar.P);

        public static Vector operator *(Fraction scalar, Vector vector) => new Vector(vector.X * scalar.P, vector.Y * scalar.P, vector.W * scalar.Q);   
    }
}