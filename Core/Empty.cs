// Empty.cs

namespace Foundations.Geometry
{
    public partial struct Empty
    {
        public static readonly Empty Geometry = new Empty();

        public bool Intersects(Empty other) => false;

        public Empty Intersection(Empty other) => Empty.Geometry;
    }
}