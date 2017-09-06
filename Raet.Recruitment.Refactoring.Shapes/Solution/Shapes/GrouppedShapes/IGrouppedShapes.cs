using System;

namespace Refactoring.Shapes.Solution.Shapes.GrouppedShapes
{
    public interface IGrouppedShapes
    {
        Type TypeOfTheGrouppedShapes { get; }

        string TextToPrint { get; }

        void ComputeCalculations();
    }
}