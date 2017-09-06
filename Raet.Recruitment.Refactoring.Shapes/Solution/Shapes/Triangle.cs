using System;

namespace Refactoring.Shapes.Solution.Shapes
{
    public class Triangle : IShape
    {
        public string TextToPrint => "Triangles: {0}, Area: {1}, Perimeter: {2}";

        private readonly double _width;

        public Triangle(double width)
        {
            _width = width;
        }

        public double GetWidth() => _width;

        public double GetArea() => (Math.Sqrt(3) / 4) * _width * _width;

        public double GetPerimeter() => 3 * _width;
    }
}
