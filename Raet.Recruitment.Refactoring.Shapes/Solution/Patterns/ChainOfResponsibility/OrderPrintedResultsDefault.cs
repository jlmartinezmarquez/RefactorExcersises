using Refactoring.Shapes.Solution.Models;
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

        public override string OrderPrintedResults(ListOfGrouppedShapes listOfGrouppedShapes)
        {
            var squareMetrics = listOfGrouppedShapes.GetShapeElement(new Square(0));
            var grouppedCircles = listOfGrouppedShapes.GetShapeElement(new Circle());
            var grouppedTriangles = listOfGrouppedShapes.GetShapeElement(new Triangle());

            if (grouppedTriangles.NumberOf >= squareMetrics.NumberOf)
            {
                return grouppedCircles.TextToPrint + "\n" + grouppedTriangles.TextToPrint + "\n" + squareMetrics.TextToPrint;
            }

            return grouppedCircles.TextToPrint + "\n" + squareMetrics.TextToPrint + "\n" + grouppedTriangles.TextToPrint;
        }
    }
}