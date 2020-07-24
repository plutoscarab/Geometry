// Relates.cs

namespace Foundations.Geometry
{
    public partial struct PointOrEmpty
    {
        public bool Intersects(Empty other)
        {
            switch (Which)
            {
                case Option.Point:
                    return AsPoint.Intersects(other);

                case Option.Empty:
                    return AsEmpty.Intersects(other);

                default:
                    return false;
            }
        }

        public bool Intersects(Point other)
        {
            switch (Which)
            {
                case Option.Point:
                    return AsPoint.Intersects(other);

                case Option.Empty:
                    return other.Intersects(AsEmpty);

                default:
                    return false;
            }
        }

        public bool Intersects(Line other)
        {
            switch (Which)
            {
                case Option.Point:
                    return other.Intersects(AsPoint);

                case Option.Empty:
                    return other.Intersects(AsEmpty);

                default:
                    return false;
            }
        }

    }

    public partial struct LineOrPointOrEmpty
    {
        public bool Intersects(Empty other)
        {
            switch (Which)
            {
                case Option.Line:
                    return AsLine.Intersects(other);

                case Option.Point:
                    return AsPoint.Intersects(other);

                case Option.Empty:
                    return AsEmpty.Intersects(other);

                default:
                    return false;
            }
        }

        public bool Intersects(Point other)
        {
            switch (Which)
            {
                case Option.Line:
                    return AsLine.Intersects(other);

                case Option.Point:
                    return AsPoint.Intersects(other);

                case Option.Empty:
                    return other.Intersects(AsEmpty);

                default:
                    return false;
            }
        }

        public bool Intersects(Line other)
        {
            switch (Which)
            {
                case Option.Line:
                    return AsLine.Intersects(other);

                case Option.Point:
                    return other.Intersects(AsPoint);

                case Option.Empty:
                    return other.Intersects(AsEmpty);

                default:
                    return false;
            }
        }

    }

}
