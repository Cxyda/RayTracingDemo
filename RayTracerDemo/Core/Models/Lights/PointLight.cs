
namespace RayTracerDemo.Core.Models.Lights
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class PointLight : ILightSource
    {
        public Color Intensity { get; set; }
        public Vector Position { get; set; }

        public PointLight(Vector position, Color color)
        {
            Position = position;
            Intensity = color;
        }
    }
}