
using System;
using RayTracerDemo.Core.Models;

namespace RayTracerDemo
{
    /// <summary>
    /// TODO:
    /// </summary>
    public class Canvas
    {
        public readonly int Width;
        public readonly int Height;

        private Color[,] _canvas;
        
        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;
            _canvas = new Color[Width,Height];
            FillArea(0, Width, 0, Height, Color.Black);
        }

        public void FillArea(int xMin, int xMax, int yMin, int yMax, Color color)
        {
            for (var y = yMin; y < yMax; y++)
            {
                for (var x = xMin; x < xMax; x++)
                {
                    SetPixel(x, y, color);
                }
            }
        }
        public void SetPixel(int x, int y, Color color)
        {
            //y = Height - y;

            if (x < 0)
                x = 0;
            else if (x >= Width)
                x = Width-1;
            if (y < 0)
                y = 0;
            else if (y >= Height)
                y = Height-1;
            
            _canvas[x, y] = color;
        }
        public Color GetPixel(int x, int y)
        {
            //y = Height - y;

            if (x < 0)
                x = 0;
            else if (x >= Width)
                x = Width-1;
            if (y < 0)
                y = 0;
            else if (y >= Height)
                y = Height-1;

            return _canvas[x, y];
        }
    }
}