// Line.cs

using System;
using System.Numerics;

namespace Foundations.Geometry
{
    public partial struct Line
    {
        public const int Dimensions = 1;

        /// <summary>
        /// ax + by + c = 0
        /// </summary>
        public Line(BigInteger a, BigInteger b, BigInteger c)
        {
            if (a.IsZero && b.IsZero)
                throw new ArgumentException("Either a or b must be non-zero.");

            var g = BigInteger.GreatestCommonDivisor(a, BigInteger.GreatestCommonDivisor(b, c));

            A = a / g;
            B = b / g;
            C = c / g;
        }

        /// <summary>
        /// ax + by + c = 0
        /// <summary>
        public Line(Fraction a, Fraction b, Fraction c)
        : this(a.P * b.Q * c.Q, a.Q * b.P * c.Q, a.Q * b.Q * c.Q)
        {
        }

        public Line(Point a, Point b)
        : this(a.Y * b.W - a.W * b.Y, a.W * b.X - a.X * b.W, a.X * b.Y - a.Y * b.X)
        {
        }

        public Line(Point point, Direction direction)
        : this(point, point + new Vector(direction))
        {
        }

        public Line(Point point, Vector vector)
        : this(point, point + vector)
        {
        }

        public Line(Segment segment)
        : this(segment.Source, segment.Target)
        {
        }

        public Line(Ray ray)
        : this(ray.Source, ray.Source + new Vector(ray.Direction))
        {
        }

        public Direction Direction => new Direction(this);

        public override string ToString()
        {
            var s = new System.Text.StringBuilder();

            if (!A.IsZero)
            {
                if (!A.IsOne)
                {
                    if (A == BigInteger.MinusOne)
                    {
                        s.Append("-");
                    }
                    else
                    {
                        s.Append(A);
                    }
                }
                s.Append("x");
            }

            if (!B.IsZero)
            {
                if (s.Length == 0)
                {
                    if (!B.IsOne)
                    {
                        if (B == BigInteger.MinusOne)
                        {
                            s.Append("-");
                        }
                        else
                        {
                            s.Append(B);
                        }
                    }
                }
                else
                {
                    s.Append(" ");
                    s.Append(B.Sign > 0 ? "+ " : "- ");

                    if (!B.IsOne && B != BigInteger.MinusOne)
                    {
                        s.Append(BigInteger.Abs(B));
                    }
                }

                s.Append("y");
            }

            if (!C.IsZero)
            {
                if (s.Length == 0)
                {
                    s.Append(C);
                }
                else
                {
                    s.Append(" ");
                    s.Append(C.Sign > 0 ? "+ " : "- ");
                    s.Append(BigInteger.Abs(C));
                }
            }

            s.Append(" = 0");
            return s.ToString();
        }

        public bool IsHorizontal => A.IsZero;

        public bool IsVertical => B.IsZero;

        public bool IntersectsOrigin => C.IsZero;

        public bool Intersects(Empty empty) => false;

        public bool Intersects(Point point) => (point.X * A + point.Y * B + point.W * C).IsZero;

        public PointOrEmpty Intersection(Point point) => Intersects(point) ? point : new PointOrEmpty(Empty.Geometry);

        public bool Intersects(PointOrEmpty g)
        {
            switch (g.Which)
            {
                case PointOrEmpty.Option.Empty:
                    return Intersects(g.AsEmpty);

                case PointOrEmpty.Option.Point:
                    return Intersects(g.AsPoint);

                default:
                    return false;
            }
        }

        public PointOrEmpty Intersection(PointOrEmpty g) => Intersects(g) ? g : new PointOrEmpty(Empty.Geometry);

        public bool Intersects(Line other) => Direction != other.Direction || C == other.C;

        public Point Point(Fraction t)
        {
            var d = A * A + B * B;
            var center = new Point(-A * C, -B * C, d);
            var vector = new Vector(Direction);
            return center + t * vector;
        }

        public int Side(Point point) => (A * point.X + B * point.Y + C * point.W).Sign;

        public Line Opposite => new Line(-A, -B, -C, true);
    }
}