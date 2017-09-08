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

        public override string OrderPrintedResults(IEncapsulatedListOfGrouppedShapes encapsulatedListOfGrouppedShapes)
        {
            var numberOfSquares = encapsulatedListOfGrouppedShapes.NumberOf<Square>();
            var numberOfTriangles = encapsulatedListOfGrouppedShapes.NumberOf<Triangle>();

            if (numberOfTriangles >= numberOfSquares)
            {
                return encapsulatedListOfGrouppedShapes.TextToPrint<Circle>() + "\n" + encapsulatedListOfGrouppedShapes.TextToPrint<Triangle>() + "\n" + encapsulatedListOfGrouppedShapes.TextToPrint<Square>();
            }

            return encapsulatedListOfGrouppedShapes.TextToPrint<Circle>() + "\n" + encapsulatedListOfGrouppedShapes.TextToPrint<Square>() + "\n" + encapsulatedListOfGrouppedShapes.TextToPrint<Triangle>();
        }
    }
}