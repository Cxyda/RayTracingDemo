namespace RayTracerDemo.Core.Models.Geometries
{
    /// <summary>
    /// TODO: 
    /// </summary>
    public static class GeometryFactory
    {
        private static int _geometryCounter = 0;
        public static Sphere CreateSphere(Vector center, double radius, Material material)
        {
            _geometryCounter++;
            return new Sphere(_geometryCounter, center, radius, material);
        }
    }
}