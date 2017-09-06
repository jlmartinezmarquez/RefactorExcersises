using Refactoring.Shapes.Solution.Shapes;

namespace Refactoring.Shapes.Solution.Patterns
{
    public abstract class OrderPrintedResultsChainOfResponsability
    {
        protected OrderPrintedResultsChainOfResponsability Succcessor;

        public abstract void SetSuccessor(OrderPrintedResultsChainOfResponsability succcessor);

        public abstract string OrderPrintedResults(Metrics squareMetrics, Metrics circleMetrics, Metrics triangleMetrics);
    }
}
