// DataTypes.cs

using System;
using System.Numerics;

namespace Foundations.Geometry
{
    public partial struct Empty : IEquatable<Empty>
    {
        private Empty(bool _)
        {
        }

        public bool Equals(Empty other) => true;

        public override bool Equals(object obj) => obj is Empty other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Empty", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => SessionHash;

        public static bool operator ==(Empty a, Empty b) => a.Equals(b);

        public static bool operator !=(Empty a, Empty b) => !a.Equals(b);
    }

    public partial struct Fraction : IEquatable<Fraction>
    {
        private Fraction(BigInteger P, BigInteger Q, bool _)
        {
            this.P = P;
            this.Q = Q;
        }

        public BigInteger P { get; }

        public BigInteger Q { get; }

        public bool Equals(Fraction other) => other.P == P && other.Q == Q;

        public override bool Equals(object obj) => obj is Fraction other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Fraction", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => HashCode.Combine(SessionHash, P, Q);

        public static bool operator ==(Fraction a, Fraction b) => a.Equals(b);

        public static bool operator !=(Fraction a, Fraction b) => !a.Equals(b);
    }

    public partial struct Point : IEquatable<Point>
    {
        private Point(BigInteger X, BigInteger Y, BigInteger W, bool _)
        {
            this.X = X;
            this.Y = Y;
            this.W = W;
        }

        public BigInteger X { get; }

        public BigInteger Y { get; }

        public BigInteger W { get; }

        public bool Equals(Point other) => other.X == X && other.Y == Y && other.W == W;

        public override bool Equals(object obj) => obj is Point other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Point", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => HashCode.Combine(SessionHash, X, Y, W);

        public static bool operator ==(Point a, Point b) => a.Equals(b);

        public static bool operator !=(Point a, Point b) => !a.Equals(b);
    }

    public partial struct Vector : IEquatable<Vector>
    {
        private Vector(BigInteger X, BigInteger Y, BigInteger W, bool _)
        {
            this.X = X;
            this.Y = Y;
            this.W = W;
        }

        public BigInteger X { get; }

        public BigInteger Y { get; }

        public BigInteger W { get; }

        public bool Equals(Vector other) => other.X == X && other.Y == Y && other.W == W;

        public override bool Equals(object obj) => obj is Vector other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Vector", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => HashCode.Combine(SessionHash, X, Y, W);

        public static bool operator ==(Vector a, Vector b) => a.Equals(b);

        public static bool operator !=(Vector a, Vector b) => !a.Equals(b);
    }

    public partial struct Direction : IEquatable<Direction>
    {
        private Direction(BigInteger X, BigInteger Y, bool _)
        {
            this.X = X;
            this.Y = Y;
        }

        public BigInteger X { get; }

        public BigInteger Y { get; }

        public bool Equals(Direction other) => other.X == X && other.Y == Y;

        public override bool Equals(object obj) => obj is Direction other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Direction", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => HashCode.Combine(SessionHash, X, Y);

        public static bool operator ==(Direction a, Direction b) => a.Equals(b);

        public static bool operator !=(Direction a, Direction b) => !a.Equals(b);
    }

    public partial struct Segment : IEquatable<Segment>
    {
        private Segment(Point Source, Point Target, bool _)
        {
            this.Source = Source;
            this.Target = Target;
        }

        public Point Source { get; }

        public Point Target { get; }

        public bool Equals(Segment other) => other.Source == Source && other.Target == Target;

        public override bool Equals(object obj) => obj is Segment other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Segment", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => HashCode.Combine(SessionHash, Source, Target);

        public static bool operator ==(Segment a, Segment b) => a.Equals(b);

        public static bool operator !=(Segment a, Segment b) => !a.Equals(b);
    }

    public partial struct Line : IEquatable<Line>
    {
        private Line(BigInteger A, BigInteger B, BigInteger C, bool _)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public BigInteger A { get; }

        public BigInteger B { get; }

        public BigInteger C { get; }

        public bool Equals(Line other) => other.A == A && other.B == B && other.C == C;

        public override bool Equals(object obj) => obj is Line other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Line", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => HashCode.Combine(SessionHash, A, B, C);

        public static bool operator ==(Line a, Line b) => a.Equals(b);

        public static bool operator !=(Line a, Line b) => !a.Equals(b);
    }

    public partial struct Ray : IEquatable<Ray>
    {
        private Ray(Point Source, Direction Direction, bool _)
        {
            this.Source = Source;
            this.Direction = Direction;
        }

        public Point Source { get; }

        public Direction Direction { get; }

        public bool Equals(Ray other) => other.Source == Source && other.Direction == Direction;

        public override bool Equals(object obj) => obj is Ray other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Ray", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => HashCode.Combine(SessionHash, Source, Direction);

        public static bool operator ==(Ray a, Ray b) => a.Equals(b);

        public static bool operator !=(Ray a, Ray b) => !a.Equals(b);
    }

    public partial struct Circle : IEquatable<Circle>
    {
        private Circle(Point Center, Fraction SquaredRadius, bool _)
        {
            this.Center = Center;
            this.SquaredRadius = SquaredRadius;
        }

        public Point Center { get; }

        public Fraction SquaredRadius { get; }

        public bool Equals(Circle other) => other.Center == Center && other.SquaredRadius == SquaredRadius;

        public override bool Equals(object obj) => obj is Circle other && Equals(other);

        private static readonly int SessionHash = HashCode.Combine("Circle", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode() => HashCode.Combine(SessionHash, Center, SquaredRadius);

        public static bool operator ==(Circle a, Circle b) => a.Equals(b);

        public static bool operator !=(Circle a, Circle b) => !a.Equals(b);
    }

}
