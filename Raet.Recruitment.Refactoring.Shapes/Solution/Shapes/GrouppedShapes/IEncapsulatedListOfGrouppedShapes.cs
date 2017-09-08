namespace Refactoring.Shapes.Solution.Shapes.GrouppedShapes
{
    public interface IEncapsulatedListOfGrouppedShapes
    {
        void Add(GrouppedShapes grouppedShapes);
        bool HasGrouppedShapesInList(IBasicShape basicShape);
        GrouppedShapes GetGrouppedShapesElement(IBasicShape basicShape);
        int NumberOf<T>() where T : IBasicShape;
        string TextToPrint<T>() where T : IBasicShape;
    }
}