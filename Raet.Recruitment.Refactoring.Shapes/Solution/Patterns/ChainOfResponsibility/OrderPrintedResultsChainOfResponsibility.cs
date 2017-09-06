using Refactoring.Shapes.Solution.Shapes;

namespace Refactoring.Shapes.Solution.Patterns.ChainOfResponsibility
{
    public abstract class OrderPrintedResultsChainOfResponsibility
    {
        protected OrderPrintedResultsChainOfResponsibility Succcessor;

        public abstract void SetSuccessor(OrderPrintedResultsChainOfResponsibility succcessor);

        public abstract string OrderPrintedResults(Metrics squareMetrics, Metrics circleMetrics, Metrics triangleMetrics);
    }
}
