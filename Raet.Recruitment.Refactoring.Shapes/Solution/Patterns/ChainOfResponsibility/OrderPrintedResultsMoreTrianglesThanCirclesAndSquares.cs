using Refactoring.Shapes.Solution.Shapes;

namespace Refactoring.Shapes.Solution.Patterns.ChainOfResponsibility
{
    public class OrderPrintedResultsMoreTrianglesThanCirclesAndSquares : OrderPrintedResultsChainOfResponsibility
    {
        public override void SetSuccessor(OrderPrintedResultsChainOfResponsibility succcessor)
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