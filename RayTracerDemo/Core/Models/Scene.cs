using System.Collections.Generic;
using System.Globalization;
using RayTracerDemo.Core.Models.Cameras;
using RayTracerDemo.Core.Models.Geometries;
using RayTracerDemo.Core.Models.Lights;

namespace RayTracerDemo.Core.Models
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class Scene
    {
        public List<IRayTraceGeometry> Geometries;
        public List<ILightSource> Lights;

        public ICamera Camera;

        public Scene()
        {
            Camera = new Camera(60);
            Geometries = new List<IRayTraceGeometry>(64);
            Lights = new List<ILightSource>(4);
        }
        
        public void AddGeometry(params IRayTraceGeometry[] geometry)
        {
            foreach (var geo in geometry)
            {
                Geometries.Add(geo);
            }
        }

        public void AddLights(params ILightSource[] lightSource)
        {
            foreach (var light in lightSource)
            {
                Lights.Add(light);
            }
        }
    }
}