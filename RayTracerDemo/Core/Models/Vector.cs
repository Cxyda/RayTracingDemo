using System;

namespace RayTracerDemo.Core.Models
{
    public struct Vector
    {
        public static Vector Zero = new Vector();
        
        private double _magnitude;
        private double _sqrMagnitude;
        
        public readonly double X, Y, Z, W;

        public double Magnitude
        {
            get
            {
                if (double.IsNaN(_magnitude))
                    _magnitude = Math.Sqrt(SqrMagnitude);
                return _magnitude;
            }
        }
        public double SqrMagnitude
        {
            get
            {
                if (double.IsNaN(_sqrMagnitude))
                    _sqrMagnitude = X * X + Y * Y + Z * Z + W * W;
                return _sqrMagnitude;
            }
        }

        public Vector(double x = 0.0, double y = 0.0, double z = 0.0, double w = 0.0)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;

            _sqrMagnitude = double.NaN;
            _magnitude = double.NaN;
        }
        
        public bool Equals(Vector other)
        {
            return _magnitude.Equals(other._magnitude) && _sqrMagnitude.Equals(other._sqrMagnitude) && X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W);
        }
        public override bool Equals(object obj)
        {
            return obj is Vector other && Equals(other);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _magnitude.GetHashCode();
                hashCode = (hashCode * 397) ^ _sqrMagnitude.GetHashCode();
                hashCode = (hashCode * 397) ^ X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                hashCode = (hashCode * 397) ^ W.GetHashCode();
                return hashCode;
            }
        }
        
        public void Normalize()
        {
            this = Normalize(this);
        }

        public static Vector Normalize(Vector a)
        {
            return new Vector(a.X / a.Magnitude, a.Y / a.Magnitude, a.Z / a.Magnitude, a.W / a.Magnitude);
        }
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        }
        public static Vector operator *(Vector a, double scalar)
        {
            return new Vector(a.X * scalar, a.Y * scalar, a.Z * scalar, a.W * scalar);
        }
        public static Vector operator *(double scalar, Vector a)
        {
            return a * scalar;
        }
        public static bool operator ==(Vector a, Vector b)
        {
            return Math.Abs(a.X - b.X) < double.Epsilon &&
                   Math.Abs(a.Y - b.Y) < double.Epsilon &&
                   Math.Abs(a.Z - b.Z) < double.Epsilon &&
                   Math.Abs(a.W - b.W) < double.Epsilon;
        }
        public static bool operator !=(Vector a, Vector b)
        {
            return !(a == b);
        }

        public static Vector Cross(Vector a, Vector b)
        {
            return new Vector(
                a.Y * b.Z - a.Z * b.Y,
                a.Z * b.W - a.W * b.Z,
                a.W * b.X - a.X * b.W, 
                a.X * b.Y - a.Y * b.X );
        }

        public static double Dot(Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W;
        }


        /// <summary>
        /// Normal vector needs to be normalized
        /// </summary>
        public static Vector Reflect(Vector incoming, Vector normal)
        {
            return incoming - 2.0 * Dot(incoming, normal) * normal;
        }
    }
}