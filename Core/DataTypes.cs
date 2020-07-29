// DataTypes.cs

using System;
using System.Numerics;

namespace Foundations.Geometry
{
    public enum GeometryType
    {
        Empty, Point, Line, Ray, Segment, Circle
    }

    public sealed partial class Empty : IEquatable<Empty>, IGeometry
    {
        private Empty(bool _)
        {
        }

        public GeometryType GeometryType => GeometryType.Empty;

        public bool Intersects(IGeometry other)
        {
            switch (other)
            {
                case Empty empty:
                    return IntersectsInternal(empty);

                default:
                    return other.Intersects(this);
            }
        }

        public IGeometry Intersection(IGeometry other)
        {
            switch (other)
            {
                case Empty empty:
                    return IntersectionInternal(empty);

                default:
                    return other.Intersection(this);
            }
        }

        internal bool IntersectsInternal(Empty empty) => false;

        internal IGeometry IntersectionInternal(Empty empty) => Empty.Geometry;
        
        public bool Equals(Empty other) => true;

        public override bool Equals(object obj) => obj is Empty other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Empty", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => SessionHash;

        public static bool operator ==(Empty a, Empty b) => a.Equals(b);

        public static bool operator !=(Empty a, Empty b) => !a.Equals(b);
    }

    public sealed partial class Point : IEquatable<Point>, IGeometry
    {
        private Point(Z X, Z Y, Z W, bool _)
        {
            this.X = X;
            this.Y = Y;
            this.W = W;
        }

        public GeometryType GeometryType => GeometryType.Point;

        public bool Intersects(IGeometry other)
        {
            switch (other)
            {
                case Empty empty:
                    return IntersectsInternal(empty);

                case Point point:
                    return IntersectsInternal(point);

                default:
                    return other.Intersects(this);
            }
        }

        public IGeometry Intersection(IGeometry other)
        {
            switch (other)
            {
                case Empty empty:
                    return IntersectionInternal(empty);

                case Point point:
                    return IntersectionInternal(point);

                default:
                    return other.Intersection(this);
            }
        }

        internal bool IntersectsInternal(Empty empty) => false;

        internal IGeometry IntersectionInternal(Empty empty) => Empty.Geometry;
        
        public Z X { get; }

        public Z Y { get; }

        public Z W { get; }

        public bool Equals(Point other) => other.X.Equals(X) && other.Y.Equals(Y) && other.W.Equals(W);

        public override bool Equals(object obj) => obj is Point other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Point", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => HashCode.Combine(SessionHash, X, Y, W);

        public static bool operator ==(Point a, Point b) => a.Equals(b);

        public static bool operator !=(Point a, Point b) => !a.Equals(b);
    }

    public sealed partial class Line : IEquatable<Line>, IGeometry
    {
        private Line(Z A, Z B, Z C, bool _)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public GeometryType GeometryType => GeometryType.Line;

        public bool Intersects(IGeometry other)
        {
            switch (other)
            {
                case Empty empty:
                    return IntersectsInternal(empty);

                case Point point:
                    return IntersectsInternal(point);

                case Line line:
                    return IntersectsInternal(line);

                default:
                    return other.Intersects(this);
            }
        }

        public IGeometry Intersection(IGeometry other)
        {
            switch (other)
            {
                case Empty empty:
                    return IntersectionInternal(empty);

                case Point point:
                    return IntersectionInternal(point);

                case Line line:
                    return IntersectionInternal(line);

                default:
                    return other.Intersection(this);
            }
        }

        internal bool IntersectsInternal(Empty empty) => false;

        internal IGeometry IntersectionInternal(Empty empty) => Empty.Geometry;
        
        public Z A { get; }

        public Z B { get; }

        public Z C { get; }

        public bool Equals(Line other) => other.A.Equals(A) && other.B.Equals(B) && other.C.Equals(C);

        public override bool Equals(object obj) => obj is Line other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Line", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => HashCode.Combine(SessionHash, A, B, C);

        public static bool operator ==(Line a, Line b) => a.Equals(b);

        public static bool operator !=(Line a, Line b) => !a.Equals(b);
    }

    public sealed partial class Ray : IEquatable<Ray>, IGeometry
    {
        private Ray(Point Source, Direction Direction, bool _)
        {
            this.Source = Source;
            this.Direction = Direction;
        }

        public GeometryType GeometryType => GeometryType.Ray;

        public bool Intersects(IGeometry other)
        {
            switch (other)
            {
                case Empty empty:
                    return IntersectsInternal(empty);

                case Point point:
                    return IntersectsInternal(point);

                case Line line:
                    return IntersectsInternal(line);

                case Ray ray:
                    return IntersectsInternal(ray);

                default:
                    return other.Intersects(this);
            }
        }

        public IGeometry Intersection(IGeometry other)
        {
            switch (other)
            {
                case Empty empty:
                    return IntersectionInternal(empty);

                case Point point:
                    return IntersectionInternal(point);

                case Line line:
                    return IntersectionInternal(line);

                case Ray ray:
                    return IntersectionInternal(ray);

                default:
                    return other.Intersection(this);
            }
        }

        internal bool IntersectsInternal(Empty empty) => false;

        internal IGeometry IntersectionInternal(Empty empty) => Empty.Geometry;
        
        public Point Source { get; }

        public Direction Direction { get; }

