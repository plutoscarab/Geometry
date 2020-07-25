// Circle.cs

using System;

namespace Foundations.Geometry
{
    public sealed partial class Circle
    {
        internal bool IntersectsInternal(Point point) => throw new NotImplementedException();

        internal IGeometry IntersectionInternal(Point point) => throw new NotImplementedException();
        
        internal bool IntersectsInternal(Line line) => throw new NotImplementedException();

        internal IGeometry IntersectionInternal(Line line) => throw new NotImplementedException();
        
        internal bool IntersectsInternal(Ray ray) => throw new NotImplementedException();

        internal IGeometry IntersectionInternal(Ray ray) => throw new NotImplementedException();
        
        internal bool IntersectsInternal(Segment segment) => throw new NotImplementedException();

        internal IGeometry IntersectionInternal(Segment segment) => throw new NotImplementedException();
        
        internal bool IntersectsInternal(Circle circle) => throw new NotImplementedException();

        internal IGeometry IntersectionInternal(Circle circle) => throw new NotImplementedException();
    }
}