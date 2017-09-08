using Refactoring.Shapes.Solution.Shapes;
using Refactoring.Shapes.Solution.Shapes.GrouppedShapes;

namespace Refactoring.Shapes.Solution.Patterns.Facade
{
    public interface IFacadeListOfGrouppedShapes
    {
        void Add(GrouppedShapes grouppedShapes);
        bool HasGrouppedShapesInList(IBasicShape basicShape);
        GrouppedShapes GetGrouppedShapesElement(IBasicShape basicShape);
        int NumberOf<T>() where T : IBasicShape;
        string TextToPrint<T>() where T : IBasicShape;

        void ComputeCalculations(GrouppedShapes grouppedShapes, IBasicShape basicShape);
    }
}