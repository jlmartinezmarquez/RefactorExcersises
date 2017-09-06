using Refactoring.Shapes.Solution.Shapes;

namespace Refactoring.Shapes.Solution.Patterns
{
    public class OrderPrintedResultsDefault : OrderPrintedResultsChainOfResponsability
    {
        public override void SetSuccessor(OrderPrintedResultsChainOfResponsability succcessor)
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