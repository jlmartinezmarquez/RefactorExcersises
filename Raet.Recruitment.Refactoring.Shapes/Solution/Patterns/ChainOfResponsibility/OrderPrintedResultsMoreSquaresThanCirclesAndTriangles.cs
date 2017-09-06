using Refactoring.Shapes.Solution.Models;
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

        public override string OrderPrintedResults(ListOfGrouppedShapes listOfGrouppedShapes)
        {
            var grouppedSquares = listOfGrouppedShapes.GetShapeElement(new Square(0));
            var grouppedCircles = listOfGrouppedShapes.GetShapeElement(new Circle());
            var grouppedTriangles = listOfGrouppedShapes.GetShapeElement(new Triangle());
            
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
                return Succcessor?.OrderPrintedResults(listOfGrouppedShapes);
            }
        }
    }
}