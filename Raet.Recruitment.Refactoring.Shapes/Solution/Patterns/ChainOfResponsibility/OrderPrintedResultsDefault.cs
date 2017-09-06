using Refactoring.Shapes.Solution.Shapes;

namespace Refactoring.Shapes.Solution.Patterns.ChainOfResponsibility
{
    public class OrderPrintedResultsDefault : OrderPrintedResultsChainOfResponsibility
    {
        public override void SetSuccessor(OrderPrintedResultsChainOfResponsibility succcessor)
        {
            Succcessor = succcessor;
        }

        public override string OrderPrintedResults(Metrics squareMetrics, Metrics circleMetrics, Metrics triangleMetrics)
        {
            if (triangleMetrics.NumberOf >= squareMetrics.NumberOf)
            {
                return circleMetrics.ShapeString + "\n" + triangleMetrics.ShapeString + "\n" + squareMetrics.ShapeString;
            }
            else
            {
                return circleMetrics.ShapeString + "\n" + squareMetrics.ShapeString + "\n" + triangleMetrics.ShapeString;
            }
        }
    }
}