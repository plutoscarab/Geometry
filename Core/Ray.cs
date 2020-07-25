// Ray.cs

using System;

namespace Foundations.Geometry
{
    public sealed partial class Ray
    {
        internal bool IntersectsInternal(Point point) => throw new NotImplementedException();

        internal IGeometry IntersectionInternal(Point point) => throw new NotImplementedException();
        
        internal bool IntersectsInternal(Line line) => throw new NotImplementedException();

        internal IGeometry IntersectionInternal(Line line) => throw new NotImplementedException();
        
        internal bool IntersectsInternal(Ray ray) => throw new NotImplementedException();

        internal IGeometry IntersectionInternal(Ray ray) => throw new NotImplementedException();
    }
}