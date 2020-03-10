namespace RayTracerDemo.Core.Models.Cameras
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class Camera : ICamera
    {
        public Vector Position { get; set; }
        public float FOV { get; set; }

        public Camera(float fieldOfView)
        {
            // TODO: calculate position
            Position = new Vector(0,0,-2000);
        }
    }
}