namespace Refactoring.Shapes.Solution.Shapes
{
    public class Square : IShape
    {
        public string TextToPrint => "Squares: {0}, Area: {1}, Perimeter: {2}";

        private double _width;

        public Square(double width)
        {
            _width = width;
        }

        public double GetWidth()
        {
            return _width;
        }

        public double GetArea()
        {
            return _width * _width;
        }

        public double GetPerimeter()
        {
            return 4 * _width;
        }
    }
}
