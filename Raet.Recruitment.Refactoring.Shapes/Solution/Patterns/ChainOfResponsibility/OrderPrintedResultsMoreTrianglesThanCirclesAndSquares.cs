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
            var squareMetrics = encapsulatedListOfGrouppedShapes.GetShapeElement(new Square(0));
            var grouppedCircles = encapsulatedListOfGrouppedShapes.GetShapeElement(new Circle(0));
            var grouppedTriangles = encapsulatedListOfGrouppedShapes.GetShapeElement(new Triangle(0));

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
                return Succcessor?.OrderPrintedResults(encapsulatedListOfGrouppedShapes);
            }
        }
    }
}