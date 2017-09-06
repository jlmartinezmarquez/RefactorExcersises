using Refactoring.Shapes.Solution.Models;
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

        public override string OrderPrintedResults(ListOfGrouppedShapes listOfGrouppedShapes)
        {
            var squareMetrics = listOfGrouppedShapes.GetShapeElement(new Square(0));
            var grouppedCircles = listOfGrouppedShapes.GetShapeElement(new Circle());
            var grouppedTriangles = listOfGrouppedShapes.GetShapeElement(new Triangle());

            if (grouppedTriangles.NumberOf >= grouppedCircles.NumberOf && grouppedTriangles.NumberOf >= squareMetrics.NumberOf)
            {
                if (grouppedCircles.NumberOf >= squareMetrics.NumberOf)
                {
                    return grouppedTriangles.TextToPrint + "\n" + grouppedCircles.TextToPrint + "\n" + squareMetrics.TextToPrint;
                }
                else
                {
                    return grouppedTriangles.TextToPrint + "\n" + squareMetrics.TextToPrint + "\n" + grouppedCircles.TextToPrint;
                }
            }
            else
            {
                return Succcessor?.OrderPrintedResults(listOfGrouppedShapes);
            }
        }
    }
}