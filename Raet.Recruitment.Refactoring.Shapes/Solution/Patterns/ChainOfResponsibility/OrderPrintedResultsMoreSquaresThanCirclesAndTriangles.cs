using Refactoring.Shapes.Solution.Shapes;
using Refactoring.Shapes.Solution.Shapes.GrouppedShapes;

namespace Refactoring.Shapes.Solution.Patterns.ChainOfResponsibility
{
    public class OrderPrintedResultsMoreSquaresThanCirclesAndTriangles : OrderPrintedResultsChainOfResponsibility
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
            
            if (numberOfSquares >= numberOfCircles && numberOfSquares >= numberOfTriangles)
            {
                if (numberOfCircles >= numberOfTriangles)
                {
                    return encapsulatedListOfGrouppedShapes.TextToPrint<Square>() + "\n" + encapsulatedListOfGrouppedShapes.TextToPrint<Circle>() + "\n" + encapsulatedListOfGrouppedShapes.TextToPrint<Triangle>();
                }
                else
                {
                    return encapsulatedListOfGrouppedShapes.TextToPrint<Square>() + "\n" + encapsulatedListOfGrouppedShapes.TextToPrint<Triangle>() + "\n" + encapsulatedListOfGrouppedShapes.TextToPrint<Circle>();
                }
            }
            else
            {
                return Succcessor?.OrderPrintedResults(encapsulatedListOfGrouppedShapes);
            }
        }
    }
}