using RayTracerDemo.Core.Models.Lights;
using RayTracerDemo.Core.Models.RayCast;

namespace RayTracerDemo.Core.Models.Geometries
{
    public interface IRayTraceGeometry
    {
        int Id { get; }
        Material Material { get; }
        bool Intersect(Ray ray, out Hit hit);
        Vector GetNormal(Vector pointOnSurface);
        Color GetColor(ILightSource light, Vector point, Vector cameraVector);
    }
}