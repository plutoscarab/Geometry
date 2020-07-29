// Ray.cs

using System;

namespace Foundations.Geometry
{
    public partial struct Ray
    {
        public Ray(Point source, Direction direction)
        : this(source, direction, true)
        {
        }

        public Ray(Point source, Point other)
        : this(source, other - source)
        {
        }

        public Ray(Point source, Vector vector)
        : this(source, vector.Direction)
        {
        }

        internal bool IntersectsInternal(Point point) => point == Source || (point - Source).Direction == Direction;

        internal IGeometry IntersectionInternal(Point point) => IntersectsInternal(point) ? (IGeometry)point : Empty.Geometry;
        
        internal bool IntersectsInternal(Line line) => throw new NotImplementedException();

        internal IGeometry IntersectionInternal(Line line) => throw new NotImplementedException();
        
        internal bool IntersectsInternal(Ray ray) => throw new NotImplementedException();

        internal IGeometry IntersectionInternal(Ray ray) => throw new NotImplementedException();
    }
}