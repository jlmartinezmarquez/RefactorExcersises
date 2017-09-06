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
            var grouppedSquares = encapsulatedListOfGrouppedShapes.GetShapeElement(new Square(0));  //TODO: find a better way of doing this refactoring GetShapeElement
            var grouppedCircles = encapsulatedListOfGrouppedShapes.GetShapeElement(new Circle(0));
            var grouppedTriangles = encapsulatedListOfGrouppedShapes.GetShapeElement(new Triangle(0));
            
            if (grouppedSquares.NumberOf >= grouppedCircles.NumberOf && grouppedSquares.NumberOf >= grouppedTriangles.NumberOf)
            {
                if (grouppedCircles.NumberOf >= grouppedTriangles.NumberOf)
                {
                    return grouppedSquares.TextToPrint + "\n" + grouppedCircles.TextToPrint + "\n" + grouppedTriangles.TextToPrint;
                }
                else
                {
                    return grouppedSquares.TextToPrint + "\n" + grouppedTriangles.TextToPrint + "\n" + grouppedCircles.TextToPrint;
                }
            }
            else
            {
                return Succcessor?.OrderPrintedResults(encapsulatedListOfGrouppedShapes);
            }
        }
    }
}