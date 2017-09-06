using System;

namespace Refactoring.Shapes.Solution.Shapes
{
    public class Circle : IShape
    {
        public string TextToPrint => "Circles: {0}, Area: {1}, Perimeter: {2}";

        private readonly double _width;

        public Circle(double width)
        {
            _width = width;
        }

        public double GetWidth() => _width;        

        public double GetArea() => Math.PI * (_width / 2) * (_width / 2);        

        public double GetPerimeter() => Math.PI * _width;
    }
}
