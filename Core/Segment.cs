// Segment.cs

using System;

namespace Foundations.Geometry
{
    public partial struct Segment
    {
        internal bool IntersectsInternal(Point point) => throw new NotImplementedException();

        internal IGeometry IntersectionInternal(Point point) => throw new NotImplementedException();

        internal bool IntersectsInternal(Line line) => throw new NotImplementedException();

        internal IGeometry IntersectionInternal(Line line) => throw new NotImplementedException();

        internal bool IntersectsInternal(Ray ray) => throw new NotImplementedException();

        internal IGeometry IntersectionInternal(Ray ray) => throw new NotImplementedException();

        internal bool IntersectsInternal(Segment segment) => throw new NotImplementedException();

        internal IGeometry IntersectionInternal(Segment segment) => throw new NotImplementedException();
    }
}