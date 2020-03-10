using System;
using RayTracerDemo.Core.Models;
using RayTracerDemo.Core.Models.Geometries;
using RayTracerDemo.Core.Models.Lights;

namespace RayTracerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello RayTracing World!");
            Scene scene = new Scene();
            ILightSource pointLight = new PointLight(new Vector(0,100, 15), new Color(2,2,2,1, true));
            scene.AddLights(pointLight);
            var sphere1 = GeometryFactory.CreateSphere(new Vector(-50, -80, 0), 20, new Material(Color.Red));
            var sphere2 = GeometryFactory.CreateSphere(new Vector(0, -50, 50), 50, new Material(Color.Yellow, 1, 5));
            //scene.AddGeometry(sphere1);
            scene.AddGeometry(sphere1, sphere2);
            
            RayTracer rt = new RayTracer(scene, 400,400);
            rt.Render();
            //Environment environment = new Environment(new Vector(0.0, -9.8, 0.0), new Vector());
            //Projectile projectile = new Projectile(new Vector(0, 200, 0.0), new Vector(20,3, 0));
            //var simulation = new Simulation.Simulation(environment, projectile);

            //simulation.Run();
        }
    }
}