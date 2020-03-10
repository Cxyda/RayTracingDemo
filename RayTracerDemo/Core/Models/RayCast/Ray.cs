using System.Collections.Generic;

namespace RayTracerDemo.Core.Models.RayCast
{
    public struct Ray
    {
        public readonly Vector Origin;
        public readonly Vector Direction;
        public readonly double Length;
        
        public Ray(Vector origin, Vector direction)
        {
            Origin = origin;
            Length = direction.Magnitude;
            Direction = Vector.Normalize(direction);
        }

        public Vector Point(double scalar)
        {
            return Origin + Direction * scalar;
        }
    }
}