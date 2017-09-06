using Refactoring.Shapes.Solution.Shapes;

namespace Refactoring.Shapes.Solution.Patterns
{
    public class OrderPrintedResultsMoreTrianglesThanCirclesAndSquares : OrderPrintedResultsChainOfResponsability
    {
        public override void SetSuccessor(OrderPrintedResultsChainOfResponsability succcessor)
        {
            Succcessor = succcessor;
        }

        public override string OrderPrintedResults(Metrics squareMetrics, Metrics circleMetrics, Metrics triangleMetrics)
        {
            if (triangleMetrics.NumberOf >= circleMetrics.NumberOf && triangleMetrics.NumberOf >= squareMetrics.NumberOf)
            {
                if (circleMetrics.NumberOf >= squareMetrics.NumberOf)
                {
                    return triangleMetrics.ShapeString + "\n" + circleMetrics.ShapeString + "\n" + squareMetrics.ShapeString;
                }
                else
                {
                    return triangleMetrics.ShapeString + "\n" + squareMetrics.ShapeString + "\n" + circleMetrics.ShapeString;
                }
            }
            else
            {
                return Succcessor?.OrderPrintedResults(squareMetrics, circleMetrics, triangleMetrics);
            }
        }
    }
}