        public bool Equals(Ray other) => other.Source.Equals(Source) && other.Direction.Equals(Direction);

        public override bool Equals(object obj) => obj is Ray other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Ray", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => HashCode.Combine(SessionHash, Source, Direction);

        public static bool operator ==(Ray a, Ray b) => a.Equals(b);

        public static bool operator !=(Ray a, Ray b) => !a.Equals(b);
    }

    public sealed partial class Segment : IEquatable<Segment>, IGeometry
    {
        private Segment(Point Source, Point Target, bool _)
        {
            this.Source = Source;
            this.Target = Target;
        }

        public GeometryType GeometryType => GeometryType.Segment;

        public bool Intersects(IGeometry other)
        {
            switch (other)
            {
                case Empty empty:
                    return IntersectsInternal(empty);

                case Point point:
                    return IntersectsInternal(point);

                case Line line:
                    return IntersectsInternal(line);

                case Ray ray:
                    return IntersectsInternal(ray);

                case Segment segment:
                    return IntersectsInternal(segment);

                default:
                    return other.Intersects(this);
            }
        }

        public IGeometry Intersection(IGeometry other)
        {
            switch (other)
            {
                case Empty empty:
                    return IntersectionInternal(empty);

                case Point point:
                    return IntersectionInternal(point);

                case Line line:
                    return IntersectionInternal(line);

                case Ray ray:
                    return IntersectionInternal(ray);

                case Segment segment:
                    return IntersectionInternal(segment);

                default:
                    return other.Intersection(this);
            }
        }

        internal bool IntersectsInternal(Empty empty) => false;

        internal IGeometry IntersectionInternal(Empty empty) => Empty.Geometry;
        
        public Point Source { get; }

        public Point Target { get; }

        public bool Equals(Segment other) => other.Source.Equals(Source) && other.Target.Equals(Target);

        public override bool Equals(object obj) => obj is Segment other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Segment", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => HashCode.Combine(SessionHash, Source, Target);

        public static bool operator ==(Segment a, Segment b) => a.Equals(b);

        public static bool operator !=(Segment a, Segment b) => !a.Equals(b);
    }

    public sealed partial class Circle : IEquatable<Circle>, IGeometry
    {
        private Circle(Point Center, Q SquaredRadius, bool _)
        {
            this.Center = Center;
            this.SquaredRadius = SquaredRadius;
        }

        public GeometryType GeometryType => GeometryType.Circle;

        public bool Intersects(IGeometry other)
        {
            switch (other)
            {
                case Empty empty:
                    return IntersectsInternal(empty);

                case Point point:
                    return IntersectsInternal(point);

                case Line line:
                    return IntersectsInternal(line);

                case Ray ray:
                    return IntersectsInternal(ray);

                case Segment segment:
                    return IntersectsInternal(segment);

                case Circle circle:
                    return IntersectsInternal(circle);

                default:
                    return other.Intersects(this);
            }
        }

        public IGeometry Intersection(IGeometry other)
        {
            switch (other)
            {
                case Empty empty:
                    return IntersectionInternal(empty);

                case Point point:
                    return IntersectionInternal(point);

                case Line line:
                    return IntersectionInternal(line);

                case Ray ray:
                    return IntersectionInternal(ray);

                case Segment segment:
                    return IntersectionInternal(segment);

                case Circle circle:
                    return IntersectionInternal(circle);

                default:
                    return other.Intersection(this);
            }
        }

        internal bool IntersectsInternal(Empty empty) => false;

        internal IGeometry IntersectionInternal(Empty empty) => Empty.Geometry;
        
        public Point Center { get; }

        public Q SquaredRadius { get; }

        public bool Equals(Circle other) => other.Center.Equals(Center) && other.SquaredRadius.Equals(SquaredRadius);

        public override bool Equals(object obj) => obj is Circle other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Circle", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => HashCode.Combine(SessionHash, Center, SquaredRadius);

        public static bool operator ==(Circle a, Circle b) => a.Equals(b);

        public static bool operator !=(Circle a, Circle b) => !a.Equals(b);
    }

    public sealed partial class Vector : IEquatable<Vector>
    {
        private Vector(Z X, Z Y, Z W, bool _)
        {
            this.X = X;
            this.Y = Y;
            this.W = W;
        }

        public Z X { get; }

        public Z Y { get; }

        public Z W { get; }

        public bool Equals(Vector other) => other.X.Equals(X) && other.Y.Equals(Y) && other.W.Equals(W);

        public override bool Equals(object obj) => obj is Vector other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Vector", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => HashCode.Combine(SessionHash, X, Y, W);

        public static bool operator ==(Vector a, Vector b) => a.Equals(b);

        public static bool operator !=(Vector a, Vector b) => !a.Equals(b);
    }

    public sealed partial class Direction : IEquatable<Direction>
    {
        private Direction(Z X, Z Y, bool _)
        {
            this.X = X;
            this.Y = Y;
        }

        public Z X { get; }

        public Z Y { get; }

        public bool Equals(Direction other) => other.X.Equals(X) && other.Y.Equals(Y);

        public override bool Equals(object obj) => obj is Direction other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Direction", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => HashCode.Combine(SessionHash, X, Y);

        public static bool operator ==(Direction a, Direction b) => a.Equals(b);

        public static bool operator !=(Direction a, Direction b) => !a.Equals(b);
    }
}
