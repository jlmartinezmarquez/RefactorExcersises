using Refactoring.Shapes.Solution.Patterns.Facade;
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

        public override string OrderPrintedResults(IFacadeListOfGrouppedShapes facadeListOfGrouppedShapes)
        {
            var numberOfSquares = facadeListOfGrouppedShapes.NumberOf<Square>();
            var numberOfCircles = facadeListOfGrouppedShapes.NumberOf<Circle>();
            var numberOfTriangles = facadeListOfGrouppedShapes.NumberOf<Triangle>();
            
            if (numberOfSquares >= numberOfCircles && numberOfSquares >= numberOfTriangles)
            {
                if (numberOfCircles >= numberOfTriangles)
                {
                    return facadeListOfGrouppedShapes.TextToPrint<Square>() + "\n" + facadeListOfGrouppedShapes.TextToPrint<Circle>() + "\n" + facadeListOfGrouppedShapes.TextToPrint<Triangle>();
                }
                else
                {
                    return facadeListOfGrouppedShapes.TextToPrint<Square>() + "\n" + facadeListOfGrouppedShapes.TextToPrint<Triangle>() + "\n" + facadeListOfGrouppedShapes.TextToPrint<Circle>();
                }
            }
            else
            {
                return Succcessor?.OrderPrintedResults(facadeListOfGrouppedShapes);
            }
        }
    }
}