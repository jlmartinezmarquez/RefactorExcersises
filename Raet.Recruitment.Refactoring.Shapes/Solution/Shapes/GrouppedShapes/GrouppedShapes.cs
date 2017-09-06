using System;

namespace Refactoring.Shapes.Solution.Shapes.GrouppedShapes
{
    public class GrouppedShapes
    {
        public int NumberOf { get; set; }
        public double AreaSquares { get; set; }
        public double PerimeterSquares { get; set; }

        public string TextToPrint => string.Format(_shape.TextToPrint, NumberOf, AreaSquares, PerimeterSquares);

        private readonly IShape _shape;

        public GrouppedShapes(IShape shape)
        {
            _shape = shape;

            NumberOf = 0;
            AreaSquares = 0;
            PerimeterSquares = 0;
        }

        public void ComputeCalculations()
        {
            NumberOf++;
            AreaSquares += _shape.GetArea();
            PerimeterSquares += _shape.GetPerimeter();
        }

        public Type TypeOfTheGrouppedShapes => _shape.GetType();
    }
}
