using System.Collections.Generic;
using RayTracerDemo.Core.Models;
using RayTracerDemo.Core.Models.RayCast;
using RayTracerDemo.Core.Utility;

namespace RayTracerDemo
{
    /// <summary>
    /// The <see cref="RayTracer"/> class casts rays for each pixel of the canvas against all objects in the scene
    /// -    Each ray is evaluated for a hit with an object or a miss
    /// -    If there is a hit, the color of the pixel which was hit is calculated
    /// -    After all rays has been cast, the result is written into a bitmap
    /// </summary>
    public class RayTracer
    {
        private readonly Scene _scene;
        private readonly int _width;
        private readonly int _height;

        private Canvas _canvas;

        public RayTracer(Scene scene, int width, int height)
        {
            _scene = scene;
            _width = width;
            _height = height;
            _canvas = new Canvas(_width, _height);
        }

        public void Render()
        {
            var halfWidth = _width / 2;
            var halfHeight = _height / 2;

            // cast a ray against each pixel on the canvas
            for (var y = -halfHeight; y < halfHeight; y++)
            {
                for (var x = -halfWidth; x < halfWidth; x++)
                {
                    List<Hit> hits = CastRay(x, y);
                    // Check if we did hit something
                    if (hits.Count == 0)
                    {
                        continue;
                    }

                    Color lightColor = CalculateLight(hits[0]);
                    _canvas.SetPixel(x+ _width/2, y + _height/2, lightColor);
                }
            }

            // Save the result into a bitmap
            PPM.SaveCanvas(_canvas, "RtTest");
        }

        private Color CalculateLight(Hit hit)
        {
            return hit.Geometry.GetColor(_scene.Lights[0], hit.Ray.Point(hit.IntersectionScalar), hit.Ray.Direction);
        }

        private List<Hit> CastRay(int x, int y)
        {
            var  hits = new List<Hit>(2);
            var ray = new Ray(_scene.Camera.Position, new Vector(x,y,0) - _scene.Camera.Position);
            foreach (var geometry in _scene.Geometries)
            {
                if (!geometry.Intersect(ray, out var hit)) 
                    continue;
                hits.Add(hit);
            }
            hits.Sort((a, b) => a.IntersectionScalar < b.IntersectionScalar ? -1 : 1);

            return hits;
        }
    }
}