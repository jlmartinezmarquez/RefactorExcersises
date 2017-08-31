using Refactoring.Shapes.Solution.Metrics;

namespace Refactoring.Shapes.Solution.Patterns
{
    public abstract class OrderPrintedResultsChainOfResponsability
    {
        protected OrderPrintedResultsChainOfResponsability Succcessor;

        public abstract void SetSuccessor(OrderPrintedResultsChainOfResponsability succcessor);

        public abstract string OrderPrintedResults(IMetrics squareMetrics, IMetrics circleMetrics, IMetrics triangleMetrics);
    }

    public class OrderPrintedResultsMoreSquares : OrderPrintedResultsChainOfResponsability
    {
        public override void SetSuccessor(OrderPrintedResultsChainOfResponsability succcessor)
        {
            Succcessor = succcessor;
        }

        public override string OrderPrintedResults(IMetrics squareMetrics, IMetrics circleMetrics, IMetrics triangleMetrics)
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

    public class OrderPrintedResultsMoreTriangles : OrderPrintedResultsChainOfResponsability
    {
        public override void SetSuccessor(OrderPrintedResultsChainOfResponsability succcessor)
        {
            Succcessor = succcessor;
        }

        public override string OrderPrintedResults(IMetrics squareMetrics, IMetrics circleMetrics, IMetrics triangleMetrics)
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

    public class OrderPrintedResultsDefault : OrderPrintedResultsChainOfResponsability
    {
        public override void SetSuccessor(OrderPrintedResultsChainOfResponsability succcessor)
        {
            Succcessor = succcessor;
        }

        public override string OrderPrintedResults(IMetrics squareMetrics, IMetrics circleMetrics, IMetrics triangleMetrics)
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
