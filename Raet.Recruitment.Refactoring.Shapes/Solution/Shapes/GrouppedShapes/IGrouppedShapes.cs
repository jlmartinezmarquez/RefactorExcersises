using System;

namespace Refactoring.Shapes.Solution.Shapes.GrouppedShapes
{
    interface IGrouppedShapes
    {
        int NumberOf { get; set; }
        double AreaSquares { get; set; }
        double PerimeterSquares { get; set; }

        Type TypeOfTheGrouppedShapes { get; }

        string TextToPrint { get; }

        void ComputeCalculations();
    }
}