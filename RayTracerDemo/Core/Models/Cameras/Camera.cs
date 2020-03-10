using System;

namespace RayTracerDemo.Core.Models.Cameras
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class Camera : ICamera
    {
        public Vector Position { get; set; }
        public float FOV { get; set; }

        private int _width;

        public Camera(int width, float fieldOfView)
        {
            _width = width;
            SetFov(fieldOfView);
        }

        private void SetFov(float fov)
        {
            FOV = fov;
            var d = _width / (2.0f * Math.Tan((double)fov / 2.0));
            Position = new Vector(0,0, d);
        }
    }
}