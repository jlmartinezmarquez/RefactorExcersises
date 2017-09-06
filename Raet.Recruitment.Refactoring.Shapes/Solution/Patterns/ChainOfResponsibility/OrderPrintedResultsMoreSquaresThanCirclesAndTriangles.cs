using Refactoring.Shapes.Solution.Shapes;

namespace Refactoring.Shapes.Solution.Patterns.ChainOfResponsibility
{
    public class OrderPrintedResultsMoreSquaresThanCirclesAndTriangles : OrderPrintedResultsChainOfResponsibility
    {
        public override void SetSuccessor(OrderPrintedResultsChainOfResponsibility succcessor)
        {
            Succcessor = succcessor;
        }

        public override string OrderPrintedResults(Metrics squareMetrics, Metrics circleMetrics, Metrics triangleMetrics)
        {
            if (squareMetrics.NumberOf >= circleMetrics.NumberOf && squareMetrics.NumberOf >= triangleMetrics.NumberOf)
            {
                if (circleMetrics.NumberOf >= triangleMetrics.NumberOf)
                {
                    return squareMetrics.ShapeString + "\n" + circleMetrics.ShapeString + "\n" + triangleMetrics.ShapeString;
                }
                else
                {
                    return squareMetrics.ShapeString + "\n" + triangleMetrics.ShapeString + "\n" + circleMetrics.ShapeString;
                }
            }
            else
            {
                return Succcessor?.OrderPrintedResults(squareMetrics, circleMetrics, triangleMetrics);
            }
        }
    }
}