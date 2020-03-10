using System.Text;
namespace RayTracerDemo.Core.Utility
{

    public static class PPM
    {
        public enum ImageFormat
        {
            PPM
        }
        private static int _maxValue = 255;
        private static int _maxCharactersPerLine = 70;

        private static ImageFormat _imageFormat = ImageFormat.PPM;
        public static bool SaveCanvas(Canvas canvas, string fileName)
        {
            Create(canvas, fileName);
            return true;
        }

        private static void Create(Canvas canvas, string fileName)
        {
            var header = $"P3\n{canvas.Width} {canvas.Height}\n{_maxValue}\n";

            var body = CreateBody(canvas);
            var footer = $"\n";
            var total = header + body + footer;
            System.IO.File.WriteAllText($"{fileName}.{_imageFormat.ToString().ToLower()}", total);
        }

        private static string CreateBody(Canvas canvas)
        {
            var sb = new StringBuilder();
            for (var y = canvas.Height-1; y >= 0; y--)
            {
                for (var x = 0; x < canvas.Width; x++)
                {
                    var color = canvas.GetPixel(x, y);
                    string r = $"{(int) Clamp((color.R * _maxValue), _maxValue)}";
                    string g = $"{(int) Clamp((color.G * _maxValue), _maxValue)}";
                    string b = $"{(int) Clamp((color.B * _maxValue), _maxValue)}";
                    sb.Append($"{r} {g} {b} ");
                }
            }

            return sb.ToString();
        }

        private static float Clamp(float value, float maxValue)
        {
            if (value < 0)
                value = 0f;

            else if (value > maxValue)
                value = maxValue;

            return value;
        }
    }
}