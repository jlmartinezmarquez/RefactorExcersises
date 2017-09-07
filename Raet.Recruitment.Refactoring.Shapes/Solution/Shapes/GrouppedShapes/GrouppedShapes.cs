using System;

namespace Refactoring.Shapes.Solution.Shapes.GrouppedShapes
{
    public class GrouppedShapes
    {
        public int NumberOf { get; set; }
        public double AreaSquares { get; set; }
        public double PerimeterSquares { get; set; }

        public string TextToPrint => string.Format(_basicShape.TextToPrint, NumberOf, AreaSquares.ToString("#.##"), PerimeterSquares.ToString("#.##"));

        private readonly IBasicShape _basicShape;

        public GrouppedShapes(IBasicShape basicShape)
        {
            _basicShape = basicShape;

            NumberOf = 0;
            AreaSquares = 0;
            PerimeterSquares = 0;
        }

        public void ComputeCalculations()
        {
            NumberOf++;
            AreaSquares += _basicShape.GetArea();
            PerimeterSquares += _basicShape.GetPerimeter();
        }

        public Type TypeOfTheGrouppedShapes => _basicShape.GetType();
    }
}
