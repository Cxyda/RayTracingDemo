using System.Numerics;

namespace RayTracerDemo.Core.Models.Cameras
{
    public interface ICamera
    {
        Vector Position { get; set; }
        float FOV { get; set; }
    }
}