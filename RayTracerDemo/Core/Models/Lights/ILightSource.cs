namespace RayTracerDemo.Core.Models.Lights
{
    /// <summary>
    /// TODO: 
    /// </summary>
    public interface ILightSource
    {
        Vector Position { get; set; }
        Color Intensity { get; set; }
    }
}