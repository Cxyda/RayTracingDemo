using RayTracerDemo.Core.Models.Geometries;

namespace RayTracerDemo.Core.Models.RayCast
{
    public struct Hit
    {
        public Ray Ray;
        public double IntersectionScalar;
        public IRayTraceGeometry Geometry;

        public Hit(Ray ray, double intersectionScalar, IRayTraceGeometry geometry)
        {
            IntersectionScalar = intersectionScalar;
            Geometry = geometry;
            Ray = ray;
        }
    }
}