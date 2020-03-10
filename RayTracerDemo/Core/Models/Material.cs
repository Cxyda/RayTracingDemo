namespace RayTracerDemo.Core.Models
{
    public class Material
    {
        public Color Albedo;
        public double Specular;
        public double Shininess;

        public Material(Color albedoColor, double specular = 0.0, double shininess = 10.0)
        {
            Albedo = albedoColor;
            Specular = specular;
            Shininess = shininess;
        }
    }
}