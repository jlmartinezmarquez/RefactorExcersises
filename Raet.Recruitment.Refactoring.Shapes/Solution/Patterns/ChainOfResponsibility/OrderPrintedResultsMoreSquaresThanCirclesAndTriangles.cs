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
            var numberOfSquares = encapsulatedListOfGrouppedShapes.NumberOf(new Square(0));  //TODO: find a better way of doing this refactoring GetShapeElement
            var numberOfCircles = encapsulatedListOfGrouppedShapes.NumberOf(new Circle(0));
            var numberOfTriangles = encapsulatedListOfGrouppedShapes.NumberOf(new Triangle(0));
            
            if (numberOfSquares >= numberOfCircles && numberOfSquares >= numberOfTriangles)
            {
                if (numberOfCircles >= numberOfTriangles)
                {
                    return grouppedSquares.TextToPrint + "\n" + grouppedCircles.TextToPrint + "\n" + numberOfTriangles.TextToPrint;
                }
                else
                {
                    return grouppedSquares.TextToPrint + "\n" + numberOfTriangles.TextToPrint + "\n" + grouppedCircles.TextToPrint;
                }
            }
            else
            {
                return Succcessor?.OrderPrintedResults(encapsulatedListOfGrouppedShapes);
            }
        }
    }
}