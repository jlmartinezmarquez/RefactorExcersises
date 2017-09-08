using Refactoring.Shapes.Solution.Patterns.Facade;
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

        public override string OrderPrintedResults(IFacadeListOfGrouppedShapes facadeListOfGrouppedShapes)
        {
            var numberOfSquares = facadeListOfGrouppedShapes.NumberOf<Square>();
            var numberOfCircles = facadeListOfGrouppedShapes.NumberOf<Circle>();
            var numberOfTriangles = facadeListOfGrouppedShapes.NumberOf<Triangle>();

            if (numberOfTriangles >= numberOfCircles && numberOfTriangles >= numberOfSquares)
            {
                if (numberOfCircles >= numberOfSquares)
                {
                    return facadeListOfGrouppedShapes.TextToPrint<Triangle>() + "\n" + facadeListOfGrouppedShapes.TextToPrint<Circle>() + "\n" + facadeListOfGrouppedShapes.TextToPrint<Square>();
                }
                else
                {
                    return facadeListOfGrouppedShapes.TextToPrint<Triangle>() + "\n" + facadeListOfGrouppedShapes.TextToPrint<Square>() + "\n" + facadeListOfGrouppedShapes.TextToPrint<Circle>();
                }
            }
            else
            {
                return Succcessor?.OrderPrintedResults(facadeListOfGrouppedShapes);
            }
        }
    }
}