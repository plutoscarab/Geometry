// Line.cs

using System;
using System.Numerics;

namespace Foundations.Geometry
{
    public sealed partial class Line
    {
        public const int Dimensions = 1;

        /// <summary>
        /// ax + by + c = 0
        /// </summary>
        public Line(Z a, Z b, Z c)
        {
            if (a.IsZero && b.IsZero)
                throw new ArgumentException("Either a or b must be non-zero.");

            (A, B, C) = a.Reduce(b, c);
        }

        /// <summary>
        /// ax + by + c = 0
        /// <summary>
        public Line(Q a, Q b, Q c)
        : this(a.N * b.D * c.D, a.D * b.N * c.D, a.D * b.D * c.D)
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
                    if ((-A).IsOne)
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
                        if ((-B).IsOne)
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

                    if (!B.IsOne && !(-B).IsOne)
                    {
                        s.Append(B.Abs());
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
                    s.Append(C.Abs());
                }
            }

            s.Append(" = 0");
            return s.ToString();
        }

        public bool IsHorizontal => A.IsZero;

        public bool IsVertical => B.IsZero;

        public bool IntersectsOrigin => C.IsZero;

        internal bool IntersectsInternal(Point point) => (point.X * A + point.Y * B + point.W * C).IsZero;

        internal IGeometry IntersectionInternal(Point point) => Intersects(point) ? (IGeometry)point : Empty.Geometry;

        internal bool IntersectsInternal(Line line) => (Direction != line.Direction && Direction.Opposite != line.Direction) || C == line.C;

        internal IGeometry IntersectionInternal(Line line)
        {
            // Lines are coincident?
            if (this == line || this == line.Opposite)
            {
                return this;
            }

            // Lines are parallel?
            var d = A * line.B - B * line.A;

            if (d.IsZero)
            {
                return Empty.Geometry;
            }

            // Lines intersect at point.
            var x = new Q(B * line.C - C * line.B, d);
            var y = new Q(C * line.A - A * line.C, d);
            return new Point(x, y);
        }

        public Point Point(Q t)
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