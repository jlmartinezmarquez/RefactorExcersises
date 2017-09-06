using System;
using Refactoring.Shapes.Solution.Shapes;

namespace Refactoring.Shapes.Solution.Patterns.Strategy
{
    public class SquareGetMeasuresStrategy : IGetMeasuresStrategy
    {
        public double GetArea(IShape shape)
        {
            ReturnIfNotSquare(shape);

            return shape.Width * shape.Width;
        }

        public double GetPerimeter(IShape shape)
        {
            ReturnIfNotSquare(shape);

            return 4 * shape.Width;
        }

        private static void ReturnIfNotSquare(IShape shape)
        {
            if (!(shape is Square)) throw new ArgumentException("Needed a square to calculate the area of a square");
        }
    }
}
