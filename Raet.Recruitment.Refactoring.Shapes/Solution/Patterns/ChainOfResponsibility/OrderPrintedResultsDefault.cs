using Refactoring.Shapes.Solution.Patterns.Facade;
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

        public override string OrderPrintedResults(IFacadeListOfGrouppedShapes facadeListOfGrouppedShapes)
        {
            var numberOfSquares = facadeListOfGrouppedShapes.NumberOf<Square>();
            var numberOfTriangles = facadeListOfGrouppedShapes.NumberOf<Triangle>();

            if (numberOfTriangles >= numberOfSquares)
            {
                return facadeListOfGrouppedShapes.TextToPrint<Circle>() + "\n" + facadeListOfGrouppedShapes.TextToPrint<Triangle>() + "\n" + facadeListOfGrouppedShapes.TextToPrint<Square>();
            }

            return facadeListOfGrouppedShapes.TextToPrint<Circle>() + "\n" + facadeListOfGrouppedShapes.TextToPrint<Square>() + "\n" + facadeListOfGrouppedShapes.TextToPrint<Triangle>();
        }
    }
}