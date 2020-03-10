using System;
using RayTracerDemo.Core.Models.Lights;
using RayTracerDemo.Core.Models.RayCast;

namespace RayTracerDemo.Core.Models.Geometries
{
    /// <summary>
    /// TODO: 
    /// </summary>
    public struct Sphere : IRayTraceGeometry
    {
        public int Id { get; }
        public Material Material { get; }

        public readonly Vector Center;
        public readonly double Radius;
        
        public Sphere(int id, Vector center, double radius, Material material)
        {
            Id = id;
            Center = center;
            Radius = radius;
            Material = material;
        }

        public bool Intersect(Ray ray, out Hit hit)
        {
            hit = default;
            // A : Ray origin; B : Ray direction; C : Sphere center
            // Sphere equation : dot((P−C),(P−C))=r2
            // Ray equation : p(t)=A+tB

            // combined: dot((A+tB−C),(A+tB−C))= r^2
            // expanded and rearranged: t^2⋅dot(B,B)+2t⋅dot(B,A−C)+dot(A−C,A−C)−r2=0
            // simplified : at^2+bt+c=0
            
            var oc = ray.Origin - Center;    

            var a = Vector.Dot(ray.Direction, ray.Direction);
            var b = 2.0 * Vector.Dot(oc, ray.Direction);
            var c = Vector.Dot(oc,oc) - Radius*Radius;
            
            var discriminant = b*b - 4*a*c;

            if (discriminant < 0) return false;

            // calculate the hitPoint
            var intersectionScalar = 0.0;
            var numerator = -b - Math.Sqrt(discriminant);
            if (numerator > 0.0)
            {
                intersectionScalar = numerator / (2.0 * a);
            }

            hit = new Hit(ray, intersectionScalar, this);
            return true;

        }

        public Vector GetNormal(Vector pointOnSurface)
        {
            var pc = pointOnSurface - Center;
            // check if point is on surface
            if (Math.Abs(pc.Magnitude - Radius) > 0.0001)
                return Vector.Zero;

            pc.Normalize();
            return pc;
        }

        public Color GetColor(ILightSource light, Vector pointOnSurface, Vector cameraVector)
        {
            var normal = GetNormal(pointOnSurface);
            if (normal == Vector.Zero)
            {
                throw new Exception("Given point is not on the surface");
            }

            // apply phong light model
            var effectiveColor = light.Intensity * Material.Albedo;
            var diffuseColor = Color.Black;
            var ambientColor = new Color(0.1f, 0.1f, 0.1f);
            var specularColor = Color.Black;

            var lightVector = Vector.Normalize(light.Position - Center);

            var lDotN = Vector.Dot(lightVector, normal);

            if (lDotN >= 0)
            {
                diffuseColor = effectiveColor * Material.Albedo * lDotN;
                var reflect = Vector.Reflect(lightVector, normal);
                var rDotC = Vector.Dot(reflect, cameraVector);
                if (rDotC >= 0)
                {
                    var value = Math.Pow(rDotC, Material.Shininess);
                    specularColor = light.Intensity * Material.Specular * value;
                }
            }
            return diffuseColor + specularColor + ambientColor;
        }
    }
}