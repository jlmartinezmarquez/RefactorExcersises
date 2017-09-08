using Refactoring.Shapes.Solution.Shapes;
using Refactoring.Shapes.Solution.Shapes.GrouppedShapes;

namespace Refactoring.Shapes.Solution.Patterns.ChainOfResponsibility
{
    public class OrderPrintedResultsMoreTrianglesThanCirclesAndSquares : OrderPrintedResultsChainOfResponsibility
    {
        public override void SetSuccessor(OrderPrintedResultsChainOfResponsibility succcessor)
        {
            Succcessor = succcessor;
        }

        public override string OrderPrintedResults(EncapsulatedListOfGrouppedShapes encapsulatedListOfGrouppedShapes)
        {
            var numberOfSquares = encapsulatedListOfGrouppedShapes.NumberOf<Square>();
            var numberOfCircles = encapsulatedListOfGrouppedShapes.NumberOf<Circle>();
            var numberOfTriangles = encapsulatedListOfGrouppedShapes.NumberOf<Triangle>();

            if (numberOfTriangles >= numberOfCircles && numberOfTriangles >= numberOfSquares)
            {
                if (numberOfCircles >= numberOfSquares)
                {
                    return encapsulatedListOfGrouppedShapes.TextToPrint<Triangle>() + "\n" + encapsulatedListOfGrouppedShapes.TextToPrint<Circle>() + "\n" + encapsulatedListOfGrouppedShapes.TextToPrint<Square>();
                }
                else
                {
                    return encapsulatedListOfGrouppedShapes.TextToPrint<Triangle>() + "\n" + encapsulatedListOfGrouppedShapes.TextToPrint<Square>() + "\n" + encapsulatedListOfGrouppedShapes.TextToPrint<Circle>();
                }
            }
            else
            {
                return Succcessor?.OrderPrintedResults(encapsulatedListOfGrouppedShapes);
            }
        }
    }
}