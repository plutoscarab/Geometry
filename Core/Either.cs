// Either.cs

using System;
using System.Runtime.InteropServices;

namespace Foundations.Geometry
{
    [StructLayout(LayoutKind.Explicit)]
    public partial struct PointOrEmpty : IEquatable<PointOrEmpty>
    {
        public static readonly PointOrEmpty Undefined = default;

        public enum Option
        {
            Undefined, Point, Empty,
        }

        [FieldOffset(0)]
        public readonly Option Which;

        [FieldOffset(sizeof(int))]
        private readonly Point _Point;

        public bool IsPoint => Which == Option.Point;

        public Point AsPoint => Which == Option.Point ? _Point : throw new InvalidOperationException();

        public static implicit operator PointOrEmpty(Point value) => new PointOrEmpty(value);

        public PointOrEmpty(Point value)
        {
            _Empty = default;
            _Point = value;
            Which = Option.Point;
        }

        [FieldOffset(sizeof(int))]
        private readonly Empty _Empty;

        public bool IsEmpty => Which == Option.Empty;

        public Empty AsEmpty => Which == Option.Empty ? _Empty : throw new InvalidOperationException();

        public static implicit operator PointOrEmpty(Empty value) => new PointOrEmpty(value);

        public PointOrEmpty(Empty value)
        {
            _Point = default;
            _Empty = value;
            Which = Option.Empty;
        }
    
        public bool IsUndefined => Which == Option.Undefined;

        public override string ToString()
        {
            switch (Which)
            {
                default:
                    return Which.ToString();

                case Option.Point:
                    return Which + " " + _Point;

                case Option.Empty:
                    return Which + " " + _Empty;
            }
        }

        public override bool Equals(object obj) => obj is PointOrEmpty other && Equals(other);

        public bool Equals(PointOrEmpty other)
        {
            switch (Which)
            {
                default:
                    return other.IsUndefined;

                case Option.Point:
                    return other.IsPoint && _Point.Equals(other.AsPoint);

                case Option.Empty:
                    return other.IsEmpty && _Empty.Equals(other.AsEmpty);
            }
        }

        public static bool operator ==(PointOrEmpty a, PointOrEmpty b) => a.Equals(b);

        public static bool operator !=(PointOrEmpty a, PointOrEmpty b) => !a.Equals(b);

        private static readonly int SessionHash = HashCode.Combine("PointOrEmpty", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode()
        {
            switch (Which)
            {
                default:
                    return SessionHash;

                case Option.Point:
                    return HashCode.Combine(_Point, SessionHash);

                case Option.Empty:
                    return HashCode.Combine(_Empty, SessionHash);
            }
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct LineOrPointOrEmpty : IEquatable<LineOrPointOrEmpty>
    {
        public static readonly LineOrPointOrEmpty Undefined = default;

        public enum Option
        {
            Undefined, Line, Point, Empty,
        }

        [FieldOffset(0)]
        public readonly Option Which;

        [FieldOffset(sizeof(int))]
        private readonly Line _Line;

        public bool IsLine => Which == Option.Line;

        public Line AsLine => Which == Option.Line ? _Line : throw new InvalidOperationException();

        public static implicit operator LineOrPointOrEmpty(Line value) => new LineOrPointOrEmpty(value);

        public LineOrPointOrEmpty(Line value)
        {
            _Point = default;
            _Empty = default;
            _Line = value;
            Which = Option.Line;
        }

        [FieldOffset(sizeof(int))]
        private readonly Point _Point;

        public bool IsPoint => Which == Option.Point;

        public Point AsPoint => Which == Option.Point ? _Point : throw new InvalidOperationException();

        public static implicit operator LineOrPointOrEmpty(Point value) => new LineOrPointOrEmpty(value);

        public LineOrPointOrEmpty(Point value)
        {
            _Line = default;
            _Empty = default;
            _Point = value;
            Which = Option.Point;
        }

        [FieldOffset(sizeof(int))]
        private readonly Empty _Empty;

        public bool IsEmpty => Which == Option.Empty;

        public Empty AsEmpty => Which == Option.Empty ? _Empty : throw new InvalidOperationException();

        public static implicit operator LineOrPointOrEmpty(Empty value) => new LineOrPointOrEmpty(value);

        public LineOrPointOrEmpty(Empty value)
        {
            _Line = default;
            _Point = default;
            _Empty = value;
            Which = Option.Empty;
        }
    
        public bool IsUndefined => Which == Option.Undefined;

        public override string ToString()
        {
            switch (Which)
            {
                default:
                    return Which.ToString();

                case Option.Line:
                    return Which + " " + _Line;

                case Option.Point:
                    return Which + " " + _Point;

                case Option.Empty:
                    return Which + " " + _Empty;
            }
        }

        public override bool Equals(object obj) => obj is LineOrPointOrEmpty other && Equals(other);

        public bool Equals(LineOrPointOrEmpty other)
        {
            switch (Which)
            {
                default:
                    return other.IsUndefined;

                case Option.Line:
                    return other.IsLine && _Line.Equals(other.AsLine);

                case Option.Point:
                    return other.IsPoint && _Point.Equals(other.AsPoint);

                case Option.Empty:
                    return other.IsEmpty && _Empty.Equals(other.AsEmpty);
            }
        }

        public static bool operator ==(LineOrPointOrEmpty a, LineOrPointOrEmpty b) => a.Equals(b);

        public static bool operator !=(LineOrPointOrEmpty a, LineOrPointOrEmpty b) => !a.Equals(b);

        private static readonly int SessionHash = HashCode.Combine("LineOrPointOrEmpty", System.Diagnostics.Stopwatch.GetTimestamp());

        public override int GetHashCode()
        {
            switch (Which)
            {
                default:
                    return SessionHash;

                case Option.Line:
                    return HashCode.Combine(_Line, SessionHash);

                case Option.Point:
                    return HashCode.Combine(_Point, SessionHash);

                case Option.Empty:
                    return HashCode.Combine(_Empty, SessionHash);
            }
        }
    }

}
