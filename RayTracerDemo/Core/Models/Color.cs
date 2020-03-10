using System.Security.Claims;

namespace RayTracerDemo.Core.Models
{
    /// <summary>
    /// TODO: 
    /// </summary>
    public struct Color
    {
        public static Color Black = new Color(0f, 0f, 0f);
        public static Color White = new Color(1f, 1f, 1f);
        public static Color Grey = new Color(.5f, .5f, .5f);
        public static Color Red = new Color(1f, 0f, 0f);
        public static Color Green = new Color(0f, 1f, 0f);
        public static Color Blue = new Color(0f, 0f, 1f);
        public static Color Yellow = new Color(1f, 1f, 0f);

        public readonly float R;
        public readonly float G;
        public readonly float B;
        public readonly float A;
        public readonly bool HdrColor;

        public Color(float r, float g, float b, float a = 1f, bool hdrColor = false)
        {
            R = r;
            G = g;
            B = b;
            A = a;
            HdrColor = hdrColor;
            
            A = Clamp(A);
            if (HdrColor) return;

            R = Clamp(R);
            G = Clamp(G);
            B = Clamp(B);
        }

        private float Clamp(float value)
        {
            if (value < 0)
                value = 0f;

            else if (value > 1f)
                value = 1f;

            return value;
        }

        public static Color operator +(Color a, Color b)
        {
            return new Color(a.R + b.R, a.G + b.G, a.B + b.B, a.A + b.A, a.HdrColor || b.HdrColor);
        }
        public static Color operator *(Color a, double intensity)
        {
            return a * (float) intensity;
        }
        public static Color operator *(Color a, float intensity)
        {
            return new Color(a.R * intensity, a.G * intensity, a.B * intensity, a.A * intensity, a.HdrColor);
        }
        public static Color operator *(Color a, Color b)
        {
            return new Color(a.R * b.R, a.G * b.G, a.B * b.B, a.A * b.A, a.HdrColor || b.HdrColor);
        }
    }
}