using Refactoring.Shapes.Solution.Shapes;
using Refactoring.Shapes.Solution.Shapes.GrouppedShapes;

namespace Refactoring.Shapes.Solution.Patterns.ChainOfResponsibility
{
    public class OrderPrintedResultsDefault : OrderPrintedResultsChainOfResponsibility
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

            if (grouppedTriangles.NumberOf >= squareMetrics.NumberOf)
            {
                return grouppedCircles.TextToPrint + "\n" + grouppedTriangles.TextToPrint + "\n" + squareMetrics.TextToPrint;
            }

            return grouppedCircles.TextToPrint + "\n" + squareMetrics.TextToPrint + "\n" + grouppedTriangles.TextToPrint;
        }
    }
}