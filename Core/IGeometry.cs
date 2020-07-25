// IGeometry.cs

namespace Foundations.Geometry
{
    public interface IGeometry
    {
        GeometryType GeometryType { get; }
        
        bool Intersects(IGeometry other);

        IGeometry Intersection(IGeometry other);
    }
}